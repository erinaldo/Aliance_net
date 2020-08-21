namespace Help
{
    partial class TFTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTicket));
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.lklLimpar = new System.Windows.Forms.LinkLabel();
            this.llkAnexo = new System.Windows.Forms.LinkLabel();
            this.bb_gravar = new System.Windows.Forms.Button();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.cbPrioridade = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_evolucao = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.ds_assunto = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.pTop = new Componentes.PanelDados(this.components);
            this.pFechar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bsTicket = new System.Windows.Forms.BindingSource(this.components);
            this.panelDados1.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.Transparent;
            this.panelDados1.Controls.Add(this.lklLimpar);
            this.panelDados1.Controls.Add(this.llkAnexo);
            this.panelDados1.Controls.Add(this.bb_gravar);
            this.panelDados1.Location = new System.Drawing.Point(-2, 314);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(712, 54);
            this.panelDados1.TabIndex = 3;
            // 
            // lklLimpar
            // 
            this.lklLimpar.Location = new System.Drawing.Point(654, 3);
            this.lklLimpar.Name = "lklLimpar";
            this.lklLimpar.Size = new System.Drawing.Size(54, 48);
            this.lklLimpar.TabIndex = 2;
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
            this.llkAnexo.TabIndex = 1;
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
            // pFiltro
            // 
            this.pFiltro.BackColor = System.Drawing.Color.Transparent;
            this.pFiltro.Controls.Add(this.cbPrioridade);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.ds_evolucao);
            this.pFiltro.Controls.Add(this.label4);
            this.pFiltro.Controls.Add(this.ds_assunto);
            this.pFiltro.Controls.Add(this.label6);
            this.pFiltro.Location = new System.Drawing.Point(-2, 40);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(712, 271);
            this.pFiltro.TabIndex = 2;
            // 
            // cbPrioridade
            // 
            this.cbPrioridade.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsTicket, "St_prioridade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbPrioridade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrioridade.FormattingEnabled = true;
            this.cbPrioridade.Location = new System.Drawing.Point(587, 22);
            this.cbPrioridade.Name = "cbPrioridade";
            this.cbPrioridade.NM_Alias = "";
            this.cbPrioridade.NM_Campo = "";
            this.cbPrioridade.NM_Param = "";
            this.cbPrioridade.Size = new System.Drawing.Size(121, 21);
            this.cbPrioridade.ST_Gravar = false;
            this.cbPrioridade.ST_LimparCampo = true;
            this.cbPrioridade.ST_NotNull = false;
            this.cbPrioridade.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(584, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Prioridade";
            // 
            // ds_evolucao
            // 
            this.ds_evolucao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_evolucao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_evolucao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_evolucao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTicket, "Ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_evolucao.Location = new System.Drawing.Point(7, 61);
            this.ds_evolucao.Multiline = true;
            this.ds_evolucao.Name = "ds_evolucao";
            this.ds_evolucao.NM_Alias = "";
            this.ds_evolucao.NM_Campo = "";
            this.ds_evolucao.NM_CampoBusca = "";
            this.ds_evolucao.NM_Param = "";
            this.ds_evolucao.QTD_Zero = 0;
            this.ds_evolucao.Size = new System.Drawing.Size(701, 207);
            this.ds_evolucao.ST_AutoInc = false;
            this.ds_evolucao.ST_DisableAuto = false;
            this.ds_evolucao.ST_Float = false;
            this.ds_evolucao.ST_Gravar = false;
            this.ds_evolucao.ST_Int = false;
            this.ds_evolucao.ST_LimpaCampo = true;
            this.ds_evolucao.ST_NotNull = false;
            this.ds_evolucao.ST_PrimaryKey = false;
            this.ds_evolucao.TabIndex = 3;
            this.ds_evolucao.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Descrição";
            // 
            // ds_assunto
            // 
            this.ds_assunto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_assunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_assunto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_assunto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTicket, "Ds_assunto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_assunto.Location = new System.Drawing.Point(7, 22);
            this.ds_assunto.Name = "ds_assunto";
            this.ds_assunto.NM_Alias = "";
            this.ds_assunto.NM_Campo = "";
            this.ds_assunto.NM_CampoBusca = "";
            this.ds_assunto.NM_Param = "";
            this.ds_assunto.QTD_Zero = 0;
            this.ds_assunto.Size = new System.Drawing.Size(574, 20);
            this.ds_assunto.ST_AutoInc = false;
            this.ds_assunto.ST_DisableAuto = false;
            this.ds_assunto.ST_Float = false;
            this.ds_assunto.ST_Gravar = false;
            this.ds_assunto.ST_Int = false;
            this.ds_assunto.ST_LimpaCampo = true;
            this.ds_assunto.ST_NotNull = false;
            this.ds_assunto.ST_PrimaryKey = false;
            this.ds_assunto.TabIndex = 2;
            this.ds_assunto.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(4, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Assunto";
            // 
            // pTop
            // 
            this.pTop.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pTop.Controls.Add(this.pFechar);
            this.pTop.Controls.Add(this.label1);
            this.pTop.ForeColor = System.Drawing.SystemColors.Control;
            this.pTop.Location = new System.Drawing.Point(-2, 0);
            this.pTop.Name = "pTop";
            this.pTop.NM_ProcDeletar = "";
            this.pTop.NM_ProcGravar = "";
            this.pTop.Size = new System.Drawing.Size(712, 34);
            this.pTop.TabIndex = 1;
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
            this.label1.Size = new System.Drawing.Size(594, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "TICKET HELP DESK";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bsTicket
            // 
            this.bsTicket.DataSource = typeof(CamadaDados.Help.Ticket);
            // 
            // TFTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 368);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.pFiltro);
            this.Controls.Add(this.pTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFTicket";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TFTicket_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFTicket_KeyDown);
            this.panelDados1.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTicket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pTop;
        private System.Windows.Forms.PictureBox pFechar;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados pFiltro;
        private Componentes.EditDefault ds_assunto;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault ds_evolucao;
        private System.Windows.Forms.Label label4;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Button bb_gravar;
        private System.Windows.Forms.LinkLabel llkAnexo;
        private System.Windows.Forms.LinkLabel lklLimpar;
        private System.Windows.Forms.BindingSource bsTicket;
        private Componentes.ComboBoxDefault cbPrioridade;
        private System.Windows.Forms.Label label2;
    }
}