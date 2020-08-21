namespace Faturamento
{
    partial class TFAlterarEventoNFCe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAlterarEventoNFCe));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsEvento = new System.Windows.Forms.BindingSource(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.ds_evento = new Componentes.EditDefault(this.components);
            this.tipo_evento = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.chave_acesso = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nr_nfce = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEvento)).BeginInit();
            this.pDados.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(493, 43);
            this.barraMenu.TabIndex = 10;
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
            // bsEvento
            // 
            this.bsEvento.DataSource = typeof(CamadaDados.Faturamento.PDV.TList_EventoNFCe);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.ds_evento);
            this.pDados.Controls.Add(this.tipo_evento);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.chave_acesso);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.nr_nfce);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(493, 276);
            this.pDados.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Descrição Evento";
            // 
            // ds_evento
            // 
            this.ds_evento.BackColor = System.Drawing.SystemColors.Window;
            this.ds_evento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_evento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_evento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEvento, "Ds_evento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_evento.Location = new System.Drawing.Point(11, 98);
            this.ds_evento.Multiline = true;
            this.ds_evento.Name = "ds_evento";
            this.ds_evento.NM_Alias = "";
            this.ds_evento.NM_Campo = "";
            this.ds_evento.NM_CampoBusca = "";
            this.ds_evento.NM_Param = "";
            this.ds_evento.QTD_Zero = 0;
            this.ds_evento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ds_evento.Size = new System.Drawing.Size(472, 165);
            this.ds_evento.ST_AutoInc = false;
            this.ds_evento.ST_DisableAuto = false;
            this.ds_evento.ST_Float = false;
            this.ds_evento.ST_Gravar = false;
            this.ds_evento.ST_Int = false;
            this.ds_evento.ST_LimpaCampo = true;
            this.ds_evento.ST_NotNull = false;
            this.ds_evento.ST_PrimaryKey = false;
            this.ds_evento.TabIndex = 0;
            this.ds_evento.TextOld = null;
            // 
            // tipo_evento
            // 
            this.tipo_evento.BackColor = System.Drawing.SystemColors.Window;
            this.tipo_evento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tipo_evento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tipo_evento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEvento, "Tipo_evento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tipo_evento.Enabled = false;
            this.tipo_evento.Location = new System.Drawing.Point(387, 59);
            this.tipo_evento.Name = "tipo_evento";
            this.tipo_evento.NM_Alias = "";
            this.tipo_evento.NM_Campo = "";
            this.tipo_evento.NM_CampoBusca = "";
            this.tipo_evento.NM_Param = "";
            this.tipo_evento.QTD_Zero = 0;
            this.tipo_evento.Size = new System.Drawing.Size(96, 20);
            this.tipo_evento.ST_AutoInc = false;
            this.tipo_evento.ST_DisableAuto = false;
            this.tipo_evento.ST_Float = false;
            this.tipo_evento.ST_Gravar = false;
            this.tipo_evento.ST_Int = false;
            this.tipo_evento.ST_LimpaCampo = true;
            this.tipo_evento.ST_NotNull = false;
            this.tipo_evento.ST_PrimaryKey = false;
            this.tipo_evento.TabIndex = 8;
            this.tipo_evento.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo Evento";
            // 
            // chave_acesso
            // 
            this.chave_acesso.BackColor = System.Drawing.SystemColors.Window;
            this.chave_acesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chave_acesso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.chave_acesso.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEvento, "Chave_acesso_nfce", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chave_acesso.Enabled = false;
            this.chave_acesso.Location = new System.Drawing.Point(92, 59);
            this.chave_acesso.Name = "chave_acesso";
            this.chave_acesso.NM_Alias = "";
            this.chave_acesso.NM_Campo = "";
            this.chave_acesso.NM_CampoBusca = "";
            this.chave_acesso.NM_Param = "";
            this.chave_acesso.QTD_Zero = 0;
            this.chave_acesso.Size = new System.Drawing.Size(289, 20);
            this.chave_acesso.ST_AutoInc = false;
            this.chave_acesso.ST_DisableAuto = false;
            this.chave_acesso.ST_Float = false;
            this.chave_acesso.ST_Gravar = false;
            this.chave_acesso.ST_Int = false;
            this.chave_acesso.ST_LimpaCampo = true;
            this.chave_acesso.ST_NotNull = false;
            this.chave_acesso.ST_PrimaryKey = false;
            this.chave_acesso.TabIndex = 6;
            this.chave_acesso.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chave Acesso NFC-e";
            // 
            // nr_nfce
            // 
            this.nr_nfce.BackColor = System.Drawing.SystemColors.Window;
            this.nr_nfce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_nfce.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_nfce.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEvento, "Nr_nfce", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_nfce.Enabled = false;
            this.nr_nfce.Location = new System.Drawing.Point(11, 59);
            this.nr_nfce.Name = "nr_nfce";
            this.nr_nfce.NM_Alias = "";
            this.nr_nfce.NM_Campo = "";
            this.nr_nfce.NM_CampoBusca = "";
            this.nr_nfce.NM_Param = "";
            this.nr_nfce.QTD_Zero = 0;
            this.nr_nfce.Size = new System.Drawing.Size(72, 20);
            this.nr_nfce.ST_AutoInc = false;
            this.nr_nfce.ST_DisableAuto = false;
            this.nr_nfce.ST_Float = false;
            this.nr_nfce.ST_Gravar = false;
            this.nr_nfce.ST_Int = false;
            this.nr_nfce.ST_LimpaCampo = true;
            this.nr_nfce.ST_NotNull = false;
            this.nr_nfce.ST_PrimaryKey = false;
            this.nr_nfce.TabIndex = 4;
            this.nr_nfce.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nº NFC-e";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEvento, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(59, 20);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "";
            this.nm_empresa.NM_CampoBusca = "";
            this.nm_empresa.NM_Param = "";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(424, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 2;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEvento, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(11, 20);
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
            this.cd_empresa.TabIndex = 1;
            this.cd_empresa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa";
            // 
            // TFAlterarEventoNFCe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 319);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAlterarEventoNFCe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Evento NFC-e";
            this.Load += new System.EventHandler(this.TFAlterarEventoNFCe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAlterarEventoNFCe_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEvento)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault ds_evento;
        private Componentes.EditDefault tipo_evento;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault chave_acesso;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nr_nfce;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsEvento;
    }
}