namespace Contabil.Relatorio
{
    partial class TFRel_DRE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRel_DRE));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.cbDRE = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cbAno = new Componentes.ComboBoxDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Imprimir,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(551, 43);
            this.barraMenu.TabIndex = 7;
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.cbDRE);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.cbEmpresa);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.cbAno);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(551, 91);
            this.panelDados1.TabIndex = 0;
            // 
            // cbDRE
            // 
            this.cbDRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDRE.FormattingEnabled = true;
            this.cbDRE.Location = new System.Drawing.Point(71, 57);
            this.cbDRE.Name = "cbDRE";
            this.cbDRE.NM_Alias = "";
            this.cbDRE.NM_Campo = "";
            this.cbDRE.NM_Param = "";
            this.cbDRE.Size = new System.Drawing.Size(468, 21);
            this.cbDRE.ST_Gravar = false;
            this.cbDRE.ST_LimparCampo = true;
            this.cbDRE.ST_NotNull = false;
            this.cbDRE.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "DRE:";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(71, 30);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(468, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Empresa:";
            // 
            // cbAno
            // 
            this.cbAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAno.FormattingEnabled = true;
            this.cbAno.Location = new System.Drawing.Point(71, 3);
            this.cbAno.Name = "cbAno";
            this.cbAno.NM_Alias = "";
            this.cbAno.NM_Campo = "";
            this.cbAno.NM_Param = "";
            this.cbAno.Size = new System.Drawing.Size(121, 21);
            this.cbAno.ST_Gravar = false;
            this.cbAno.ST_LimparCampo = true;
            this.cbAno.ST_NotNull = false;
            this.cbAno.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exercicio:";
            // 
            // TFRel_DRE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 134);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFRel_DRE";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório DRE - Demonstrativo do Resultado do Exercicio";
            this.Load += new System.EventHandler(this.TFRel_DRE_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRel_DRE_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private Componentes.PanelDados panelDados1;
        private Componentes.ComboBoxDefault cbAno;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault cbDRE;
        private System.Windows.Forms.Label label2;
        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.Label label3;
    }
}