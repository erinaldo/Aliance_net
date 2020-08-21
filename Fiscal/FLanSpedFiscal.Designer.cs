namespace Fiscal
{
    partial class TFLanSpedFiscal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanSpedFiscal));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_GerarFiscal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.cbAno = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbMes = new Componentes.ComboBoxDefault(this.components);
            this.bb_path = new System.Windows.Forms.Button();
            this.path_sped = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.rg_Finalidade = new Componentes.RadioGroup(this.components);
            this.rb_Substituto = new Componentes.RadioButtonDefault(this.components);
            this.rb_Original = new Componentes.RadioButtonDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.rg_Finalidade.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(570, 39);
            this.barraMenu.TabIndex = 3;
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
            this.pDados.Controls.Add(this.cbEmpresa);
            this.pDados.Controls.Add(this.cbAno);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cbMes);
            this.pDados.Controls.Add(this.bb_path);
            this.pDados.Controls.Add(this.path_sped);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.rg_Finalidade);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 39);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(570, 200);
            this.pDados.TabIndex = 0;
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(104, 29);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(455, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 155;
            // 
            // cbAno
            // 
            this.cbAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAno.FormattingEnabled = true;
            this.cbAno.Location = new System.Drawing.Point(240, 2);
            this.cbAno.Name = "cbAno";
            this.cbAno.NM_Alias = "";
            this.cbAno.NM_Campo = "";
            this.cbAno.NM_Param = "";
            this.cbAno.Size = new System.Drawing.Size(54, 21);
            this.cbAno.ST_Gravar = false;
            this.cbAno.ST_LimparCampo = true;
            this.cbAno.ST_NotNull = false;
            this.cbAno.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(227, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 154;
            this.label2.Text = "/";
            // 
            // cbMes
            // 
            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(104, 2);
            this.cbMes.Name = "cbMes";
            this.cbMes.NM_Alias = "";
            this.cbMes.NM_Campo = "";
            this.cbMes.NM_Param = "";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.ST_Gravar = false;
            this.cbMes.ST_LimparCampo = true;
            this.cbMes.ST_NotNull = false;
            this.cbMes.TabIndex = 0;
            // 
            // bb_path
            // 
            this.bb_path.BackColor = System.Drawing.SystemColors.Control;
            this.bb_path.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_path.Location = new System.Drawing.Point(531, 55);
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
            this.path_sped.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Fiscal.Properties.Settings.Default, "PATH_SPED", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.path_sped.Location = new System.Drawing.Point(104, 55);
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
            this.path_sped.Text = global::Fiscal.Properties.Settings.Default.PATH_SPED;
            this.path_sped.TextOld = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(27, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 149;
            this.label10.Text = "Path Arquivo:";
            // 
            // rg_Finalidade
            // 
            this.rg_Finalidade.Controls.Add(this.rb_Substituto);
            this.rg_Finalidade.Controls.Add(this.rb_Original);
            this.rg_Finalidade.Location = new System.Drawing.Point(104, 81);
            this.rg_Finalidade.Name = "rg_Finalidade";
            this.rg_Finalidade.NM_Alias = "";
            this.rg_Finalidade.NM_Campo = "";
            this.rg_Finalidade.NM_Param = "";
            this.rg_Finalidade.NM_Valor = "";
            this.rg_Finalidade.Size = new System.Drawing.Size(229, 59);
            this.rg_Finalidade.ST_Gravar = false;
            this.rg_Finalidade.ST_NotNull = false;
            this.rg_Finalidade.TabIndex = 6;
            this.rg_Finalidade.TabStop = false;
            this.rg_Finalidade.Text = "Finalidade";
            // 
            // rb_Substituto
            // 
            this.rb_Substituto.AutoSize = true;
            this.rb_Substituto.Checked = true;
            this.rb_Substituto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_Substituto.Location = new System.Drawing.Point(7, 34);
            this.rb_Substituto.Name = "rb_Substituto";
            this.rb_Substituto.Size = new System.Drawing.Size(170, 17);
            this.rb_Substituto.TabIndex = 1;
            this.rb_Substituto.TabStop = true;
            this.rb_Substituto.Text = "Remessa do arquivo substituto";
            this.rb_Substituto.UseVisualStyleBackColor = true;
            this.rb_Substituto.Valor = "";
            // 
            // rb_Original
            // 
            this.rb_Original.AutoSize = true;
            this.rb_Original.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_Original.Location = new System.Drawing.Point(7, 16);
            this.rb_Original.Name = "rb_Original";
            this.rb_Original.Size = new System.Drawing.Size(158, 17);
            this.rb_Original.TabIndex = 0;
            this.rb_Original.Text = "Remessa do arquivo original";
            this.rb_Original.UseVisualStyleBackColor = true;
            this.rb_Original.Valor = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(47, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 147;
            this.label8.Text = "Empresa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(52, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 144;
            this.label1.Text = "Periodo:";
            // 
            // TFLanSpedFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 239);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFLanSpedFiscal";
            this.ShowInTaskbar = false;
            this.Text = "SPED FISCAL - ICMS/IPI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFLanSpedFiscal_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanSpedFiscal_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanSpedFiscal_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.rg_Finalidade.ResumeLayout(false);
            this.rg_Finalidade.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_GerarFiscal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private Componentes.RadioGroup rg_Finalidade;
        private Componentes.RadioButtonDefault rb_Substituto;
        private Componentes.RadioButtonDefault rb_Original;
        private System.Windows.Forms.Button bb_path;
        private Componentes.EditDefault path_sped;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private Componentes.ComboBoxDefault cbAno;
        private System.Windows.Forms.Label label2;
        private Componentes.ComboBoxDefault cbMes;
        private Componentes.ComboBoxDefault cbEmpresa;
    }
}