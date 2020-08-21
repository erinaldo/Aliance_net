namespace Financeiro.Relatorio
{
    partial class TFRel_SaldoSinteticoContaGer
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label cd_EmpresaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRel_SaldoSinteticoContaGer));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.pMoeda = new Componentes.PanelDados(this.components);
            this.sigla_moeda_padrao = new Componentes.EditDefault(this.components);
            this.ds_moeda_padrao = new Componentes.EditDefault(this.components);
            this.cd_moeda_padrao = new Componentes.EditDefault(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.clbContaGer = new Componentes.CheckedListBoxDefault(this.components);
            this.cbMarcaDesmarca = new Componentes.CheckBoxDefault(this.components);
            this.cbContaProvisao = new Componentes.CheckBoxDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            label1 = new System.Windows.Forms.Label();
            cd_EmpresaLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pMoeda.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(3, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(93, 13);
            label1.TabIndex = 36;
            label1.Text = "Moeda Padrão:";
            // 
            // cd_EmpresaLabel
            // 
            cd_EmpresaLabel.AutoSize = true;
            cd_EmpresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_EmpresaLabel.Location = new System.Drawing.Point(10, 6);
            cd_EmpresaLabel.Name = "cd_EmpresaLabel";
            cd_EmpresaLabel.Size = new System.Drawing.Size(59, 13);
            cd_EmpresaLabel.TabIndex = 35;
            cd_EmpresaLabel.Text = "Empresa:";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Imprimir,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(717, 43);
            this.barraMenu.TabIndex = 3;
            // 
            // BB_Novo
            // 
            this.BB_Novo.AutoSize = false;
            this.BB_Novo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BB_Novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Novo.Image")));
            this.BB_Novo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Novo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BB_Novo.Size = new System.Drawing.Size(75, 40);
            this.BB_Novo.Text = "(F2)\r\nLimpar";
            this.BB_Novo.ToolTipText = "Limpar Filtros";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Imprimir
            // 
            this.BB_Imprimir.AutoSize = false;
            this.BB_Imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BB_Imprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Imprimir.ForeColor = System.Drawing.Color.Green;
            this.BB_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Imprimir.Image")));
            this.BB_Imprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Imprimir.Name = "BB_Imprimir";
            this.BB_Imprimir.Size = new System.Drawing.Size(95, 40);
            this.BB_Imprimir.Text = "(F8)\r\nRelatório";
            this.BB_Imprimir.ToolTipText = "Visualizar Relatório";
            this.BB_Imprimir.Click += new System.EventHandler(this.BB_Imprimir_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.pMoeda);
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.cbContaProvisao);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(cd_EmpresaLabel);
            this.pDados.Controls.Add(this.cd_Empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.Size = new System.Drawing.Size(717, 430);
            this.pDados.TabIndex = 4;
            // 
            // pMoeda
            // 
            this.pMoeda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pMoeda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pMoeda.Controls.Add(this.sigla_moeda_padrao);
            this.pMoeda.Controls.Add(this.ds_moeda_padrao);
            this.pMoeda.Controls.Add(this.cd_moeda_padrao);
            this.pMoeda.Controls.Add(label1);
            this.pMoeda.Location = new System.Drawing.Point(75, 388);
            this.pMoeda.Name = "pMoeda";
            this.pMoeda.Size = new System.Drawing.Size(631, 31);
            this.pMoeda.TabIndex = 40;
            // 
            // sigla_moeda_padrao
            // 
            this.sigla_moeda_padrao.BackColor = System.Drawing.Color.White;
            this.sigla_moeda_padrao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_moeda_padrao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_moeda_padrao.Enabled = false;
            this.sigla_moeda_padrao.Location = new System.Drawing.Point(594, 3);
            this.sigla_moeda_padrao.Name = "sigla_moeda_padrao";
            this.sigla_moeda_padrao.NM_Campo = "cd_Empresa";
            this.sigla_moeda_padrao.NM_CampoBusca = "cd_Empresa";
            this.sigla_moeda_padrao.NM_Param = "@P_CD_EMPRESA";
            this.sigla_moeda_padrao.QTD_Zero = 0;
            this.sigla_moeda_padrao.Size = new System.Drawing.Size(29, 20);
            this.sigla_moeda_padrao.ST_AutoInc = false;
            this.sigla_moeda_padrao.ST_DisableAuto = false;
            this.sigla_moeda_padrao.ST_Float = false;
            this.sigla_moeda_padrao.ST_Gravar = true;
            this.sigla_moeda_padrao.ST_Int = false;
            this.sigla_moeda_padrao.ST_LimpaCampo = true;
            this.sigla_moeda_padrao.ST_NotNull = false;
            this.sigla_moeda_padrao.ST_PrimaryKey = false;
            this.sigla_moeda_padrao.TabIndex = 39;
            this.sigla_moeda_padrao.TextOld = null;
            // 
            // ds_moeda_padrao
            // 
            this.ds_moeda_padrao.BackColor = System.Drawing.Color.White;
            this.ds_moeda_padrao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_moeda_padrao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_moeda_padrao.Enabled = false;
            this.ds_moeda_padrao.Location = new System.Drawing.Point(158, 3);
            this.ds_moeda_padrao.Name = "ds_moeda_padrao";
            this.ds_moeda_padrao.NM_Campo = "cd_Empresa";
            this.ds_moeda_padrao.NM_CampoBusca = "cd_Empresa";
            this.ds_moeda_padrao.NM_Param = "@P_CD_EMPRESA";
            this.ds_moeda_padrao.QTD_Zero = 0;
            this.ds_moeda_padrao.Size = new System.Drawing.Size(435, 20);
            this.ds_moeda_padrao.ST_AutoInc = false;
            this.ds_moeda_padrao.ST_DisableAuto = false;
            this.ds_moeda_padrao.ST_Float = false;
            this.ds_moeda_padrao.ST_Gravar = true;
            this.ds_moeda_padrao.ST_Int = false;
            this.ds_moeda_padrao.ST_LimpaCampo = true;
            this.ds_moeda_padrao.ST_NotNull = false;
            this.ds_moeda_padrao.ST_PrimaryKey = false;
            this.ds_moeda_padrao.TabIndex = 38;
            this.ds_moeda_padrao.TextOld = null;
            // 
            // cd_moeda_padrao
            // 
            this.cd_moeda_padrao.BackColor = System.Drawing.Color.White;
            this.cd_moeda_padrao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_moeda_padrao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_moeda_padrao.Enabled = false;
            this.cd_moeda_padrao.Location = new System.Drawing.Point(102, 3);
            this.cd_moeda_padrao.Name = "cd_moeda_padrao";
            this.cd_moeda_padrao.NM_Campo = "cd_Empresa";
            this.cd_moeda_padrao.NM_CampoBusca = "cd_Empresa";
            this.cd_moeda_padrao.NM_Param = "@P_CD_EMPRESA";
            this.cd_moeda_padrao.QTD_Zero = 0;
            this.cd_moeda_padrao.Size = new System.Drawing.Size(55, 20);
            this.cd_moeda_padrao.ST_AutoInc = false;
            this.cd_moeda_padrao.ST_DisableAuto = false;
            this.cd_moeda_padrao.ST_Float = false;
            this.cd_moeda_padrao.ST_Gravar = true;
            this.cd_moeda_padrao.ST_Int = false;
            this.cd_moeda_padrao.ST_LimpaCampo = true;
            this.cd_moeda_padrao.ST_NotNull = false;
            this.cd_moeda_padrao.ST_PrimaryKey = false;
            this.cd_moeda_padrao.TabIndex = 37;
            this.cd_moeda_padrao.TextOld = null;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.clbContaGer);
            this.radioGroup1.Controls.Add(this.cbMarcaDesmarca);
            this.radioGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Location = new System.Drawing.Point(75, 52);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Size = new System.Drawing.Size(631, 330);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 39;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Contas Gerenciais";
            // 
            // clbContaGer
            // 
            this.clbContaGer.CheckOnClick = true;
            this.clbContaGer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbContaGer.FormattingEnabled = true;
            this.clbContaGer.HorizontalScrollbar = true;
            this.clbContaGer.Location = new System.Drawing.Point(6, 37);
            this.clbContaGer.Name = "clbContaGer";
            this.clbContaGer.Size = new System.Drawing.Size(619, 289);
            this.clbContaGer.ST_Gravar = false;
            this.clbContaGer.Tabela = null;
            this.clbContaGer.TabIndex = 7;
            // 
            // cbMarcaDesmarca
            // 
            this.cbMarcaDesmarca.AutoSize = true;
            this.cbMarcaDesmarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMarcaDesmarca.Location = new System.Drawing.Point(6, 19);
            this.cbMarcaDesmarca.Name = "cbMarcaDesmarca";
            this.cbMarcaDesmarca.Size = new System.Drawing.Size(170, 17);
            this.cbMarcaDesmarca.ST_Gravar = false;
            this.cbMarcaDesmarca.ST_LimparCampo = true;
            this.cbMarcaDesmarca.ST_NotNull = false;
            this.cbMarcaDesmarca.TabIndex = 38;
            this.cbMarcaDesmarca.Text = "Marcar/Desmarcar Todos";
            this.cbMarcaDesmarca.UseVisualStyleBackColor = true;
            this.cbMarcaDesmarca.CheckStateChanged += new System.EventHandler(this.cbMarcaDesmarca_CheckStateChanged);
            // 
            // cbContaProvisao
            // 
            this.cbContaProvisao.AutoSize = true;
            this.cbContaProvisao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContaProvisao.Location = new System.Drawing.Point(75, 29);
            this.cbContaProvisao.Name = "cbContaProvisao";
            this.cbContaProvisao.Size = new System.Drawing.Size(242, 17);
            this.cbContaProvisao.ST_Gravar = false;
            this.cbContaProvisao.ST_LimparCampo = true;
            this.cbContaProvisao.ST_NotNull = false;
            this.cbContaProvisao.TabIndex = 37;
            this.cbContaProvisao.Text = "Listar Contas de Provisão de Cheques";
            this.cbContaProvisao.UseVisualStyleBackColor = true;
            this.cbContaProvisao.CheckStateChanged += new System.EventHandler(this.cbContaProvisao_CheckStateChanged);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.Color.White;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(165, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_CD_CONTAGER";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(541, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = true;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 36;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.Location = new System.Drawing.Point(131, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 2;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_Empresa
            // 
            this.cd_Empresa.BackColor = System.Drawing.Color.White;
            this.cd_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_Empresa.Location = new System.Drawing.Point(75, 3);
            this.cd_Empresa.Name = "cd_Empresa";
            this.cd_Empresa.NM_Campo = "cd_Empresa";
            this.cd_Empresa.NM_CampoBusca = "cd_Empresa";
            this.cd_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_Empresa.QTD_Zero = 0;
            this.cd_Empresa.Size = new System.Drawing.Size(55, 20);
            this.cd_Empresa.ST_AutoInc = false;
            this.cd_Empresa.ST_DisableAuto = false;
            this.cd_Empresa.ST_Float = false;
            this.cd_Empresa.ST_Gravar = true;
            this.cd_Empresa.ST_Int = false;
            this.cd_Empresa.ST_LimpaCampo = true;
            this.cd_Empresa.ST_NotNull = false;
            this.cd_Empresa.ST_PrimaryKey = false;
            this.cd_Empresa.TabIndex = 1;
            this.cd_Empresa.TextOld = null;
            this.cd_Empresa.Leave += new System.EventHandler(this.cd_Empresa_Leave);
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(54, 40);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // TFRel_SaldoSinteticoContaGer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 473);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFRel_SaldoSinteticoContaGer";
            this.ShowInTaskbar = false;
            this.Text = "Relatorio Sintetico Saldo Conta Gerencial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFRel_SaldoSinteticoContaGer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRel_SaldoSinteticoContaGer_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pMoeda.ResumeLayout(false);
            this.pMoeda.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Imprimir;
        private Componentes.PanelDados pDados;
        private Componentes.CheckBoxDefault cbContaProvisao;
        private Componentes.CheckedListBoxDefault clbContaGer;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_Empresa;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.CheckBoxDefault cbMarcaDesmarca;
        private Componentes.PanelDados pMoeda;
        private Componentes.EditDefault ds_moeda_padrao;
        private Componentes.EditDefault cd_moeda_padrao;
        private Componentes.EditDefault sigla_moeda_padrao;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
    }
}