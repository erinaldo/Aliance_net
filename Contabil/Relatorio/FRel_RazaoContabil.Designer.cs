namespace Contabil.Relatorio
{
    partial class TFRel_RazaoContabil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRel_RazaoContabil));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.nr_livro = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.st_termoencerramento = new Componentes.CheckBoxDefault(this.components);
            this.st_termoabertura = new Componentes.CheckBoxDefault(this.components);
            this.bb_contactb = new System.Windows.Forms.Button();
            this.cd_contactb = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dt_fin = new Componentes.EditData(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dt_ini = new Componentes.EditData(this.components);
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Imprimir,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(688, 43);
            this.barraMenu.TabIndex = 5;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
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
            // pFiltro
            // 
            this.pFiltro.Controls.Add(this.cbEmpresa);
            this.pFiltro.Controls.Add(this.label6);
            this.pFiltro.Controls.Add(this.nr_livro);
            this.pFiltro.Controls.Add(this.label4);
            this.pFiltro.Controls.Add(this.st_termoencerramento);
            this.pFiltro.Controls.Add(this.st_termoabertura);
            this.pFiltro.Controls.Add(this.bb_contactb);
            this.pFiltro.Controls.Add(this.cd_contactb);
            this.pFiltro.Controls.Add(this.label3);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.dt_fin);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.dt_ini);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(0, 43);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(688, 105);
            this.pFiltro.TabIndex = 6;
            // 
            // nr_livro
            // 
            this.nr_livro.BackColor = System.Drawing.SystemColors.Window;
            this.nr_livro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_livro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_livro.Location = new System.Drawing.Point(620, 78);
            this.nr_livro.Name = "nr_livro";
            this.nr_livro.NM_Alias = "";
            this.nr_livro.NM_Campo = "";
            this.nr_livro.NM_CampoBusca = "";
            this.nr_livro.NM_Param = "";
            this.nr_livro.QTD_Zero = 0;
            this.nr_livro.Size = new System.Drawing.Size(57, 20);
            this.nr_livro.ST_AutoInc = false;
            this.nr_livro.ST_DisableAuto = false;
            this.nr_livro.ST_Float = false;
            this.nr_livro.ST_Gravar = false;
            this.nr_livro.ST_Int = true;
            this.nr_livro.ST_LimpaCampo = true;
            this.nr_livro.ST_NotNull = false;
            this.nr_livro.ST_PrimaryKey = false;
            this.nr_livro.TabIndex = 15;
            this.nr_livro.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(566, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nº Livro:";
            // 
            // st_termoencerramento
            // 
            this.st_termoencerramento.AutoSize = true;
            this.st_termoencerramento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_termoencerramento.Location = new System.Drawing.Point(269, 79);
            this.st_termoencerramento.Name = "st_termoencerramento";
            this.st_termoencerramento.NM_Alias = "";
            this.st_termoencerramento.NM_Campo = "";
            this.st_termoencerramento.NM_Param = "";
            this.st_termoencerramento.Size = new System.Drawing.Size(196, 17);
            this.st_termoencerramento.ST_Gravar = false;
            this.st_termoencerramento.ST_LimparCampo = true;
            this.st_termoencerramento.ST_NotNull = false;
            this.st_termoencerramento.TabIndex = 13;
            this.st_termoencerramento.Text = "Emitir Termo de Encerramento";
            this.st_termoencerramento.UseVisualStyleBackColor = true;
            this.st_termoencerramento.Vl_False = "";
            this.st_termoencerramento.Vl_True = "";
            // 
            // st_termoabertura
            // 
            this.st_termoabertura.AutoSize = true;
            this.st_termoabertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_termoabertura.Location = new System.Drawing.Point(97, 79);
            this.st_termoabertura.Name = "st_termoabertura";
            this.st_termoabertura.NM_Alias = "";
            this.st_termoabertura.NM_Campo = "";
            this.st_termoabertura.NM_Param = "";
            this.st_termoabertura.Size = new System.Drawing.Size(166, 17);
            this.st_termoabertura.ST_Gravar = false;
            this.st_termoabertura.ST_LimparCampo = true;
            this.st_termoabertura.ST_NotNull = false;
            this.st_termoabertura.TabIndex = 12;
            this.st_termoabertura.Text = "Emitir Termo de Abertura";
            this.st_termoabertura.UseVisualStyleBackColor = true;
            this.st_termoabertura.Vl_False = "";
            this.st_termoabertura.Vl_True = "";
            // 
            // bb_contactb
            // 
            this.bb_contactb.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contactb.Image = ((System.Drawing.Image)(resources.GetObject("bb_contactb.Image")));
            this.bb_contactb.Location = new System.Drawing.Point(649, 57);
            this.bb_contactb.Name = "bb_contactb";
            this.bb_contactb.Size = new System.Drawing.Size(28, 19);
            this.bb_contactb.TabIndex = 11;
            this.bb_contactb.UseVisualStyleBackColor = false;
            this.bb_contactb.Click += new System.EventHandler(this.bb_contactb_Click);
            // 
            // cd_contactb
            // 
            this.cd_contactb.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contactb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contactb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contactb.Location = new System.Drawing.Point(97, 57);
            this.cd_contactb.Name = "cd_contactb";
            this.cd_contactb.NM_Alias = "";
            this.cd_contactb.NM_Campo = "";
            this.cd_contactb.NM_CampoBusca = "";
            this.cd_contactb.NM_Param = "";
            this.cd_contactb.QTD_Zero = 0;
            this.cd_contactb.Size = new System.Drawing.Size(549, 20);
            this.cd_contactb.ST_AutoInc = false;
            this.cd_contactb.ST_DisableAuto = false;
            this.cd_contactb.ST_Float = false;
            this.cd_contactb.ST_Gravar = false;
            this.cd_contactb.ST_Int = false;
            this.cd_contactb.ST_LimpaCampo = true;
            this.cd_contactb.ST_NotNull = false;
            this.cd_contactb.ST_PrimaryKey = false;
            this.cd_contactb.TabIndex = 10;
            this.cd_contactb.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Conta Contabil:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Data Final:";
            // 
            // dt_fin
            // 
            this.dt_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin.Location = new System.Drawing.Point(246, 4);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Operador = "";
            this.dt_fin.Size = new System.Drawing.Size(78, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data Inicial:";
            // 
            // dt_ini
            // 
            this.dt_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini.Location = new System.Drawing.Point(97, 4);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Operador = "";
            this.dt_ini.Size = new System.Drawing.Size(78, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 4;
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(97, 30);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(580, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Empresa:";
            // 
            // TFRel_RazaoContabil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 148);
            this.Controls.Add(this.pFiltro);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFRel_RazaoContabil";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorio Razão Contabil";
            this.Load += new System.EventHandler(this.TFRel_RazaoContabil_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRel_RazaoContabil_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.Label label2;
        private Componentes.EditData dt_fin;
        private System.Windows.Forms.Label label1;
        private Componentes.EditData dt_ini;
        private Componentes.EditDefault cd_contactb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_contactb;
        private Componentes.CheckBoxDefault st_termoabertura;
        private Componentes.EditDefault nr_livro;
        private System.Windows.Forms.Label label4;
        private Componentes.CheckBoxDefault st_termoencerramento;
        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.Label label6;
    }
}