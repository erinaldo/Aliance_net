namespace Locacao
{
    partial class TFHistorico
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
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.ds_mensagem = new Componentes.EditDefault(this.components);
            this.lbCancela = new System.Windows.Forms.Label();
            this.lblConfirma = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.ds_mensagem);
            this.panelDados1.Controls.Add(this.lbCancela);
            this.panelDados1.Controls.Add(this.lblConfirma);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 0);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(798, 399);
            this.panelDados1.TabIndex = 0;
            // 
            // ds_mensagem
            // 
            this.ds_mensagem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_mensagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_mensagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_mensagem.Location = new System.Drawing.Point(3, 34);
            this.ds_mensagem.Multiline = true;
            this.ds_mensagem.Name = "ds_mensagem";
            this.ds_mensagem.NM_Alias = "";
            this.ds_mensagem.NM_Campo = "";
            this.ds_mensagem.NM_CampoBusca = "";
            this.ds_mensagem.NM_Param = "";
            this.ds_mensagem.QTD_Zero = 0;
            this.ds_mensagem.Size = new System.Drawing.Size(790, 325);
            this.ds_mensagem.ST_AutoInc = false;
            this.ds_mensagem.ST_DisableAuto = false;
            this.ds_mensagem.ST_Float = false;
            this.ds_mensagem.ST_Gravar = false;
            this.ds_mensagem.ST_Int = false;
            this.ds_mensagem.ST_LimpaCampo = true;
            this.ds_mensagem.ST_NotNull = false;
            this.ds_mensagem.ST_PrimaryKey = false;
            this.ds_mensagem.TabIndex = 0;
            this.ds_mensagem.TextOld = null;
            // 
            // lbCancela
            // 
            this.lbCancela.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCancela.ForeColor = System.Drawing.Color.Red;
            this.lbCancela.Location = new System.Drawing.Point(435, 371);
            this.lbCancela.Name = "lbCancela";
            this.lbCancela.Size = new System.Drawing.Size(180, 19);
            this.lbCancela.TabIndex = 135;
            this.lbCancela.Text = "<ESC> CANCELAR";
            this.lbCancela.Click += new System.EventHandler(this.lbCancela_Click);
            this.lbCancela.MouseEnter += new System.EventHandler(this.lbCancela_MouseEnter);
            this.lbCancela.MouseLeave += new System.EventHandler(this.lbCancela_MouseLeave);
            // 
            // lblConfirma
            // 
            this.lblConfirma.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirma.Location = new System.Drawing.Point(195, 371);
            this.lblConfirma.Name = "lblConfirma";
            this.lblConfirma.Size = new System.Drawing.Size(193, 19);
            this.lblConfirma.TabIndex = 134;
            this.lblConfirma.Text = "<ENTER> Confirmar ";
            this.lblConfirma.Click += new System.EventHandler(this.lblConfirma_Click);
            this.lblConfirma.MouseEnter += new System.EventHandler(this.lblConfirma_MouseEnter);
            this.lblConfirma.MouseLeave += new System.EventHandler(this.lblConfirma_MouseLeave);
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 19);
            this.label1.TabIndex = 136;
            this.label1.Text = "Histórico";
            // 
            // TFHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 399);
            this.Controls.Add(this.panelDados1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFHistorico";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserir MSG Evolução";
            this.Load += new System.EventHandler(this.TFHistorico_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFHistorico_KeyDown);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault ds_mensagem;
        private System.Windows.Forms.Label lbCancela;
        private System.Windows.Forms.Label lblConfirma;
        private System.Windows.Forms.Label label1;
    }
}