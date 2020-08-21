namespace Parametros.Diversos
{
    partial class TFBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFBackup));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_path = new System.Windows.Forms.Button();
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.pFtp = new Componentes.PanelDados(this.components);
            this.senha_ftp = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.usuario_ftp = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.nm_servidor_ftp = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pDetalhes = new Componentes.PanelDados(this.components);
            this.st_enviaremail = new Componentes.CheckBoxDefault(this.components);
            this.st_compactar = new Componentes.CheckBoxDefault(this.components);
            this.nm_arquivo_backup = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            this.pFtp.SuspendLayout();
            this.pDetalhes.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // BB_Fechar
            // 
            resources.ApplyResources(this.BB_Fechar, "BB_Fechar");
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tlpCentral
            // 
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.bb_path);
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.pDetalhes);
            this.pDados.Controls.Add(this.nm_arquivo_backup);
            this.pDados.Controls.Add(this.label3);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // bb_path
            // 
            this.bb_path.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_path, "bb_path");
            this.bb_path.Name = "bb_path";
            this.bb_path.UseVisualStyleBackColor = false;
            this.bb_path.Click += new System.EventHandler(this.bb_path_Click);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.pFtp);
            resources.ApplyResources(this.radioGroup1, "radioGroup1");
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabStop = false;
            // 
            // pFtp
            // 
            this.pFtp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pFtp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pFtp.Controls.Add(this.senha_ftp);
            this.pFtp.Controls.Add(this.label6);
            this.pFtp.Controls.Add(this.usuario_ftp);
            this.pFtp.Controls.Add(this.label5);
            this.pFtp.Controls.Add(this.nm_servidor_ftp);
            this.pFtp.Controls.Add(this.label4);
            resources.ApplyResources(this.pFtp, "pFtp");
            this.pFtp.Name = "pFtp";
            this.pFtp.NM_ProcDeletar = "";
            this.pFtp.NM_ProcGravar = "";
            // 
            // senha_ftp
            // 
            this.senha_ftp.BackColor = System.Drawing.SystemColors.Window;
            this.senha_ftp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.senha_ftp.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Parametros.Properties.Settings.Default, "senha_ftp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.senha_ftp, "senha_ftp");
            this.senha_ftp.Name = "senha_ftp";
            this.senha_ftp.NM_Alias = "";
            this.senha_ftp.NM_Campo = "";
            this.senha_ftp.NM_CampoBusca = "";
            this.senha_ftp.NM_Param = "";
            this.senha_ftp.QTD_Zero = 0;
            this.senha_ftp.ST_AutoInc = false;
            this.senha_ftp.ST_DisableAuto = false;
            this.senha_ftp.ST_Float = false;
            this.senha_ftp.ST_Gravar = false;
            this.senha_ftp.ST_Int = false;
            this.senha_ftp.ST_LimpaCampo = true;
            this.senha_ftp.ST_NotNull = false;
            this.senha_ftp.ST_PrimaryKey = false;
            this.senha_ftp.Text = global::Parametros.Properties.Settings.Default.senha_ftp;
            this.senha_ftp.TextOld = null;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // usuario_ftp
            // 
            this.usuario_ftp.BackColor = System.Drawing.SystemColors.Window;
            this.usuario_ftp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuario_ftp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.usuario_ftp.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Parametros.Properties.Settings.Default, "usuario_ftp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.usuario_ftp, "usuario_ftp");
            this.usuario_ftp.Name = "usuario_ftp";
            this.usuario_ftp.NM_Alias = "";
            this.usuario_ftp.NM_Campo = "";
            this.usuario_ftp.NM_CampoBusca = "";
            this.usuario_ftp.NM_Param = "";
            this.usuario_ftp.QTD_Zero = 0;
            this.usuario_ftp.ST_AutoInc = false;
            this.usuario_ftp.ST_DisableAuto = false;
            this.usuario_ftp.ST_Float = false;
            this.usuario_ftp.ST_Gravar = false;
            this.usuario_ftp.ST_Int = false;
            this.usuario_ftp.ST_LimpaCampo = true;
            this.usuario_ftp.ST_NotNull = false;
            this.usuario_ftp.ST_PrimaryKey = false;
            this.usuario_ftp.Text = global::Parametros.Properties.Settings.Default.usuario_ftp;
            this.usuario_ftp.TextOld = null;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // nm_servidor_ftp
            // 
            this.nm_servidor_ftp.BackColor = System.Drawing.SystemColors.Window;
            this.nm_servidor_ftp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_servidor_ftp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_servidor_ftp.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Parametros.Properties.Settings.Default, "servidor_ftp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nm_servidor_ftp, "nm_servidor_ftp");
            this.nm_servidor_ftp.Name = "nm_servidor_ftp";
            this.nm_servidor_ftp.NM_Alias = "";
            this.nm_servidor_ftp.NM_Campo = "";
            this.nm_servidor_ftp.NM_CampoBusca = "";
            this.nm_servidor_ftp.NM_Param = "";
            this.nm_servidor_ftp.QTD_Zero = 0;
            this.nm_servidor_ftp.ST_AutoInc = false;
            this.nm_servidor_ftp.ST_DisableAuto = false;
            this.nm_servidor_ftp.ST_Float = false;
            this.nm_servidor_ftp.ST_Gravar = false;
            this.nm_servidor_ftp.ST_Int = false;
            this.nm_servidor_ftp.ST_LimpaCampo = true;
            this.nm_servidor_ftp.ST_NotNull = false;
            this.nm_servidor_ftp.ST_PrimaryKey = false;
            this.nm_servidor_ftp.Text = global::Parametros.Properties.Settings.Default.servidor_ftp;
            this.nm_servidor_ftp.TextOld = null;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // pDetalhes
            // 
            this.pDetalhes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pDetalhes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDetalhes.Controls.Add(this.st_enviaremail);
            this.pDetalhes.Controls.Add(this.st_compactar);
            resources.ApplyResources(this.pDetalhes, "pDetalhes");
            this.pDetalhes.Name = "pDetalhes";
            this.pDetalhes.NM_ProcDeletar = "";
            this.pDetalhes.NM_ProcGravar = "";
            // 
            // st_enviaremail
            // 
            resources.ApplyResources(this.st_enviaremail, "st_enviaremail");
            this.st_enviaremail.Checked = global::Parametros.Properties.Settings.Default.enviar_ftp;
            this.st_enviaremail.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Parametros.Properties.Settings.Default, "enviar_ftp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_enviaremail.Name = "st_enviaremail";
            this.st_enviaremail.NM_Alias = "";
            this.st_enviaremail.NM_Campo = "";
            this.st_enviaremail.NM_Param = "";
            this.st_enviaremail.ST_Gravar = false;
            this.st_enviaremail.ST_LimparCampo = true;
            this.st_enviaremail.ST_NotNull = false;
            this.st_enviaremail.UseVisualStyleBackColor = true;
            this.st_enviaremail.Vl_False = "";
            this.st_enviaremail.Vl_True = "";
            // 
            // st_compactar
            // 
            resources.ApplyResources(this.st_compactar, "st_compactar");
            this.st_compactar.Checked = global::Parametros.Properties.Settings.Default.compactar_arq;
            this.st_compactar.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Parametros.Properties.Settings.Default, "compactar_arq", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_compactar.Name = "st_compactar";
            this.st_compactar.NM_Alias = "";
            this.st_compactar.NM_Campo = "";
            this.st_compactar.NM_Param = "";
            this.st_compactar.ST_Gravar = false;
            this.st_compactar.ST_LimparCampo = true;
            this.st_compactar.ST_NotNull = false;
            this.st_compactar.UseVisualStyleBackColor = true;
            this.st_compactar.Vl_False = "";
            this.st_compactar.Vl_True = "";
            // 
            // nm_arquivo_backup
            // 
            this.nm_arquivo_backup.BackColor = System.Drawing.SystemColors.Window;
            this.nm_arquivo_backup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_arquivo_backup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_arquivo_backup.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Parametros.Properties.Settings.Default, "path_backup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nm_arquivo_backup, "nm_arquivo_backup");
            this.nm_arquivo_backup.Name = "nm_arquivo_backup";
            this.nm_arquivo_backup.NM_Alias = "";
            this.nm_arquivo_backup.NM_Campo = "";
            this.nm_arquivo_backup.NM_CampoBusca = "";
            this.nm_arquivo_backup.NM_Param = "";
            this.nm_arquivo_backup.QTD_Zero = 0;
            this.nm_arquivo_backup.ST_AutoInc = false;
            this.nm_arquivo_backup.ST_DisableAuto = false;
            this.nm_arquivo_backup.ST_Float = false;
            this.nm_arquivo_backup.ST_Gravar = false;
            this.nm_arquivo_backup.ST_Int = false;
            this.nm_arquivo_backup.ST_LimpaCampo = true;
            this.nm_arquivo_backup.ST_NotNull = false;
            this.nm_arquivo_backup.ST_PrimaryKey = false;
            this.nm_arquivo_backup.Text = global::Parametros.Properties.Settings.Default.path_backup;
            this.nm_arquivo_backup.TextOld = null;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // TFBackup
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFBackup";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFBackup_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFBackup_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFBackup_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.pFtp.ResumeLayout(false);
            this.pFtp.PerformLayout();
            this.pDetalhes.ResumeLayout(false);
            this.pDetalhes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nm_arquivo_backup;
        private System.Windows.Forms.Label label3;
        private Componentes.PanelDados pDetalhes;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.CheckBoxDefault st_enviaremail;
        private Componentes.CheckBoxDefault st_compactar;
        private Componentes.PanelDados pFtp;
        private Componentes.EditDefault senha_ftp;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault usuario_ftp;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault nm_servidor_ftp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_path;
    }
}