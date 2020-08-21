namespace Contabil
{
    partial class TFLanSpedContabil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanSpedContabil));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_GerarFiscal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_path = new System.Windows.Forms.Button();
            this.path_sped = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.dt_fin = new Componentes.EditData(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dt_ini = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cbDRE = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_GerarFiscal,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(869, 39);
            this.barraMenu.TabIndex = 5;
            // 
            // BB_GerarFiscal
            // 
            this.BB_GerarFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_GerarFiscal.ForeColor = System.Drawing.Color.Green;
            this.BB_GerarFiscal.Image = ((System.Drawing.Image)(resources.GetObject("BB_GerarFiscal.Image")));
            this.BB_GerarFiscal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_GerarFiscal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_GerarFiscal.Name = "BB_GerarFiscal";
            this.BB_GerarFiscal.Size = new System.Drawing.Size(111, 36);
            this.BB_GerarFiscal.Text = "(F4)\r\nGerar SPED";
            this.BB_GerarFiscal.ToolTipText = "Gerar SPED";
            this.BB_GerarFiscal.Click += new System.EventHandler(this.BB_GerarFiscal_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
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
            this.BB_Fechar.Size = new System.Drawing.Size(54, 36);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.cbDRE);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.bb_path);
            this.pDados.Controls.Add(this.path_sped);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.cbEmpresa);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.dt_fin);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.dt_ini);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 39);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(869, 448);
            this.pDados.TabIndex = 0;
            // 
            // bb_path
            // 
            this.bb_path.BackColor = System.Drawing.SystemColors.Control;
            this.bb_path.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_path.Location = new System.Drawing.Point(511, 88);
            this.bb_path.Name = "bb_path";
            this.bb_path.Size = new System.Drawing.Size(28, 19);
            this.bb_path.TabIndex = 5;
            this.bb_path.Text = "...";
            this.bb_path.UseVisualStyleBackColor = false;
            this.bb_path.Click += new System.EventHandler(this.bb_path_Click);
            // 
            // path_sped
            // 
            this.path_sped.BackColor = System.Drawing.SystemColors.Window;
            this.path_sped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.path_sped.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.path_sped.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Contabil.Properties.Settings.Default, "PATH_SPEDCONTABIL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.path_sped.Location = new System.Drawing.Point(84, 88);
            this.path_sped.Name = "path_sped";
            this.path_sped.NM_Alias = "";
            this.path_sped.NM_Campo = "";
            this.path_sped.NM_CampoBusca = "";
            this.path_sped.NM_Param = "";
            this.path_sped.QTD_Zero = 0;
            this.path_sped.Size = new System.Drawing.Size(426, 20);
            this.path_sped.ST_AutoInc = false;
            this.path_sped.ST_DisableAuto = false;
            this.path_sped.ST_Float = false;
            this.path_sped.ST_Gravar = false;
            this.path_sped.ST_Int = false;
            this.path_sped.ST_LimpaCampo = true;
            this.path_sped.ST_NotNull = false;
            this.path_sped.ST_PrimaryKey = false;
            this.path_sped.TabIndex = 4;
            this.path_sped.Text = global::Contabil.Properties.Settings.Default.PATH_SPEDCONTABIL;
            this.path_sped.TextOld = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(7, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 166;
            this.label10.Text = "Path Arquivo:";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(84, 34);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(455, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(27, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 163;
            this.label8.Text = "Empresa:";
            // 
            // dt_fin
            // 
            this.dt_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin.Location = new System.Drawing.Point(187, 8);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Operador = "";
            this.dt_fin.Size = new System.Drawing.Size(69, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(159, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 160;
            this.label1.Text = "até";
            // 
            // dt_ini
            // 
            this.dt_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini.Location = new System.Drawing.Point(84, 8);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Operador = "";
            this.dt_ini.Size = new System.Drawing.Size(69, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(32, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 158;
            this.label3.Text = "Periodo:";
            // 
            // cbDRE
            // 
            this.cbDRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDRE.FormattingEnabled = true;
            this.cbDRE.Location = new System.Drawing.Point(84, 61);
            this.cbDRE.Name = "cbDRE";
            this.cbDRE.NM_Alias = "";
            this.cbDRE.NM_Campo = "";
            this.cbDRE.NM_Param = "";
            this.cbDRE.Size = new System.Drawing.Size(455, 21);
            this.cbDRE.ST_Gravar = false;
            this.cbDRE.ST_LimparCampo = true;
            this.cbDRE.ST_NotNull = false;
            this.cbDRE.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(45, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 168;
            this.label2.Text = "DRE:";
            // 
            // TFLanSpedContabil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 487);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFLanSpedContabil";
            this.ShowInTaskbar = false;
            this.Text = "Gerar Sped Contabil";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFLanSpedContabil_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanSpedContabil_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanSpedContabil_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_GerarFiscal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private Componentes.PanelDados pDados;
        private Componentes.EditData dt_fin;
        private System.Windows.Forms.Label label1;
        private Componentes.EditData dt_ini;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bb_path;
        private Componentes.EditDefault path_sped;
        private System.Windows.Forms.Label label10;
        private Componentes.ComboBoxDefault cbDRE;
        private System.Windows.Forms.Label label2;
    }
}