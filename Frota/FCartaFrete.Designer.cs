namespace Frota
{
    partial class TFCartaFrete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCartaFrete));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.bsCartaCorrecao = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vl_documento = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dt_emissao = new Componentes.EditData(this.components);
            this.nm_motorista = new Componentes.EditDefault(this.components);
            this.bb_motorista = new System.Windows.Forms.Button();
            this.cd_motorista = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartaCorrecao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(572, 43);
            this.barraMenu.TabIndex = 19;
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.vl_documento);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.dt_emissao);
            this.pDados.Controls.Add(this.nm_motorista);
            this.pDados.Controls.Add(this.bb_motorista);
            this.pDados.Controls.Add(this.cd_motorista);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(572, 162);
            this.pDados.TabIndex = 20;
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaCorrecao, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(68, 83);
            this.ds_observacao.MaxLength = 2048;
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(497, 72);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 6;
            this.ds_observacao.TextOld = null;
            // 
            // bsCartaCorrecao
            // 
            this.bsCartaCorrecao.DataSource = typeof(CamadaDados.Frota.TList_CartaFrete);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Vl. Documento:";
            // 
            // vl_documento
            // 
            this.vl_documento.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCartaCorrecao, "Vl_documento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_documento.DecimalPlaces = 2;
            this.vl_documento.Location = new System.Drawing.Point(232, 57);
            this.vl_documento.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_documento.Name = "vl_documento";
            this.vl_documento.NM_Alias = "";
            this.vl_documento.NM_Campo = "";
            this.vl_documento.NM_Param = "";
            this.vl_documento.Operador = "";
            this.vl_documento.Size = new System.Drawing.Size(120, 20);
            this.vl_documento.ST_AutoInc = false;
            this.vl_documento.ST_DisableAuto = false;
            this.vl_documento.ST_Gravar = true;
            this.vl_documento.ST_LimparCampo = true;
            this.vl_documento.ST_NotNull = true;
            this.vl_documento.ST_PrimaryKey = false;
            this.vl_documento.TabIndex = 5;
            this.vl_documento.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Emissão:";
            // 
            // dt_emissao
            // 
            this.dt_emissao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_emissao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaCorrecao, "Dt_emissaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_emissao.Location = new System.Drawing.Point(68, 57);
            this.dt_emissao.Mask = "00/00/0000";
            this.dt_emissao.Name = "dt_emissao";
            this.dt_emissao.NM_Alias = "";
            this.dt_emissao.NM_Campo = "";
            this.dt_emissao.NM_CampoBusca = "";
            this.dt_emissao.NM_Param = "";
            this.dt_emissao.Operador = "";
            this.dt_emissao.Size = new System.Drawing.Size(72, 20);
            this.dt_emissao.ST_Gravar = true;
            this.dt_emissao.ST_LimpaCampo = true;
            this.dt_emissao.ST_NotNull = true;
            this.dt_emissao.ST_PrimaryKey = false;
            this.dt_emissao.TabIndex = 4;
            // 
            // nm_motorista
            // 
            this.nm_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.nm_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_motorista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaCorrecao, "Nm_motorista", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_motorista.Enabled = false;
            this.nm_motorista.Location = new System.Drawing.Point(174, 31);
            this.nm_motorista.Name = "nm_motorista";
            this.nm_motorista.NM_Alias = "";
            this.nm_motorista.NM_Campo = "nm_clifor";
            this.nm_motorista.NM_CampoBusca = "nm_clifor";
            this.nm_motorista.NM_Param = "@P_NM_EMPRESA";
            this.nm_motorista.QTD_Zero = 0;
            this.nm_motorista.Size = new System.Drawing.Size(391, 20);
            this.nm_motorista.ST_AutoInc = false;
            this.nm_motorista.ST_DisableAuto = false;
            this.nm_motorista.ST_Float = false;
            this.nm_motorista.ST_Gravar = false;
            this.nm_motorista.ST_Int = false;
            this.nm_motorista.ST_LimpaCampo = true;
            this.nm_motorista.ST_NotNull = false;
            this.nm_motorista.ST_PrimaryKey = false;
            this.nm_motorista.TabIndex = 68;
            this.nm_motorista.TextOld = null;
            // 
            // bb_motorista
            // 
            this.bb_motorista.Image = ((System.Drawing.Image)(resources.GetObject("bb_motorista.Image")));
            this.bb_motorista.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_motorista.Location = new System.Drawing.Point(140, 31);
            this.bb_motorista.Name = "bb_motorista";
            this.bb_motorista.Size = new System.Drawing.Size(28, 20);
            this.bb_motorista.TabIndex = 3;
            this.bb_motorista.UseVisualStyleBackColor = true;
            this.bb_motorista.Click += new System.EventHandler(this.bb_motorista_Click);
            // 
            // cd_motorista
            // 
            this.cd_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.cd_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_motorista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaCorrecao, "Cd_motorista", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_motorista.Location = new System.Drawing.Point(68, 31);
            this.cd_motorista.Name = "cd_motorista";
            this.cd_motorista.NM_Alias = "";
            this.cd_motorista.NM_Campo = "cd_clifor";
            this.cd_motorista.NM_CampoBusca = "cd_clifor";
            this.cd_motorista.NM_Param = "@P_CD_EMPRESA";
            this.cd_motorista.QTD_Zero = 0;
            this.cd_motorista.Size = new System.Drawing.Size(72, 20);
            this.cd_motorista.ST_AutoInc = false;
            this.cd_motorista.ST_DisableAuto = false;
            this.cd_motorista.ST_Float = false;
            this.cd_motorista.ST_Gravar = true;
            this.cd_motorista.ST_Int = false;
            this.cd_motorista.ST_LimpaCampo = true;
            this.cd_motorista.ST_NotNull = true;
            this.cd_motorista.ST_PrimaryKey = false;
            this.cd_motorista.TabIndex = 2;
            this.cd_motorista.TextOld = null;
            this.cd_motorista.Leave += new System.EventHandler(this.cd_motorista_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 67;
            this.label8.Text = "Motorista:";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaCorrecao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(174, 5);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(391, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 60;
            this.nm_empresa.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Empresa:";
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(140, 5);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaCorrecao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(68, 5);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(72, 20);
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
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // TFCartaFrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 205);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCartaFrete";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carta Frete";
            this.Load += new System.EventHandler(this.TFCartaFrete_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCartaFrete_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartaCorrecao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_motorista;
        private System.Windows.Forms.Button bb_motorista;
        private Componentes.EditDefault cd_motorista;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat vl_documento;
        private System.Windows.Forms.Label label2;
        private Componentes.EditData dt_emissao;
        private System.Windows.Forms.BindingSource bsCartaCorrecao;
    }
}