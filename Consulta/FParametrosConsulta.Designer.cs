namespace Consulta
{
    partial class TFParametrosConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFParametrosConsulta));
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.vparam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vvalor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gParam = new System.Windows.Forms.DataGridView();
            this.param = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TS_Param = new System.Windows.Forms.ToolStrip();
            this.bb_gravar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gParam)).BeginInit();
            this.TS_Param.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.gParam);
            this.panelDados1.Controls.Add(this.TS_Param);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 0);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(600, 262);
            this.panelDados1.TabIndex = 0;
            // 
            // vparam
            // 
            this.vparam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vparam.DataPropertyName = "param";
            this.vparam.HeaderText = "Parametros";
            this.vparam.Name = "vparam";
            this.vparam.ReadOnly = true;
            // 
            // vvalor
            // 
            this.vvalor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vvalor.DataPropertyName = "valor";
            this.vvalor.HeaderText = "Valor";
            this.vvalor.Name = "vvalor";
            this.vvalor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // gParam
            // 
            this.gParam.AllowUserToAddRows = false;
            this.gParam.AllowUserToDeleteRows = false;
            this.gParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.param,
            this.valor});
            this.gParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gParam.Location = new System.Drawing.Point(0, 25);
            this.gParam.Name = "gParam";
            this.gParam.Size = new System.Drawing.Size(598, 235);
            this.gParam.TabIndex = 0;
            // 
            // param
            // 
            this.param.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.param.DataPropertyName = "param";
            this.param.HeaderText = "Parametros";
            this.param.Name = "param";
            this.param.Width = 85;
            // 
            // valor
            // 
            this.valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.valor.DataPropertyName = "valor";
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.Width = 56;
            // 
            // TS_Param
            // 
            this.TS_Param.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_gravar});
            this.TS_Param.Location = new System.Drawing.Point(0, 0);
            this.TS_Param.Name = "TS_Param";
            this.TS_Param.Size = new System.Drawing.Size(598, 25);
            this.TS_Param.TabIndex = 32;
            // 
            // bb_gravar
            // 
            this.bb_gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_gravar.Image = ((System.Drawing.Image)(resources.GetObject("bb_gravar.Image")));
            this.bb_gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_gravar.Name = "bb_gravar";
            this.bb_gravar.Size = new System.Drawing.Size(92, 22);
            this.bb_gravar.Text = "(F4) Gravar";
            this.bb_gravar.Click += new System.EventHandler(this.bb_gravar_Click);
            // 
            // TFParametrosConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 262);
            this.Controls.Add(this.panelDados1);
            this.KeyPreview = true;
            this.Name = "TFParametrosConsulta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametros de Consulta - ESC para Sair";
            this.Load += new System.EventHandler(this.TFParametrosConsulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFParametrosConsulta_KeyDown);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gParam)).EndInit();
            this.TS_Param.ResumeLayout(false);
            this.TS_Param.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.DataGridViewTextBoxColumn vparam;
        private System.Windows.Forms.DataGridViewTextBoxColumn vvalor;
        private System.Windows.Forms.DataGridView gParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn param;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.ToolStrip TS_Param;
        private System.Windows.Forms.ToolStripButton bb_gravar;
    }
}