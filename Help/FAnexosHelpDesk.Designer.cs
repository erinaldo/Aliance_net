namespace Help
{
    partial class TFAnexosHelpDesk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAnexosHelpDesk));
            this.pTop = new Componentes.PanelDados(this.components);
            this.pFechar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.bb_load = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pAnexo = new System.Windows.Forms.PictureBox();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmColar = new System.Windows.Forms.ToolStripMenuItem();
            this.ds_anexo = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_gravar = new System.Windows.Forms.Button();
            this.pTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).BeginInit();
            this.pFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pAnexo)).BeginInit();
            this.ContextMenuStrip.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pTop.Controls.Add(this.pFechar);
            this.pTop.Controls.Add(this.label1);
            this.pTop.ForeColor = System.Drawing.SystemColors.Control;
            this.pTop.Location = new System.Drawing.Point(0, 1);
            this.pTop.Name = "pTop";
            this.pTop.NM_ProcDeletar = "";
            this.pTop.NM_ProcGravar = "";
            this.pTop.Size = new System.Drawing.Size(800, 34);
            this.pTop.TabIndex = 3;
            // 
            // pFechar
            // 
            this.pFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pFechar.Image = ((System.Drawing.Image)(resources.GetObject("pFechar.Image")));
            this.pFechar.Location = new System.Drawing.Point(764, 3);
            this.pFechar.Name = "pFechar";
            this.pFechar.Size = new System.Drawing.Size(33, 29);
            this.pFechar.TabIndex = 1;
            this.pFechar.TabStop = false;
            this.pFechar.Click += new System.EventHandler(this.pFechar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(755, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "ANEXOS EVOLUÇÃO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pFiltro
            // 
            this.pFiltro.BackColor = System.Drawing.Color.Transparent;
            this.pFiltro.Controls.Add(this.bb_load);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.pAnexo);
            this.pFiltro.Controls.Add(this.ds_anexo);
            this.pFiltro.Controls.Add(this.label4);
            this.pFiltro.Location = new System.Drawing.Point(0, 41);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(800, 515);
            this.pFiltro.TabIndex = 4;
            // 
            // bb_load
            // 
            this.bb_load.Location = new System.Drawing.Point(60, 41);
            this.bb_load.Name = "bb_load";
            this.bb_load.Size = new System.Drawing.Size(67, 19);
            this.bb_load.TabIndex = 11;
            this.bb_load.Text = "Load...";
            this.bb_load.UseVisualStyleBackColor = true;
            this.bb_load.Click += new System.EventHandler(this.bb_load_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Imagem";
            // 
            // pAnexo
            // 
            this.pAnexo.ContextMenuStrip = this.ContextMenuStrip;
            this.pAnexo.Location = new System.Drawing.Point(7, 60);
            this.pAnexo.Name = "pAnexo";
            this.pAnexo.Size = new System.Drawing.Size(793, 452);
            this.pAnexo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pAnexo.TabIndex = 9;
            this.pAnexo.TabStop = false;
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmColar});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(103, 26);
            this.ContextMenuStrip.Text = "Colar";
            this.ContextMenuStrip.Click += new System.EventHandler(this.tsmColar_Click);
            // 
            // tsmColar
            // 
            this.tsmColar.Name = "tsmColar";
            this.tsmColar.Size = new System.Drawing.Size(102, 22);
            this.tsmColar.Text = "Colar";
            this.tsmColar.Click += new System.EventHandler(this.tsmColar_Click);
            // 
            // ds_anexo
            // 
            this.ds_anexo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_anexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_anexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_anexo.Location = new System.Drawing.Point(7, 21);
            this.ds_anexo.Name = "ds_anexo";
            this.ds_anexo.NM_Alias = "";
            this.ds_anexo.NM_Campo = "";
            this.ds_anexo.NM_CampoBusca = "";
            this.ds_anexo.NM_Param = "";
            this.ds_anexo.QTD_Zero = 0;
            this.ds_anexo.Size = new System.Drawing.Size(790, 20);
            this.ds_anexo.ST_AutoInc = false;
            this.ds_anexo.ST_DisableAuto = false;
            this.ds_anexo.ST_Float = false;
            this.ds_anexo.ST_Gravar = false;
            this.ds_anexo.ST_Int = false;
            this.ds_anexo.ST_LimpaCampo = true;
            this.ds_anexo.ST_NotNull = false;
            this.ds_anexo.ST_PrimaryKey = false;
            this.ds_anexo.TabIndex = 3;
            this.ds_anexo.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Descrição";
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.Transparent;
            this.panelDados1.Controls.Add(this.bb_gravar);
            this.panelDados1.Location = new System.Drawing.Point(0, 563);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(800, 54);
            this.panelDados1.TabIndex = 5;
            // 
            // bb_gravar
            // 
            this.bb_gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_gravar.ForeColor = System.Drawing.Color.Green;
            this.bb_gravar.Image = ((System.Drawing.Image)(resources.GetObject("bb_gravar.Image")));
            this.bb_gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_gravar.Location = new System.Drawing.Point(298, 3);
            this.bb_gravar.Name = "bb_gravar";
            this.bb_gravar.Size = new System.Drawing.Size(116, 48);
            this.bb_gravar.TabIndex = 0;
            this.bb_gravar.Text = "(F4)\r\nGravar";
            this.bb_gravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_gravar.UseVisualStyleBackColor = true;
            this.bb_gravar.Click += new System.EventHandler(this.bb_gravar_Click);
            // 
            // TFAnexosHelpDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 617);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.pFiltro);
            this.Controls.Add(this.pTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFAnexosHelpDesk";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TFAnexosHelpDesk_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAnexosHelpDesk_KeyDown);
            this.pTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).EndInit();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pAnexo)).EndInit();
            this.ContextMenuStrip.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pTop;
        private System.Windows.Forms.PictureBox pFechar;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados pFiltro;
        private Componentes.EditDefault ds_anexo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pAnexo;
        private System.Windows.Forms.Button bb_load;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Button bb_gravar;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmColar;
    }
}