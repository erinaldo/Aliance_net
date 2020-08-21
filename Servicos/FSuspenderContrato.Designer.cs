namespace Servicos
{
    partial class TFSuspenderContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFSuspenderContrato));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_motivo = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dt_prevtermsusp = new Componentes.EditData(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(499, 43);
            this.barraMenu.TabIndex = 16;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.dt_prevtermsusp);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_motivo);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(499, 130);
            this.pDados.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Motivo";
            // 
            // ds_motivo
            // 
            this.ds_motivo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_motivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_motivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_motivo.Location = new System.Drawing.Point(8, 21);
            this.ds_motivo.Multiline = true;
            this.ds_motivo.Name = "ds_motivo";
            this.ds_motivo.NM_Alias = "";
            this.ds_motivo.NM_Campo = "";
            this.ds_motivo.NM_CampoBusca = "";
            this.ds_motivo.NM_Param = "";
            this.ds_motivo.QTD_Zero = 0;
            this.ds_motivo.Size = new System.Drawing.Size(483, 62);
            this.ds_motivo.ST_AutoInc = false;
            this.ds_motivo.ST_DisableAuto = false;
            this.ds_motivo.ST_Float = false;
            this.ds_motivo.ST_Gravar = false;
            this.ds_motivo.ST_Int = false;
            this.ds_motivo.ST_LimpaCampo = true;
            this.ds_motivo.ST_NotNull = false;
            this.ds_motivo.ST_PrimaryKey = false;
            this.ds_motivo.TabIndex = 1;
            this.ds_motivo.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dt. Prev. Ter. ";
            // 
            // dt_prevtermsusp
            // 
            this.dt_prevtermsusp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_prevtermsusp.Location = new System.Drawing.Point(8, 102);
            this.dt_prevtermsusp.Mask = "00/00/0000";
            this.dt_prevtermsusp.Name = "dt_prevtermsusp";
            this.dt_prevtermsusp.NM_Alias = "";
            this.dt_prevtermsusp.NM_Campo = "";
            this.dt_prevtermsusp.NM_CampoBusca = "";
            this.dt_prevtermsusp.NM_Param = "";
            this.dt_prevtermsusp.Operador = "";
            this.dt_prevtermsusp.Size = new System.Drawing.Size(81, 20);
            this.dt_prevtermsusp.ST_Gravar = false;
            this.dt_prevtermsusp.ST_LimpaCampo = true;
            this.dt_prevtermsusp.ST_NotNull = false;
            this.dt_prevtermsusp.ST_PrimaryKey = false;
            this.dt_prevtermsusp.TabIndex = 3;
            // 
            // TFSuspenderContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 173);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFSuspenderContrato";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suspender Contrato";
            this.Load += new System.EventHandler(this.TFSuspenderContrato_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFSuspenderContrato_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditData dt_prevtermsusp;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_motivo;
        private System.Windows.Forms.Label label1;
    }
}