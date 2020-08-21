namespace Financeiro
{
    partial class TFReimprimirCheques
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFReimprimirCheques));
            System.Windows.Forms.Label nr_chequeLabel;
            System.Windows.Forms.Label label2;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.BB_Banco = new System.Windows.Forms.Button();
            this.ds_banco = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cd_banco = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.nr_chequeini = new Componentes.EditDefault(this.components);
            this.nr_chequefin = new Componentes.EditDefault(this.components);
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            nr_chequeLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(594, 43);
            this.barraMenu.TabIndex = 12;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(100, 40);
            this.BB_Gravar.Text = " (F4)\r\n Imprimir";
            this.BB_Gravar.ToolTipText = "Imprimir Titulos";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.nr_chequefin);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.nr_chequeini);
            this.pDados.Controls.Add(nr_chequeLabel);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.BB_Banco);
            this.pDados.Controls.Add(this.ds_banco);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.cd_banco);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(594, 84);
            this.pDados.TabIndex = 13;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(195, 6);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 1;
            this.BB_Empresa.UseVisualStyleBackColor = false;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Location = new System.Drawing.Point(115, 5);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(79, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(50, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Empresa:";
            // 
            // BB_Banco
            // 
            this.BB_Banco.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Banco.Image = ((System.Drawing.Image)(resources.GetObject("BB_Banco.Image")));
            this.BB_Banco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Banco.Location = new System.Drawing.Point(195, 31);
            this.BB_Banco.Name = "BB_Banco";
            this.BB_Banco.Size = new System.Drawing.Size(28, 19);
            this.BB_Banco.TabIndex = 3;
            this.BB_Banco.UseVisualStyleBackColor = false;
            this.BB_Banco.Click += new System.EventHandler(this.BB_Banco_Click);
            // 
            // ds_banco
            // 
            this.ds_banco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_banco.Enabled = false;
            this.ds_banco.Location = new System.Drawing.Point(224, 31);
            this.ds_banco.MaxLength = 32000;
            this.ds_banco.Name = "ds_banco";
            this.ds_banco.NM_Alias = "";
            this.ds_banco.NM_Campo = "ds_banco";
            this.ds_banco.NM_CampoBusca = "ds_banco";
            this.ds_banco.NM_Param = "@P_DS_BANCO";
            this.ds_banco.QTD_Zero = 0;
            this.ds_banco.Size = new System.Drawing.Size(363, 20);
            this.ds_banco.ST_AutoInc = false;
            this.ds_banco.ST_DisableAuto = false;
            this.ds_banco.ST_Float = false;
            this.ds_banco.ST_Gravar = true;
            this.ds_banco.ST_Int = false;
            this.ds_banco.ST_LimpaCampo = true;
            this.ds_banco.ST_NotNull = true;
            this.ds_banco.ST_PrimaryKey = false;
            this.ds_banco.TabIndex = 529;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(62, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 530;
            this.label10.Text = "Banco:";
            // 
            // cd_banco
            // 
            this.cd_banco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_banco.Location = new System.Drawing.Point(115, 31);
            this.cd_banco.MaxLength = 4;
            this.cd_banco.Name = "cd_banco";
            this.cd_banco.NM_Alias = "";
            this.cd_banco.NM_Campo = "cd_banco";
            this.cd_banco.NM_CampoBusca = "cd_banco";
            this.cd_banco.NM_Param = "@P_CD_BANCO";
            this.cd_banco.QTD_Zero = 0;
            this.cd_banco.Size = new System.Drawing.Size(79, 20);
            this.cd_banco.ST_AutoInc = false;
            this.cd_banco.ST_DisableAuto = true;
            this.cd_banco.ST_Float = false;
            this.cd_banco.ST_Gravar = true;
            this.cd_banco.ST_Int = false;
            this.cd_banco.ST_LimpaCampo = true;
            this.cd_banco.ST_NotNull = true;
            this.cd_banco.ST_PrimaryKey = false;
            this.cd_banco.TabIndex = 2;
            this.cd_banco.Leave += new System.EventHandler(this.cd_banco_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(224, 5);
            this.nm_empresa.MaxLength = 32000;
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_DS_BANCO";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(363, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = true;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = true;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 531;
            // 
            // nr_chequeini
            // 
            this.nr_chequeini.BackColor = System.Drawing.SystemColors.Window;
            this.nr_chequeini.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_chequeini.Location = new System.Drawing.Point(115, 57);
            this.nr_chequeini.Name = "nr_chequeini";
            this.nr_chequeini.NM_Alias = "";
            this.nr_chequeini.NM_Campo = "";
            this.nr_chequeini.NM_CampoBusca = "";
            this.nr_chequeini.NM_Param = "";
            this.nr_chequeini.QTD_Zero = 0;
            this.nr_chequeini.Size = new System.Drawing.Size(145, 20);
            this.nr_chequeini.ST_AutoInc = false;
            this.nr_chequeini.ST_DisableAuto = false;
            this.nr_chequeini.ST_Float = false;
            this.nr_chequeini.ST_Gravar = false;
            this.nr_chequeini.ST_Int = false;
            this.nr_chequeini.ST_LimpaCampo = true;
            this.nr_chequeini.ST_NotNull = true;
            this.nr_chequeini.ST_PrimaryKey = false;
            this.nr_chequeini.TabIndex = 4;
            // 
            // nr_chequeLabel
            // 
            nr_chequeLabel.AutoSize = true;
            nr_chequeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            nr_chequeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            nr_chequeLabel.Location = new System.Drawing.Point(-1, 60);
            nr_chequeLabel.Name = "nr_chequeLabel";
            nr_chequeLabel.Size = new System.Drawing.Size(110, 13);
            nr_chequeLabel.TabIndex = 533;
            nr_chequeLabel.Text = "Nº Cheque Inicial:";
            // 
            // nr_chequefin
            // 
            this.nr_chequefin.BackColor = System.Drawing.SystemColors.Window;
            this.nr_chequefin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_chequefin.Location = new System.Drawing.Point(375, 57);
            this.nr_chequefin.Name = "nr_chequefin";
            this.nr_chequefin.NM_Alias = "";
            this.nr_chequefin.NM_Campo = "";
            this.nr_chequefin.NM_CampoBusca = "";
            this.nr_chequefin.NM_Param = "";
            this.nr_chequefin.QTD_Zero = 0;
            this.nr_chequefin.Size = new System.Drawing.Size(145, 20);
            this.nr_chequefin.ST_AutoInc = false;
            this.nr_chequefin.ST_DisableAuto = false;
            this.nr_chequefin.ST_Float = false;
            this.nr_chequefin.ST_Gravar = false;
            this.nr_chequefin.ST_Int = false;
            this.nr_chequefin.ST_LimpaCampo = true;
            this.nr_chequefin.ST_NotNull = true;
            this.nr_chequefin.ST_PrimaryKey = false;
            this.nr_chequefin.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(266, 60);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(103, 13);
            label2.TabIndex = 535;
            label2.Text = "Nº Cheque Final:";
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.AutoSize = false;
            this.BB_Fechar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(75, 40);
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // TFReimprimirCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 127);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFReimprimirCheques";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reimpressão de Cheques";
            this.Load += new System.EventHandler(this.TFReimprimirCheques_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFReimprimirCheques_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BB_Banco;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault nr_chequeini;
        private System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditDefault ds_banco;
        private Componentes.EditDefault cd_banco;
        private Componentes.EditDefault nr_chequefin;
        private System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}