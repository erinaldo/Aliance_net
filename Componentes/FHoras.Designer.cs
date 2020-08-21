namespace Componentes
{
    partial class TFHoras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFHoras));
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.horas = new Componentes.EditMask(this.components);
            this.lblCancela = new System.Windows.Forms.Label();
            this.lblConfirma = new System.Windows.Forms.Label();
            this.lblQtde = new System.Windows.Forms.Label();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelDados1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDados1.BackgroundImage")));
            this.panelDados1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.horas);
            this.panelDados1.Controls.Add(this.lblCancela);
            this.panelDados1.Controls.Add(this.lblConfirma);
            this.panelDados1.Controls.Add(this.lblQtde);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 0);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(302, 165);
            this.panelDados1.TabIndex = 3;
            // 
            // horas
            // 
            this.horas.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horas.Location = new System.Drawing.Point(102, 61);
            this.horas.Mask = "00:00";
            this.horas.Name = "horas";
            this.horas.NM_Alias = "";
            this.horas.NM_Campo = "";
            this.horas.NM_CampoBusca = "";
            this.horas.NM_Param = "";
            this.horas.Size = new System.Drawing.Size(100, 41);
            this.horas.ST_Gravar = false;
            this.horas.ST_LimpaCampo = true;
            this.horas.ST_NotNull = false;
            this.horas.ST_PrimaryKey = false;
            this.horas.TabIndex = 5;
            this.horas.ValidatingType = typeof(System.DateTime);
            this.horas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.horas_KeyDown);
            // 
            // lblCancela
            // 
            this.lblCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancela.Location = new System.Drawing.Point(57, 143);
            this.lblCancela.Name = "lblCancela";
            this.lblCancela.Size = new System.Drawing.Size(176, 18);
            this.lblCancela.TabIndex = 3;
            this.lblCancela.Text = "<ESC> Sair";
            this.lblCancela.MouseLeave += new System.EventHandler(this.lblCancela_MouseLeave);
            this.lblCancela.Click += new System.EventHandler(this.lblCancela_Click);
            this.lblCancela.MouseEnter += new System.EventHandler(this.lblCancela_MouseEnter);
            // 
            // lblConfirma
            // 
            this.lblConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirma.Location = new System.Drawing.Point(57, 120);
            this.lblConfirma.Name = "lblConfirma";
            this.lblConfirma.Size = new System.Drawing.Size(176, 19);
            this.lblConfirma.TabIndex = 2;
            this.lblConfirma.Text = "<ENTER> Confirmar";
            this.lblConfirma.MouseLeave += new System.EventHandler(this.lblConfirma_MouseLeave);
            this.lblConfirma.Click += new System.EventHandler(this.lblConfirma_Click);
            this.lblConfirma.MouseEnter += new System.EventHandler(this.lblConfirma_MouseEnter);
            // 
            // lblQtde
            // 
            this.lblQtde.AutoSize = true;
            this.lblQtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtde.Location = new System.Drawing.Point(55, 25);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(82, 29);
            this.lblQtde.TabIndex = 1;
            this.lblQtde.Text = "Horas";
            // 
            // TFHoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 165);
            this.Controls.Add(this.panelDados1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFHoras";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FHoras";
            this.Load += new System.EventHandler(this.TFHoras_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFHoras_KeyDown);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelDados panelDados1;
        private System.Windows.Forms.Label lblCancela;
        private System.Windows.Forms.Label lblConfirma;
        private System.Windows.Forms.Label lblQtde;
        private EditMask horas;
    }
}