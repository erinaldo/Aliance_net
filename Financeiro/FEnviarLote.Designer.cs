namespace Financeiro
{
    partial class TFEnviarLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFEnviarLote));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.nr_lote = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dt_lote = new Componentes.EditData(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(220, 43);
            this.barraMenu.TabIndex = 13;
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
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.dt_lote);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Controls.Add(this.nr_lote);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(220, 59);
            this.panelDados1.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(22, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Nº Lote:";
            // 
            // nr_lote
            // 
            this.nr_lote.BackColor = System.Drawing.SystemColors.Window;
            this.nr_lote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_lote.Location = new System.Drawing.Point(74, 5);
            this.nr_lote.Name = "nr_lote";
            this.nr_lote.NM_Alias = "";
            this.nr_lote.NM_Campo = "";
            this.nr_lote.NM_CampoBusca = "";
            this.nr_lote.NM_Param = "";
            this.nr_lote.QTD_Zero = 0;
            this.nr_lote.Size = new System.Drawing.Size(84, 20);
            this.nr_lote.ST_AutoInc = false;
            this.nr_lote.ST_DisableAuto = false;
            this.nr_lote.ST_Float = false;
            this.nr_lote.ST_Gravar = true;
            this.nr_lote.ST_Int = true;
            this.nr_lote.ST_LimpaCampo = true;
            this.nr_lote.ST_NotNull = false;
            this.nr_lote.ST_PrimaryKey = false;
            this.nr_lote.TabIndex = 0;
            this.nr_lote.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Data Lote:";
            // 
            // dt_lote
            // 
            this.dt_lote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_lote.Location = new System.Drawing.Point(74, 31);
            this.dt_lote.Mask = "00/00/0000";
            this.dt_lote.Name = "dt_lote";
            this.dt_lote.NM_Alias = "";
            this.dt_lote.NM_Campo = "";
            this.dt_lote.NM_CampoBusca = "";
            this.dt_lote.NM_Param = "";
            this.dt_lote.Operador = "";
            this.dt_lote.Size = new System.Drawing.Size(84, 20);
            this.dt_lote.ST_Gravar = false;
            this.dt_lote.ST_LimpaCampo = true;
            this.dt_lote.ST_NotNull = false;
            this.dt_lote.ST_PrimaryKey = false;
            this.dt_lote.TabIndex = 1;
            // 
            // TFEnviarLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 102);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFEnviarLote";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar Lote Custodia/Deposito";
            this.Load += new System.EventHandler(this.TFEnviarLote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFEnviarLote_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditData dt_lote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault nr_lote;
    }
}