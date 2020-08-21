namespace Financeiro.Relatorio
{
    partial class TFRel_SaldoContasGerenciais
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
            System.Windows.Forms.Label cd_EmpresaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRel_SaldoContasGerenciais));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.dtPeriodo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_Empresa = new Componentes.EditDefault(this.components);
            cd_EmpresaLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // cd_EmpresaLabel
            // 
            cd_EmpresaLabel.AutoSize = true;
            cd_EmpresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_EmpresaLabel.Location = new System.Drawing.Point(41, 41);
            cd_EmpresaLabel.Name = "cd_EmpresaLabel";
            cd_EmpresaLabel.Size = new System.Drawing.Size(59, 13);
            cd_EmpresaLabel.TabIndex = 39;
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
            this.barraMenu.Size = new System.Drawing.Size(696, 43);
            this.barraMenu.TabIndex = 4;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.dtPeriodo);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(cd_EmpresaLabel);
            this.pDados.Controls.Add(this.cd_Empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(696, 75);
            this.pDados.TabIndex = 5;
            // 
            // dtPeriodo
            // 
            this.dtPeriodo.CustomFormat = "MMMM/yyyy";
            this.dtPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPeriodo.Location = new System.Drawing.Point(106, 12);
            this.dtPeriodo.Name = "dtPeriodo";
            this.dtPeriodo.ShowUpDown = true;
            this.dtPeriodo.Size = new System.Drawing.Size(115, 20);
            this.dtPeriodo.TabIndex = 145;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 146;
            this.label1.Text = "Data Referencia:";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.Color.White;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(196, 38);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_CD_CONTAGER";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(487, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = true;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 40;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.Location = new System.Drawing.Point(162, 38);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 38;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_Empresa
            // 
            this.cd_Empresa.BackColor = System.Drawing.Color.White;
            this.cd_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_Empresa.Location = new System.Drawing.Point(106, 38);
            this.cd_Empresa.Name = "cd_Empresa";
            this.cd_Empresa.NM_Alias = "";
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
            this.cd_Empresa.TabIndex = 37;
            this.cd_Empresa.TextOld = null;
            this.cd_Empresa.Leave += new System.EventHandler(this.cd_Empresa_Leave);
            // 
            // TFRel_SaldoContasGerenciais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 118);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "TFRel_SaldoContasGerenciais";
            this.ShowInTaskbar = false;
            this.Text = "Relatório Saldo de Contas Gerenciais";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFRel_SaldoContasGerenciais_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRel_SaldoContasGerenciais_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Imprimir;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_Empresa;
        private System.Windows.Forms.DateTimePicker dtPeriodo;
        private System.Windows.Forms.Label label1;
    }
}