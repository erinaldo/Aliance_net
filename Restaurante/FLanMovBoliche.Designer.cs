namespace Restaurante
{
    partial class TFLanMovBoliche
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanMovBoliche));
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.BB_Sair = new System.Windows.Forms.Button();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.nr_cartao = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panelDados2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(this.panel2);
            this.panelDados2.Controls.Add(this.panelDados1);
            this.panelDados2.Controls.Add(this.label2);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(0, 0);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(360, 249);
            this.panelDados2.TabIndex = 82;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.lblTitulo);
            this.panel2.Controls.Add(this.BB_Sair);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 52);
            this.panel2.TabIndex = 81;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(75, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(189, 25);
            this.lblTitulo.TabIndex = 46;
            this.lblTitulo.Text = "Abrir Pista Boliche";
            // 
            // BB_Sair
            // 
            this.BB_Sair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BB_Sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Sair.ForeColor = System.Drawing.Color.Green;
            this.BB_Sair.Image = ((System.Drawing.Image)(resources.GetObject("BB_Sair.Image")));
            this.BB_Sair.Location = new System.Drawing.Point(270, 4);
            this.BB_Sair.Name = "BB_Sair";
            this.BB_Sair.Size = new System.Drawing.Size(79, 45);
            this.BB_Sair.TabIndex = 0;
            this.BB_Sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BB_Sair.UseVisualStyleBackColor = true;
            this.BB_Sair.Click += new System.EventHandler(this.BB_Sair_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.nr_cartao);
            this.panelDados1.Location = new System.Drawing.Point(12, 147);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(336, 54);
            this.panelDados1.TabIndex = 52;
            // 
            // nr_cartao
            // 
            this.nr_cartao.BackColor = System.Drawing.Color.White;
            this.nr_cartao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nr_cartao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cartao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nr_cartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nr_cartao.Location = new System.Drawing.Point(0, 0);
            this.nr_cartao.Name = "nr_cartao";
            this.nr_cartao.NM_Alias = "";
            this.nr_cartao.NM_Campo = "NR_CARTAO";
            this.nr_cartao.NM_CampoBusca = "NR_CARTAO";
            this.nr_cartao.NM_Param = "@P_NR_CARTAO";
            this.nr_cartao.QTD_Zero = 0;
            this.nr_cartao.Size = new System.Drawing.Size(336, 49);
            this.nr_cartao.ST_AutoInc = false;
            this.nr_cartao.ST_DisableAuto = false;
            this.nr_cartao.ST_Float = false;
            this.nr_cartao.ST_Gravar = false;
            this.nr_cartao.ST_Int = true;
            this.nr_cartao.ST_LimpaCampo = true;
            this.nr_cartao.ST_NotNull = true;
            this.nr_cartao.ST_PrimaryKey = false;
            this.nr_cartao.TabIndex = 53;
            this.nr_cartao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nr_cartao.TextOld = null;
            this.nr_cartao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nr_cartao_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(28, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 39);
            this.label2.TabIndex = 51;
            this.label2.Text = "N° Cartão (Enter)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TFLanMovBoliche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 249);
            this.Controls.Add(this.panelDados2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFLanMovBoliche";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe o número do cartão";
            this.Load += new System.EventHandler(this.TFLanMovBoliche_Load);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button BB_Sair;
        private System.Windows.Forms.Label label2;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault nr_cartao;
    }
}