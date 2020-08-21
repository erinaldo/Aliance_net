namespace Aliance.NET
{
    partial class TFGerarArqCont
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFGerarArqCont));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_path = new System.Windows.Forms.Button();
            this.path = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.email = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cbAno = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cbMes = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.cbRelNFe = new Componentes.CheckBoxDefault(this.components);
            this.cbRelNFCe = new Componentes.CheckBoxDefault(this.components);
            this.cbNFCe = new Componentes.CheckBoxDefault(this.components);
            this.cbNFe = new Componentes.CheckBoxDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(489, 43);
            this.barraMenu.TabIndex = 7;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.bb_path);
            this.panelDados1.Controls.Add(this.path);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.email);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.cbAno);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.cbMes);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.panelDados2);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.cbEmpresa);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(489, 161);
            this.panelDados1.TabIndex = 0;
            // 
            // bb_path
            // 
            this.bb_path.BackColor = System.Drawing.SystemColors.Control;
            this.bb_path.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_path.Location = new System.Drawing.Point(445, 85);
            this.bb_path.Name = "bb_path";
            this.bb_path.Size = new System.Drawing.Size(28, 21);
            this.bb_path.TabIndex = 5;
            this.bb_path.Text = "...";
            this.bb_path.UseVisualStyleBackColor = false;
            this.bb_path.Click += new System.EventHandler(this.bb_path_Click);
            // 
            // path
            // 
            this.path.BackColor = System.Drawing.SystemColors.Window;
            this.path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.path.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.path.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Aliance.NET.Properties.Settings.Default, "PATH_ARQ", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.path.Location = new System.Drawing.Point(14, 86);
            this.path.Name = "path";
            this.path.NM_Alias = "";
            this.path.NM_Campo = "";
            this.path.NM_CampoBusca = "";
            this.path.NM_Param = "";
            this.path.QTD_Zero = 0;
            this.path.Size = new System.Drawing.Size(430, 20);
            this.path.ST_AutoInc = false;
            this.path.ST_DisableAuto = false;
            this.path.ST_Float = false;
            this.path.ST_Gravar = false;
            this.path.ST_Int = false;
            this.path.ST_LimpaCampo = true;
            this.path.ST_NotNull = false;
            this.path.ST_PrimaryKey = false;
            this.path.TabIndex = 4;
            this.path.Text = global::Aliance.NET.Properties.Settings.Default.PATH_ARQ;
            this.path.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 160;
            this.label5.Text = "Local do Arquivo";
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.SystemColors.Window;
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.email.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Aliance.NET.Properties.Settings.Default, "EmailContador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.email.Location = new System.Drawing.Point(14, 125);
            this.email.Name = "email";
            this.email.NM_Alias = "";
            this.email.NM_Campo = "";
            this.email.NM_CampoBusca = "";
            this.email.NM_Param = "";
            this.email.QTD_Zero = 0;
            this.email.Size = new System.Drawing.Size(459, 20);
            this.email.ST_AutoInc = false;
            this.email.ST_DisableAuto = false;
            this.email.ST_Float = false;
            this.email.ST_Gravar = false;
            this.email.ST_Int = false;
            this.email.ST_LimpaCampo = true;
            this.email.ST_NotNull = false;
            this.email.ST_PrimaryKey = false;
            this.email.TabIndex = 6;
            this.email.Text = global::Aliance.NET.Properties.Settings.Default.EmailContador;
            this.email.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 158;
            this.label4.Text = "Email";
            // 
            // cbAno
            // 
            this.cbAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAno.FormattingEnabled = true;
            this.cbAno.Location = new System.Drawing.Point(419, 19);
            this.cbAno.Name = "cbAno";
            this.cbAno.NM_Alias = "";
            this.cbAno.NM_Campo = "";
            this.cbAno.NM_Param = "";
            this.cbAno.Size = new System.Drawing.Size(54, 21);
            this.cbAno.ST_Gravar = false;
            this.cbAno.ST_LimparCampo = true;
            this.cbAno.ST_NotNull = false;
            this.cbAno.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(406, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 157;
            this.label3.Text = "/";
            // 
            // cbMes
            // 
            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(283, 19);
            this.cbMes.Name = "cbMes";
            this.cbMes.NM_Alias = "";
            this.cbMes.NM_Campo = "";
            this.cbMes.NM_Param = "";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.ST_Gravar = false;
            this.cbMes.ST_LimparCampo = true;
            this.cbMes.ST_NotNull = false;
            this.cbMes.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Periodo";
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.cbRelNFe);
            this.panelDados2.Controls.Add(this.cbRelNFCe);
            this.panelDados2.Controls.Add(this.cbNFCe);
            this.panelDados2.Controls.Add(this.cbNFe);
            this.panelDados2.Location = new System.Drawing.Point(14, 46);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(459, 21);
            this.panelDados2.TabIndex = 3;
            // 
            // cbRelNFe
            // 
            this.cbRelNFe.AutoSize = true;
            this.cbRelNFe.Checked = true;
            this.cbRelNFe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRelNFe.Location = new System.Drawing.Point(203, 3);
            this.cbRelNFe.Name = "cbRelNFe";
            this.cbRelNFe.NM_Alias = "";
            this.cbRelNFe.NM_Campo = "";
            this.cbRelNFe.NM_Param = "";
            this.cbRelNFe.Size = new System.Drawing.Size(110, 17);
            this.cbRelNFe.ST_Gravar = false;
            this.cbRelNFe.ST_LimparCampo = true;
            this.cbRelNFe.ST_NotNull = false;
            this.cbRelNFe.TabIndex = 2;
            this.cbRelNFe.Text = "Rel. Vendas NF-e";
            this.cbRelNFe.UseVisualStyleBackColor = true;
            this.cbRelNFe.Vl_False = "";
            this.cbRelNFe.Vl_True = "";
            // 
            // cbRelNFCe
            // 
            this.cbRelNFCe.AutoSize = true;
            this.cbRelNFCe.Checked = true;
            this.cbRelNFCe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRelNFCe.Location = new System.Drawing.Point(339, 3);
            this.cbRelNFCe.Name = "cbRelNFCe";
            this.cbRelNFCe.NM_Alias = "";
            this.cbRelNFCe.NM_Campo = "";
            this.cbRelNFCe.NM_Param = "";
            this.cbRelNFCe.Size = new System.Drawing.Size(117, 17);
            this.cbRelNFCe.ST_Gravar = false;
            this.cbRelNFCe.ST_LimparCampo = true;
            this.cbRelNFCe.ST_NotNull = false;
            this.cbRelNFCe.TabIndex = 2;
            this.cbRelNFCe.Text = "Rel. Vendas NFC-e";
            this.cbRelNFCe.UseVisualStyleBackColor = true;
            this.cbRelNFCe.Vl_False = "";
            this.cbRelNFCe.Vl_True = "";
            // 
            // cbNFCe
            // 
            this.cbNFCe.AutoSize = true;
            this.cbNFCe.Checked = true;
            this.cbNFCe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNFCe.Location = new System.Drawing.Point(104, 3);
            this.cbNFCe.Name = "cbNFCe";
            this.cbNFCe.NM_Alias = "";
            this.cbNFCe.NM_Campo = "";
            this.cbNFCe.NM_Param = "";
            this.cbNFCe.Size = new System.Drawing.Size(81, 17);
            this.cbNFCe.ST_Gravar = false;
            this.cbNFCe.ST_LimparCampo = true;
            this.cbNFCe.ST_NotNull = false;
            this.cbNFCe.TabIndex = 1;
            this.cbNFCe.Text = "XML NFC-e";
            this.cbNFCe.UseVisualStyleBackColor = true;
            this.cbNFCe.Vl_False = "";
            this.cbNFCe.Vl_True = "";
            // 
            // cbNFe
            // 
            this.cbNFe.AutoSize = true;
            this.cbNFe.Checked = true;
            this.cbNFe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNFe.Location = new System.Drawing.Point(3, 3);
            this.cbNFe.Name = "cbNFe";
            this.cbNFe.NM_Alias = "";
            this.cbNFe.NM_Campo = "";
            this.cbNFe.NM_Param = "";
            this.cbNFe.Size = new System.Drawing.Size(74, 17);
            this.cbNFe.ST_Gravar = false;
            this.cbNFe.ST_LimparCampo = true;
            this.cbNFe.ST_NotNull = false;
            this.cbNFe.TabIndex = 0;
            this.cbNFe.Text = "XML NF-e";
            this.cbNFe.UseVisualStyleBackColor = true;
            this.cbNFe.Vl_False = "";
            this.cbNFe.Vl_True = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Empresa";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(14, 19);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(263, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 0;
            this.cbEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cbEmpresa_SelectionChangeCommitted);
            // 
            // TFGerarArqCont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 204);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFGerarArqCont";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Arquivos Contabilidade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFGerarArqCont_FormClosing);
            this.Load += new System.EventHandler(this.TFGerarArqCont_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFGerarArqCont_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault cbEmpresa;
        private Componentes.PanelDados panelDados2;
        private Componentes.CheckBoxDefault cbRelNFCe;
        private Componentes.CheckBoxDefault cbNFCe;
        private Componentes.CheckBoxDefault cbNFe;
        private System.Windows.Forms.Label label2;
        private Componentes.ComboBoxDefault cbAno;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault cbMes;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault email;
        private Componentes.EditDefault path;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bb_path;
        private Componentes.CheckBoxDefault cbRelNFe;
    }
}