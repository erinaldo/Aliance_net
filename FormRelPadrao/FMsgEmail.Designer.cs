namespace FormRelPadrao
{
    partial class TFMsgEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFMsgEmail));
            this.tlpEmail = new System.Windows.Forms.TableLayoutPanel();
            this.pEnviar = new Componentes.PanelDados(this.components);
            this.lbAnexos = new System.Windows.Forms.ListBox();
            this.bbAnexos = new System.Windows.Forms.Button();
            this.bb_enviar = new System.Windows.Forms.Button();
            this.bb_BuscarEndEmail = new System.Windows.Forms.Button();
            this.ds_assunto = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_destinatario = new Componentes.EditDefault(this.components);
            this.pMsg = new Componentes.PanelDados(this.components);
            this.ds_mensagem = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bb_negrito = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bb_italico = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bb_sublinhado = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbxTamanho = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.bb_cor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cbxFonteFamily = new System.Windows.Forms.ToolStripComboBox();
            this.tlpEmail.SuspendLayout();
            this.pEnviar.SuspendLayout();
            this.pMsg.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpEmail
            // 
            this.tlpEmail.ColumnCount = 1;
            this.tlpEmail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEmail.Controls.Add(this.pEnviar, 0, 0);
            this.tlpEmail.Controls.Add(this.pMsg, 0, 1);
            this.tlpEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEmail.Location = new System.Drawing.Point(0, 0);
            this.tlpEmail.Name = "tlpEmail";
            this.tlpEmail.RowCount = 2;
            this.tlpEmail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.5972F));
            this.tlpEmail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.4028F));
            this.tlpEmail.Size = new System.Drawing.Size(901, 571);
            this.tlpEmail.TabIndex = 0;
            // 
            // pEnviar
            // 
            this.pEnviar.Controls.Add(this.lbAnexos);
            this.pEnviar.Controls.Add(this.bbAnexos);
            this.pEnviar.Controls.Add(this.bb_enviar);
            this.pEnviar.Controls.Add(this.bb_BuscarEndEmail);
            this.pEnviar.Controls.Add(this.ds_assunto);
            this.pEnviar.Controls.Add(this.label2);
            this.pEnviar.Controls.Add(this.ds_destinatario);
            this.pEnviar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pEnviar.Location = new System.Drawing.Point(3, 3);
            this.pEnviar.Name = "pEnviar";
            this.pEnviar.NM_ProcDeletar = "";
            this.pEnviar.NM_ProcGravar = "";
            this.pEnviar.Size = new System.Drawing.Size(895, 163);
            this.pEnviar.TabIndex = 0;
            // 
            // lbAnexos
            // 
            this.lbAnexos.ColumnWidth = 3;
            this.lbAnexos.FormattingEnabled = true;
            this.lbAnexos.HorizontalScrollbar = true;
            this.lbAnexos.Location = new System.Drawing.Point(187, 71);
            this.lbAnexos.Name = "lbAnexos";
            this.lbAnexos.Size = new System.Drawing.Size(686, 82);
            this.lbAnexos.TabIndex = 4;
            this.lbAnexos.DoubleClick += new System.EventHandler(this.lbAnexos_DoubleClick);
            // 
            // bbAnexos
            // 
            this.bbAnexos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbAnexos.Location = new System.Drawing.Point(100, 71);
            this.bbAnexos.Name = "bbAnexos";
            this.bbAnexos.Size = new System.Drawing.Size(75, 23);
            this.bbAnexos.TabIndex = 3;
            this.bbAnexos.Text = "Anexos:";
            this.bbAnexos.UseVisualStyleBackColor = true;
            this.bbAnexos.Click += new System.EventHandler(this.bbAnexos_Click);
            // 
            // bb_enviar
            // 
            this.bb_enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_enviar.Image = ((System.Drawing.Image)(resources.GetObject("bb_enviar.Image")));
            this.bb_enviar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bb_enviar.Location = new System.Drawing.Point(7, 17);
            this.bb_enviar.Name = "bb_enviar";
            this.bb_enviar.Size = new System.Drawing.Size(87, 77);
            this.bb_enviar.TabIndex = 5;
            this.bb_enviar.Text = "Enviar";
            this.bb_enviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bb_enviar.UseVisualStyleBackColor = true;
            this.bb_enviar.Click += new System.EventHandler(this.bb_enviar_Click);
            // 
            // bb_BuscarEndEmail
            // 
            this.bb_BuscarEndEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_BuscarEndEmail.Location = new System.Drawing.Point(100, 17);
            this.bb_BuscarEndEmail.Name = "bb_BuscarEndEmail";
            this.bb_BuscarEndEmail.Size = new System.Drawing.Size(75, 23);
            this.bb_BuscarEndEmail.TabIndex = 0;
            this.bb_BuscarEndEmail.Text = "Para:";
            this.bb_BuscarEndEmail.UseVisualStyleBackColor = true;
            this.bb_BuscarEndEmail.Click += new System.EventHandler(this.bb_BuscarEndEmail_Click);
            // 
            // ds_assunto
            // 
            this.ds_assunto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_assunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_assunto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_assunto.Location = new System.Drawing.Point(187, 48);
            this.ds_assunto.Name = "ds_assunto";
            this.ds_assunto.NM_Alias = "";
            this.ds_assunto.NM_Campo = "";
            this.ds_assunto.NM_CampoBusca = "";
            this.ds_assunto.NM_Param = "";
            this.ds_assunto.QTD_Zero = 0;
            this.ds_assunto.Size = new System.Drawing.Size(686, 20);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Assunto:";
            // 
            // ds_destinatario
            // 
            this.ds_destinatario.BackColor = System.Drawing.SystemColors.Window;
            this.ds_destinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_destinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_destinatario.Location = new System.Drawing.Point(187, 19);
            this.ds_destinatario.Name = "ds_destinatario";
            this.ds_destinatario.NM_Alias = "";
            this.ds_destinatario.NM_Campo = "a.email";
            this.ds_destinatario.NM_CampoBusca = "a.email";
            this.ds_destinatario.NM_Param = "@P_A.EMAIL";
            this.ds_destinatario.QTD_Zero = 0;
            this.ds_destinatario.Size = new System.Drawing.Size(686, 20);
            this.ds_destinatario.ST_AutoInc = false;
            this.ds_destinatario.ST_DisableAuto = false;
            this.ds_destinatario.ST_Float = false;
            this.ds_destinatario.ST_Gravar = false;
            this.ds_destinatario.ST_Int = false;
            this.ds_destinatario.ST_LimpaCampo = true;
            this.ds_destinatario.ST_NotNull = false;
            this.ds_destinatario.ST_PrimaryKey = false;
            this.ds_destinatario.TabIndex = 1;
            this.ds_destinatario.TextOld = null;
            // 
            // pMsg
            // 
            this.pMsg.Controls.Add(this.ds_mensagem);
            this.pMsg.Controls.Add(this.toolStrip1);
            this.pMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMsg.Location = new System.Drawing.Point(3, 172);
            this.pMsg.Name = "pMsg";
            this.pMsg.NM_ProcDeletar = "";
            this.pMsg.NM_ProcGravar = "";
            this.pMsg.Size = new System.Drawing.Size(895, 396);
            this.pMsg.TabIndex = 1;
            // 
            // ds_mensagem
            // 
            this.ds_mensagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ds_mensagem.Location = new System.Drawing.Point(0, 25);
            this.ds_mensagem.Name = "ds_mensagem";
            this.ds_mensagem.Size = new System.Drawing.Size(895, 371);
            this.ds_mensagem.TabIndex = 28;
            this.ds_mensagem.Text = "";
            this.ds_mensagem.SelectionChanged += new System.EventHandler(this.ds_mensagem_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_negrito,
            this.toolStripSeparator1,
            this.bb_italico,
            this.toolStripSeparator2,
            this.bb_sublinhado,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.cbxTamanho,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.bb_cor,
            this.toolStripSeparator5,
            this.toolStripLabel3,
            this.cbxFonteFamily});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(895, 25);
            this.toolStrip1.TabIndex = 27;
            // 
            // bb_negrito
            // 
            this.bb_negrito.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_negrito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_negrito.Name = "bb_negrito";
            this.bb_negrito.Size = new System.Drawing.Size(23, 22);
            this.bb_negrito.Text = "N";
            this.bb_negrito.ToolTipText = "Negrito";
            this.bb_negrito.Click += new System.EventHandler(this.bb_negrito_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bb_italico
            // 
            this.bb_italico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_italico.Font = new System.Drawing.Font("Calibri", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bb_italico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_italico.Name = "bb_italico";
            this.bb_italico.Size = new System.Drawing.Size(23, 22);
            this.bb_italico.Text = "I";
            this.bb_italico.ToolTipText = "Itálico";
            this.bb_italico.Click += new System.EventHandler(this.bb_italico_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bb_sublinhado
            // 
            this.bb_sublinhado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_sublinhado.Font = new System.Drawing.Font("Calibri", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.bb_sublinhado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_sublinhado.Name = "bb_sublinhado";
            this.bb_sublinhado.Size = new System.Drawing.Size(23, 22);
            this.bb_sublinhado.Text = "S";
            this.bb_sublinhado.ToolTipText = "Sublinhado";
            this.bb_sublinhado.Click += new System.EventHandler(this.bb_sublinhado_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "Tamanho:";
            // 
            // cbxTamanho
            // 
            this.cbxTamanho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTamanho.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.cbxTamanho.Name = "cbxTamanho";
            this.cbxTamanho.Size = new System.Drawing.Size(75, 25);
            this.cbxTamanho.ToolTipText = "Tamanho Fonte";
            this.cbxTamanho.SelectedIndexChanged += new System.EventHandler(this.cbxTamanho_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(26, 22);
            this.toolStripLabel2.Text = "Cor:";
            // 
            // bb_cor
            // 
            this.bb_cor.BackColor = System.Drawing.Color.Black;
            this.bb_cor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.bb_cor.ImageTransparentColor = System.Drawing.Color.Black;
            this.bb_cor.Name = "bb_cor";
            this.bb_cor.Size = new System.Drawing.Size(23, 22);
            this.bb_cor.ToolTipText = "Cor";
            this.bb_cor.Click += new System.EventHandler(this.bb_cor_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel3.Text = "Fonte:";
            // 
            // cbxFonteFamily
            // 
            this.cbxFonteFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFonteFamily.Name = "cbxFonteFamily";
            this.cbxFonteFamily.Size = new System.Drawing.Size(121, 25);
            this.cbxFonteFamily.ToolTipText = "Fonte";
            this.cbxFonteFamily.SelectedIndexChanged += new System.EventHandler(this.cbxFonteFamily_SelectedIndexChanged);
            // 
            // TFMsgEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 571);
            this.Controls.Add(this.tlpEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFMsgEmail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensagem";
            this.Load += new System.EventHandler(this.TFMsgEmail_Load);
            this.tlpEmail.ResumeLayout(false);
            this.pEnviar.ResumeLayout(false);
            this.pEnviar.PerformLayout();
            this.pMsg.ResumeLayout(false);
            this.pMsg.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpEmail;
        private Componentes.PanelDados pEnviar;
        private Componentes.EditDefault ds_destinatario;
        private Componentes.PanelDados pMsg;
        private Componentes.EditDefault ds_assunto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_BuscarEndEmail;
        private System.Windows.Forms.Button bb_enviar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bb_negrito;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bb_italico;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bb_sublinhado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox cbxTamanho;
        private System.Windows.Forms.RichTextBox ds_mensagem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton bb_cor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripComboBox cbxFonteFamily;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.Button bbAnexos;
        private System.Windows.Forms.ListBox lbAnexos;
    }
}