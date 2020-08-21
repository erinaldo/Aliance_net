namespace Faturamento
{
    partial class TFCreditoClifor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCreditoClifor));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.bsCreditoClifor = new System.Windows.Forms.BindingSource(this.components);
            this.dt_credito = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_endereco = new System.Windows.Forms.Button();
            this.ds_endereco = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cd_endereco = new Componentes.EditDefault(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.lbl = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreditoClifor)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(606, 43);
            this.barraMenu.TabIndex = 9;
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
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.dt_credito);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.bb_endereco);
            this.pDados.Controls.Add(this.ds_endereco);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_endereco);
            this.pDados.Controls.Add(this.bb_clifor);
            this.pDados.Controls.Add(this.nm_clifor);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_clifor);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.lbl);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.Size = new System.Drawing.Size(606, 130);
            this.pDados.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(3, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 102;
            this.label4.Text = "Observação:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoClifor, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(76, 106);
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(525, 20);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 7;
            // 
            // bsCreditoClifor
            // 
            this.bsCreditoClifor.DataSource = typeof(CamadaDados.Faturamento.PDV.TList_CreditoClifor);
            // 
            // dt_credito
            // 
            this.dt_credito.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoClifor, "Dt_creditostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_credito.Location = new System.Drawing.Point(76, 80);
            this.dt_credito.Mask = "00/00/0000";
            this.dt_credito.Name = "dt_credito";
            this.dt_credito.Size = new System.Drawing.Size(83, 20);
            this.dt_credito.ST_Gravar = false;
            this.dt_credito.ST_LimpaCampo = true;
            this.dt_credito.ST_NotNull = false;
            this.dt_credito.ST_PrimaryKey = false;
            this.dt_credito.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(37, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Data:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_endereco
            // 
            this.bb_endereco.Image = ((System.Drawing.Image)(resources.GetObject("bb_endereco.Image")));
            this.bb_endereco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_endereco.Location = new System.Drawing.Point(131, 54);
            this.bb_endereco.Name = "bb_endereco";
            this.bb_endereco.Size = new System.Drawing.Size(28, 19);
            this.bb_endereco.TabIndex = 5;
            this.bb_endereco.UseVisualStyleBackColor = true;
            this.bb_endereco.Click += new System.EventHandler(this.bb_endereco_Click);
            // 
            // ds_endereco
            // 
            this.ds_endereco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoClifor, "Ds_endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_endereco.Enabled = false;
            this.ds_endereco.Location = new System.Drawing.Point(165, 54);
            this.ds_endereco.Name = "ds_endereco";
            this.ds_endereco.NM_Campo = "ds_endereco";
            this.ds_endereco.NM_CampoBusca = "ds_endereco";
            this.ds_endereco.NM_Param = "@P_DS_PDV";
            this.ds_endereco.QTD_Zero = 0;
            this.ds_endereco.Size = new System.Drawing.Size(436, 20);
            this.ds_endereco.ST_AutoInc = false;
            this.ds_endereco.ST_DisableAuto = false;
            this.ds_endereco.ST_Float = false;
            this.ds_endereco.ST_Gravar = false;
            this.ds_endereco.ST_Int = false;
            this.ds_endereco.ST_LimpaCampo = true;
            this.ds_endereco.ST_NotNull = false;
            this.ds_endereco.ST_PrimaryKey = false;
            this.ds_endereco.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(14, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 97;
            this.label2.Text = "Endereço:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_endereco
            // 
            this.cd_endereco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoClifor, "Cd_endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_endereco.Location = new System.Drawing.Point(76, 54);
            this.cd_endereco.Name = "cd_endereco";
            this.cd_endereco.NM_Campo = "cd_endereco";
            this.cd_endereco.NM_CampoBusca = "cd_endereco";
            this.cd_endereco.NM_Param = "@P_CD_EMPRESA";
            this.cd_endereco.QTD_Zero = 0;
            this.cd_endereco.Size = new System.Drawing.Size(53, 20);
            this.cd_endereco.ST_AutoInc = false;
            this.cd_endereco.ST_DisableAuto = false;
            this.cd_endereco.ST_Float = false;
            this.cd_endereco.ST_Gravar = true;
            this.cd_endereco.ST_Int = true;
            this.cd_endereco.ST_LimpaCampo = true;
            this.cd_endereco.ST_NotNull = true;
            this.cd_endereco.ST_PrimaryKey = false;
            this.cd_endereco.TabIndex = 4;
            this.cd_endereco.Leave += new System.EventHandler(this.cd_endereco_Leave);
            this.cd_endereco.Enter += new System.EventHandler(this.cd_endereco_Enter);
            // 
            // bb_clifor
            // 
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(165, 28);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(28, 19);
            this.bb_clifor.TabIndex = 3;
            this.bb_clifor.UseVisualStyleBackColor = true;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoClifor, "Nm_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Location = new System.Drawing.Point(199, 28);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_DS_PDV";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(402, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "Cliente:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoClifor, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_clifor.Location = new System.Drawing.Point(76, 28);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_EMPRESA";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(86, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = true;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = true;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 2;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(131, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoClifor, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(165, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_DS_PDV";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(436, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 90;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl.Location = new System.Drawing.Point(19, 6);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(51, 13);
            this.lbl.TabIndex = 89;
            this.lbl.Text = "Empresa:";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoClifor, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(76, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(53, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // TFCreditoClifor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 173);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCreditoClifor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credito Cliente";
            this.Load += new System.EventHandler(this.TFCreditoClifor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCreditoClifor_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreditoClifor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault ds_observacao;
        private Componentes.EditData dt_credito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_endereco;
        private Componentes.EditDefault ds_endereco;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_endereco;
        private System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault nm_clifor;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label lbl;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.BindingSource bsCreditoClifor;
    }
}