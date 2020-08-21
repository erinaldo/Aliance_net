namespace Help
{
    partial class TFEvoluirTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFEvoluirTicket));
            this.pTop = new Componentes.PanelDados(this.components);
            this.pFechar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.lklLimpar = new System.Windows.Forms.LinkLabel();
            this.llkAnexo = new System.Windows.Forms.LinkLabel();
            this.bb_gravar = new System.Windows.Forms.Button();
            this.pTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).BeginInit();
            this.pFiltro.SuspendLayout();
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
            this.pTop.Size = new System.Drawing.Size(712, 34);
            this.pTop.TabIndex = 2;
            // 
            // pFechar
            // 
            this.pFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pFechar.Image = ((System.Drawing.Image)(resources.GetObject("pFechar.Image")));
            this.pFechar.Location = new System.Drawing.Point(675, 3);
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
            this.label1.Size = new System.Drawing.Size(668, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "HISTÓRICO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pFiltro
            // 
            this.pFiltro.BackColor = System.Drawing.Color.Transparent;
            this.pFiltro.Controls.Add(this.ds_historico);
            this.pFiltro.Controls.Add(this.label4);
            this.pFiltro.Location = new System.Drawing.Point(0, 41);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(712, 154);
            this.pFiltro.TabIndex = 3;
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.Location = new System.Drawing.Point(7, 20);
            this.ds_historico.MaxLength = 2048;
            this.ds_historico.Multiline = true;
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "";
            this.ds_historico.NM_CampoBusca = "";
            this.ds_historico.NM_Param = "";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.Size = new System.Drawing.Size(701, 129);
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = false;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = false;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TabIndex = 3;
            this.ds_historico.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Histórico";
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.Transparent;
            this.panelDados1.Controls.Add(this.lklLimpar);
            this.panelDados1.Controls.Add(this.llkAnexo);
            this.panelDados1.Controls.Add(this.bb_gravar);
            this.panelDados1.Location = new System.Drawing.Point(0, 201);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(712, 54);
            this.panelDados1.TabIndex = 4;
            // 
            // lklLimpar
            // 
            this.lklLimpar.Location = new System.Drawing.Point(654, 3);
            this.lklLimpar.Name = "lklLimpar";
            this.lklLimpar.Size = new System.Drawing.Size(54, 48);
            this.lklLimpar.TabIndex = 4;
            this.lklLimpar.TabStop = true;
            this.lklLimpar.Text = "Limpar Lista";
            this.lklLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lklLimpar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklLimpar_LinkClicked);
            // 
            // llkAnexo
            // 
            this.llkAnexo.Location = new System.Drawing.Point(569, 3);
            this.llkAnexo.Name = "llkAnexo";
            this.llkAnexo.Size = new System.Drawing.Size(79, 48);
            this.llkAnexo.TabIndex = 3;
            this.llkAnexo.TabStop = true;
            this.llkAnexo.Text = "Anexar Imagem";
            this.llkAnexo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llkAnexo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llkAnexo_LinkClicked);
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
            // TFEvoluirTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 258);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.pFiltro);
            this.Controls.Add(this.pTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFEvoluirTicket";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TFEvoluirTicket_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFEvoluirTicket_KeyDown);
            this.pTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).EndInit();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pTop;
        private System.Windows.Forms.PictureBox pFechar;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados pFiltro;
        private Componentes.EditDefault ds_historico;
        private System.Windows.Forms.Label label4;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Button bb_gravar;
        private System.Windows.Forms.LinkLabel lklLimpar;
        private System.Windows.Forms.LinkLabel llkAnexo;
    }
}