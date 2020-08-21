namespace FormRelPadrao
{
    partial class TFGerenciadorImpressao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFGerenciadorImpressao));
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pBotoes = new System.Windows.Forms.Panel();
            this.bbExportarPDF = new System.Windows.Forms.Button();
            this.BB_Imprimir = new System.Windows.Forms.Button();
            this.BB_Visualizar = new System.Windows.Forms.Button();
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bb_enviaremail = new System.Windows.Forms.Button();
            this.ds_email = new Componentes.EditDefault(this.components);
            this.ds_mensagem = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.clbContatos = new Componentes.CheckedListBoxDefault(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.lblMensagem = new System.Windows.Forms.Label();
            this.st_danfenfcedetalhada = new Componentes.CheckBoxDefault(this.components);
            this.st_viaestabelecimento = new Componentes.CheckBoxDefault(this.components);
            this.tlpCentral.SuspendLayout();
            this.pBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.Controls.Add(this.pBotoes, 0, 1);
            this.tlpCentral.Controls.Add(this.lblMensagem, 0, 0);
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pBotoes
            // 
            this.pBotoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBotoes.Controls.Add(this.st_viaestabelecimento);
            this.pBotoes.Controls.Add(this.st_danfenfcedetalhada);
            this.pBotoes.Controls.Add(this.bbExportarPDF);
            this.pBotoes.Controls.Add(this.BB_Imprimir);
            this.pBotoes.Controls.Add(this.BB_Visualizar);
            this.pBotoes.Controls.Add(this.nm_clifor);
            this.pBotoes.Controls.Add(this.label3);
            this.pBotoes.Controls.Add(this.label1);
            this.pBotoes.Controls.Add(this.bb_enviaremail);
            this.pBotoes.Controls.Add(this.ds_email);
            this.pBotoes.Controls.Add(this.ds_mensagem);
            this.pBotoes.Controls.Add(this.label2);
            this.pBotoes.Controls.Add(this.clbContatos);
            this.pBotoes.Controls.Add(this.bb_clifor);
            this.pBotoes.Controls.Add(this.cd_clifor);
            resources.ApplyResources(this.pBotoes, "pBotoes");
            this.pBotoes.Name = "pBotoes";
            // 
            // bbExportarPDF
            // 
            resources.ApplyResources(this.bbExportarPDF, "bbExportarPDF");
            this.bbExportarPDF.ForeColor = System.Drawing.Color.Green;
            this.bbExportarPDF.Name = "bbExportarPDF";
            this.bbExportarPDF.UseVisualStyleBackColor = true;
            this.bbExportarPDF.Click += new System.EventHandler(this.bbExportarPDF_Click);
            // 
            // BB_Imprimir
            // 
            resources.ApplyResources(this.BB_Imprimir, "BB_Imprimir");
            this.BB_Imprimir.ForeColor = System.Drawing.Color.Green;
            this.BB_Imprimir.Name = "BB_Imprimir";
            this.BB_Imprimir.UseVisualStyleBackColor = true;
            this.BB_Imprimir.Click += new System.EventHandler(this.BB_Imprimir_Click);
            // 
            // BB_Visualizar
            // 
            resources.ApplyResources(this.BB_Visualizar, "BB_Visualizar");
            this.BB_Visualizar.ForeColor = System.Drawing.Color.Green;
            this.BB_Visualizar.Name = "BB_Visualizar";
            this.BB_Visualizar.UseVisualStyleBackColor = true;
            this.BB_Visualizar.Click += new System.EventHandler(this.BB_Visualizar_Click);
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.nm_clifor, "nm_clifor");
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_NM_CLIFOR";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TextOld = null;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // bb_enviaremail
            // 
            this.bb_enviaremail.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_enviaremail, "bb_enviaremail");
            this.bb_enviaremail.ForeColor = System.Drawing.Color.Green;
            this.bb_enviaremail.Name = "bb_enviaremail";
            this.bb_enviaremail.UseVisualStyleBackColor = false;
            this.bb_enviaremail.Click += new System.EventHandler(this.bb_enviaremail_Click);
            // 
            // ds_email
            // 
            this.ds_email.BackColor = System.Drawing.SystemColors.Window;
            this.ds_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_email.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            resources.ApplyResources(this.ds_email, "ds_email");
            this.ds_email.Name = "ds_email";
            this.ds_email.QTD_Zero = 0;
            this.ds_email.ST_AutoInc = false;
            this.ds_email.ST_DisableAuto = false;
            this.ds_email.ST_Float = false;
            this.ds_email.ST_Gravar = true;
            this.ds_email.ST_Int = false;
            this.ds_email.ST_LimpaCampo = true;
            this.ds_email.ST_NotNull = false;
            this.ds_email.ST_PrimaryKey = false;
            this.ds_email.TextOld = null;
            // 
            // ds_mensagem
            // 
            this.ds_mensagem.AcceptsReturn = true;
            this.ds_mensagem.AcceptsTab = true;
            this.ds_mensagem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_mensagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_mensagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.ds_mensagem, "ds_mensagem");
            this.ds_mensagem.Name = "ds_mensagem";
            this.ds_mensagem.QTD_Zero = 0;
            this.ds_mensagem.ST_AutoInc = false;
            this.ds_mensagem.ST_DisableAuto = false;
            this.ds_mensagem.ST_Float = false;
            this.ds_mensagem.ST_Gravar = true;
            this.ds_mensagem.ST_Int = false;
            this.ds_mensagem.ST_LimpaCampo = true;
            this.ds_mensagem.ST_NotNull = false;
            this.ds_mensagem.ST_PrimaryKey = false;
            this.ds_mensagem.TextOld = null;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // clbContatos
            // 
            this.clbContatos.CheckOnClick = true;
            this.clbContatos.FormattingEnabled = true;
            resources.ApplyResources(this.clbContatos, "clbContatos");
            this.clbContatos.Name = "clbContatos";
            this.clbContatos.ST_Gravar = false;
            this.clbContatos.Tabela = null;
            // 
            // bb_clifor
            // 
            this.bb_clifor.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_clifor, "bb_clifor");
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.UseVisualStyleBackColor = false;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cd_clifor, "cd_clifor");
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Campo = "cd_Clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_CLIFOR";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = false;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TextOld = null;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // lblMensagem
            // 
            this.lblMensagem.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.lblMensagem, "lblMensagem");
            this.lblMensagem.ForeColor = System.Drawing.Color.White;
            this.lblMensagem.Name = "lblMensagem";
            // 
            // st_danfenfcedetalhada
            // 
            resources.ApplyResources(this.st_danfenfcedetalhada, "st_danfenfcedetalhada");
            this.st_danfenfcedetalhada.Name = "st_danfenfcedetalhada";
            this.st_danfenfcedetalhada.ST_Gravar = false;
            this.st_danfenfcedetalhada.ST_LimparCampo = true;
            this.st_danfenfcedetalhada.ST_NotNull = false;
            this.st_danfenfcedetalhada.UseVisualStyleBackColor = true;
            // 
            // st_viaestabelecimento
            // 
            resources.ApplyResources(this.st_viaestabelecimento, "st_viaestabelecimento");
            this.st_viaestabelecimento.Name = "st_viaestabelecimento";
            this.st_viaestabelecimento.ST_Gravar = false;
            this.st_viaestabelecimento.ST_LimparCampo = true;
            this.st_viaestabelecimento.ST_NotNull = false;
            this.st_viaestabelecimento.UseVisualStyleBackColor = true;
            // 
            // TFGerenciadorImpressao
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFGerenciadorImpressao";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFGerenciadorImpressao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFGerenciadorImpressao_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFGerenciadorImpressao_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.pBotoes.ResumeLayout(false);
            this.pBotoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private System.Windows.Forms.Panel pBotoes;
        private System.Windows.Forms.Button BB_Visualizar;
        private System.Windows.Forms.Button BB_Imprimir;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.CheckedListBoxDefault clbContatos;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault ds_email;
        private Componentes.EditDefault ds_mensagem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_enviaremail;
        private Componentes.EditDefault nm_clifor;
        private System.Windows.Forms.Button bbExportarPDF;
        private Componentes.CheckBoxDefault st_viaestabelecimento;
        private Componentes.CheckBoxDefault st_danfenfcedetalhada;
    }
}