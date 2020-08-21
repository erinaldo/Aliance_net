namespace PDV
{
    partial class TFTrocaEspecie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTrocaEspecie));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_cartao = new System.Windows.Forms.Button();
            this.bb_cheque = new System.Windows.Forms.Button();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.bsTrocaEspecie = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.id_caixa = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bb_cartafrete = new System.Windows.Forms.Button();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrocaEspecie)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(634, 43);
            this.barraMenu.TabIndex = 14;
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
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.bb_cartafrete);
            this.panelDados1.Controls.Add(this.bb_cartao);
            this.panelDados1.Controls.Add(this.bb_cheque);
            this.panelDados1.Controls.Add(this.ds_observacao);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.id_caixa);
            this.panelDados1.Controls.Add(this.nm_empresa);
            this.panelDados1.Controls.Add(this.cd_empresa);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(634, 236);
            this.panelDados1.TabIndex = 15;
            // 
            // bb_cartao
            // 
            this.bb_cartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cartao.ForeColor = System.Drawing.Color.Green;
            this.bb_cartao.Image = ((System.Drawing.Image)(resources.GetObject("bb_cartao.Image")));
            this.bb_cartao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_cartao.Location = new System.Drawing.Point(210, 155);
            this.bb_cartao.Name = "bb_cartao";
            this.bb_cartao.Size = new System.Drawing.Size(192, 73);
            this.bb_cartao.TabIndex = 8;
            this.bb_cartao.Text = "Trocar Cartão";
            this.bb_cartao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_cartao.UseVisualStyleBackColor = true;
            this.bb_cartao.Click += new System.EventHandler(this.bb_cartao_Click);
            // 
            // bb_cheque
            // 
            this.bb_cheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cheque.ForeColor = System.Drawing.Color.Green;
            this.bb_cheque.Image = ((System.Drawing.Image)(resources.GetObject("bb_cheque.Image")));
            this.bb_cheque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_cheque.Location = new System.Drawing.Point(12, 155);
            this.bb_cheque.Name = "bb_cheque";
            this.bb_cheque.Size = new System.Drawing.Size(192, 73);
            this.bb_cheque.TabIndex = 7;
            this.bb_cheque.Text = "Trocar Cheque";
            this.bb_cheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_cheque.UseVisualStyleBackColor = true;
            this.bb_cheque.Click += new System.EventHandler(this.bb_cheque_Click);
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTrocaEspecie, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(12, 62);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(613, 77);
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
            // bsTrocaEspecie
            // 
            this.bsTrocaEspecie.DataSource = typeof(CamadaDados.Faturamento.PDV.TList_TrocaEspecie);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Observação";
            // 
            // id_caixa
            // 
            this.id_caixa.BackColor = System.Drawing.SystemColors.Window;
            this.id_caixa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_caixa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_caixa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTrocaEspecie, "Id_caixastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_caixa.Enabled = false;
            this.id_caixa.Location = new System.Drawing.Point(581, 23);
            this.id_caixa.Name = "id_caixa";
            this.id_caixa.NM_Alias = "";
            this.id_caixa.NM_Campo = "";
            this.id_caixa.NM_CampoBusca = "";
            this.id_caixa.NM_Param = "";
            this.id_caixa.QTD_Zero = 0;
            this.id_caixa.Size = new System.Drawing.Size(44, 20);
            this.id_caixa.ST_AutoInc = false;
            this.id_caixa.ST_DisableAuto = false;
            this.id_caixa.ST_Float = false;
            this.id_caixa.ST_Gravar = false;
            this.id_caixa.ST_Int = false;
            this.id_caixa.ST_LimpaCampo = true;
            this.id_caixa.ST_NotNull = false;
            this.id_caixa.ST_PrimaryKey = false;
            this.id_caixa.TabIndex = 4;
            this.id_caixa.TextOld = null;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTrocaEspecie, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(63, 23);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "";
            this.nm_empresa.NM_CampoBusca = "";
            this.nm_empresa.NM_Param = "";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(512, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 3;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTrocaEspecie, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(12, 23);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "";
            this.cd_empresa.NM_CampoBusca = "";
            this.cd_empresa.NM_Param = "";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(45, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 2;
            this.cd_empresa.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(578, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Caixa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa";
            // 
            // bb_cartafrete
            // 
            this.bb_cartafrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cartafrete.ForeColor = System.Drawing.Color.Green;
            this.bb_cartafrete.Image = ((System.Drawing.Image)(resources.GetObject("bb_cartafrete.Image")));
            this.bb_cartafrete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_cartafrete.Location = new System.Drawing.Point(408, 155);
            this.bb_cartafrete.Name = "bb_cartafrete";
            this.bb_cartafrete.Size = new System.Drawing.Size(217, 73);
            this.bb_cartafrete.TabIndex = 9;
            this.bb_cartafrete.Text = "Trocar Carta Frete";
            this.bb_cartafrete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_cartafrete.UseVisualStyleBackColor = true;
            this.bb_cartafrete.Click += new System.EventHandler(this.bb_cartafrete_Click);
            // 
            // TFTrocaEspecie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 279);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFTrocaEspecie";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trocar Especie";
            this.Load += new System.EventHandler(this.TFTrocaEspecie_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFTrocaEspecie_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrocaEspecie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault id_caixa;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_cheque;
        private System.Windows.Forms.Button bb_cartao;
        private System.Windows.Forms.BindingSource bsTrocaEspecie;
        private System.Windows.Forms.Button bb_cartafrete;
    }
}