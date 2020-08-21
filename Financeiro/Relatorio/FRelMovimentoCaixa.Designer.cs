namespace Financeiro.Relatorio
{
    partial class TFRelMovimentoCaixa
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
            System.Windows.Forms.Label cd_ContaGerLabel;
            System.Windows.Forms.Label cd_EmpresaLabel;
            System.Windows.Forms.Label label18;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRelMovimentoCaixa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.clbTpDocto = new Componentes.CheckedListBoxDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_Empresa = new Componentes.EditDefault(this.components);
            this.ds_contager = new Componentes.EditDefault(this.components);
            this.bb_contager = new System.Windows.Forms.Button();
            this.cd_ContaGer = new Componentes.EditDefault(this.components);
            this.pPeriodo = new Componentes.PanelDados(this.components);
            this.DT_Final = new Componentes.EditData(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.DT_Inicial = new Componentes.EditData(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            cd_ContaGerLabel = new System.Windows.Forms.Label();
            cd_EmpresaLabel = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pPeriodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cd_ContaGerLabel
            // 
            cd_ContaGerLabel.AutoSize = true;
            cd_ContaGerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_ContaGerLabel.Location = new System.Drawing.Point(17, 66);
            cd_ContaGerLabel.Name = "cd_ContaGerLabel";
            cd_ContaGerLabel.Size = new System.Drawing.Size(68, 13);
            cd_ContaGerLabel.TabIndex = 31;
            cd_ContaGerLabel.Text = "Conta Ger:";
            // 
            // cd_EmpresaLabel
            // 
            cd_EmpresaLabel.AutoSize = true;
            cd_EmpresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_EmpresaLabel.Location = new System.Drawing.Point(26, 40);
            cd_EmpresaLabel.Name = "cd_EmpresaLabel";
            cd_EmpresaLabel.Size = new System.Drawing.Size(59, 13);
            cd_EmpresaLabel.TabIndex = 35;
            cd_EmpresaLabel.Text = "Empresa:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label18.Location = new System.Drawing.Point(450, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(145, 13);
            label18.TabIndex = 8;
            label18.Text = "Tipo Documento excluir:";
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
            this.barraMenu.Size = new System.Drawing.Size(626, 43);
            this.barraMenu.TabIndex = 2;
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
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Size = new System.Drawing.Size(626, 310);
            this.tlpCentral.TabIndex = 3;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(label18);
            this.pDados.Controls.Add(this.clbTpDocto);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(cd_EmpresaLabel);
            this.pDados.Controls.Add(this.cd_Empresa);
            this.pDados.Controls.Add(this.ds_contager);
            this.pDados.Controls.Add(this.bb_contager);
            this.pDados.Controls.Add(cd_ContaGerLabel);
            this.pDados.Controls.Add(this.cd_ContaGer);
            this.pDados.Controls.Add(this.pPeriodo);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(4, 4);
            this.pDados.Name = "pDados";
            this.pDados.Size = new System.Drawing.Size(618, 302);
            this.pDados.TabIndex = 0;
            // 
            // clbTpDocto
            // 
            this.clbTpDocto.CheckOnClick = true;
            this.clbTpDocto.FormattingEnabled = true;
            this.clbTpDocto.HorizontalScrollbar = true;
            this.clbTpDocto.Location = new System.Drawing.Point(453, 16);
            this.clbTpDocto.Name = "clbTpDocto";
            this.clbTpDocto.Size = new System.Drawing.Size(155, 64);
            this.clbTpDocto.ST_Gravar = false;
            this.clbTpDocto.Tabela = null;
            this.clbTpDocto.TabIndex = 7;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.Color.White;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(178, 37);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_CD_CONTAGER";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(269, 20);
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
            this.bb_empresa.Location = new System.Drawing.Point(144, 37);
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
            this.cd_Empresa.Location = new System.Drawing.Point(88, 37);
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
            // ds_contager
            // 
            this.ds_contager.BackColor = System.Drawing.Color.White;
            this.ds_contager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contager.Enabled = false;
            this.ds_contager.Location = new System.Drawing.Point(178, 63);
            this.ds_contager.Name = "ds_contager";
            this.ds_contager.NM_Campo = "ds_contager";
            this.ds_contager.NM_CampoBusca = "ds_contager";
            this.ds_contager.NM_Param = "@P_CD_CONTAGER";
            this.ds_contager.QTD_Zero = 0;
            this.ds_contager.Size = new System.Drawing.Size(269, 20);
            this.ds_contager.ST_AutoInc = false;
            this.ds_contager.ST_DisableAuto = false;
            this.ds_contager.ST_Float = false;
            this.ds_contager.ST_Gravar = true;
            this.ds_contager.ST_Int = false;
            this.ds_contager.ST_LimpaCampo = true;
            this.ds_contager.ST_NotNull = false;
            this.ds_contager.ST_PrimaryKey = false;
            this.ds_contager.TabIndex = 32;
            this.ds_contager.TextOld = null;
            // 
            // bb_contager
            // 
            this.bb_contager.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contager.Image = ((System.Drawing.Image)(resources.GetObject("bb_contager.Image")));
            this.bb_contager.Location = new System.Drawing.Point(144, 63);
            this.bb_contager.Name = "bb_contager";
            this.bb_contager.Size = new System.Drawing.Size(28, 19);
            this.bb_contager.TabIndex = 4;
            this.bb_contager.UseVisualStyleBackColor = false;
            this.bb_contager.Click += new System.EventHandler(this.bb_contager_Click);
            // 
            // cd_ContaGer
            // 
            this.cd_ContaGer.BackColor = System.Drawing.Color.White;
            this.cd_ContaGer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_ContaGer.Location = new System.Drawing.Point(88, 63);
            this.cd_ContaGer.Name = "cd_ContaGer";
            this.cd_ContaGer.NM_Campo = "cd_ContaGer";
            this.cd_ContaGer.NM_CampoBusca = "cd_ContaGer";
            this.cd_ContaGer.NM_Param = "@P_CD_CONTAGER";
            this.cd_ContaGer.QTD_Zero = 0;
            this.cd_ContaGer.Size = new System.Drawing.Size(55, 20);
            this.cd_ContaGer.ST_AutoInc = false;
            this.cd_ContaGer.ST_DisableAuto = false;
            this.cd_ContaGer.ST_Float = false;
            this.cd_ContaGer.ST_Gravar = true;
            this.cd_ContaGer.ST_Int = false;
            this.cd_ContaGer.ST_LimpaCampo = true;
            this.cd_ContaGer.ST_NotNull = true;
            this.cd_ContaGer.ST_PrimaryKey = false;
            this.cd_ContaGer.TabIndex = 3;
            this.cd_ContaGer.TextOld = null;
            this.cd_ContaGer.Leave += new System.EventHandler(this.cd_ContaGer_Leave);
            // 
            // pPeriodo
            // 
            this.pPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPeriodo.Controls.Add(this.DT_Final);
            this.pPeriodo.Controls.Add(this.label2);
            this.pPeriodo.Controls.Add(this.DT_Inicial);
            this.pPeriodo.Controls.Add(this.label1);
            this.pPeriodo.Location = new System.Drawing.Point(3, 0);
            this.pPeriodo.Name = "pPeriodo";
            this.pPeriodo.Size = new System.Drawing.Size(444, 31);
            this.pPeriodo.TabIndex = 0;
            // 
            // DT_Final
            // 
            this.DT_Final.BackColor = System.Drawing.Color.White;
            this.DT_Final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Final.Location = new System.Drawing.Point(237, 4);
            this.DT_Final.Mask = "00/00/0000";
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.NM_Campo = "dt_lancto";
            this.DT_Final.NM_CampoBusca = "dt_lancto";
            this.DT_Final.NM_Param = "@P_DT_LANCTO";
            this.DT_Final.Size = new System.Drawing.Size(69, 20);
            this.DT_Final.ST_Gravar = false;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = true;
            this.DT_Final.ST_PrimaryKey = false;
            this.DT_Final.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Data Final:";
            // 
            // DT_Inicial
            // 
            this.DT_Inicial.BackColor = System.Drawing.Color.White;
            this.DT_Inicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Inicial.Location = new System.Drawing.Point(87, 4);
            this.DT_Inicial.Mask = "00/00/0000";
            this.DT_Inicial.Name = "DT_Inicial";
            this.DT_Inicial.NM_Campo = "dt_lancto";
            this.DT_Inicial.NM_CampoBusca = "dt_lancto";
            this.DT_Inicial.NM_Param = "@P_DT_LANCTO";
            this.DT_Inicial.Size = new System.Drawing.Size(69, 20);
            this.DT_Inicial.ST_Gravar = false;
            this.DT_Inicial.ST_LimpaCampo = true;
            this.DT_Inicial.ST_NotNull = true;
            this.DT_Inicial.ST_PrimaryKey = false;
            this.DT_Inicial.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Data Inicial:";
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
            // TFRelMovimentoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 353);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFRelMovimentoCaixa";
            this.ShowInTaskbar = false;
            this.Text = "Relatorio de Liquidações por Tipo Documento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFRelMovimentoCaixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRelMovimentoCaixa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pPeriodo.ResumeLayout(false);
            this.pPeriodo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Imprimir;
        private Componentes.PanelDados pPeriodo;
        private Componentes.EditData DT_Inicial;
        private System.Windows.Forms.Label label1;
        private Componentes.EditData DT_Final;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_contager;
        private System.Windows.Forms.Button bb_contager;
        private Componentes.EditDefault cd_ContaGer;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_Empresa;
        private Componentes.CheckedListBoxDefault clbTpDocto;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
    }
}