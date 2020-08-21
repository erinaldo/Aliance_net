namespace Proc_Commoditties
{
    partial class TFCaptcha
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_enter = new System.Windows.Forms.Button();
            this.texto = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ptbImagem = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.35146F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.64854F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptbImagem, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(478, 78);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.bb_enter);
            this.panelDados1.Controls.Add(this.texto);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(205, 72);
            this.panelDados1.TabIndex = 0;
            // 
            // bb_enter
            // 
            this.bb_enter.Location = new System.Drawing.Point(8, 39);
            this.bb_enter.Name = "bb_enter";
            this.bb_enter.Size = new System.Drawing.Size(153, 23);
            this.bb_enter.TabIndex = 2;
            this.bb_enter.Text = "Enter";
            this.bb_enter.UseVisualStyleBackColor = true;
            this.bb_enter.Click += new System.EventHandler(this.bb_enter_Click);
            // 
            // texto
            // 
            this.texto.BackColor = System.Drawing.SystemColors.Window;
            this.texto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.texto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.texto.Location = new System.Drawing.Point(8, 17);
            this.texto.Name = "texto";
            this.texto.NM_Alias = "";
            this.texto.NM_Campo = "";
            this.texto.NM_CampoBusca = "";
            this.texto.NM_Param = "";
            this.texto.QTD_Zero = 0;
            this.texto.Size = new System.Drawing.Size(153, 20);
            this.texto.ST_AutoInc = false;
            this.texto.ST_DisableAuto = false;
            this.texto.ST_Float = false;
            this.texto.ST_Gravar = false;
            this.texto.ST_Int = false;
            this.texto.ST_LimpaCampo = true;
            this.texto.ST_NotNull = false;
            this.texto.ST_PrimaryKey = false;
            this.texto.TabIndex = 1;
            this.texto.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Digite o Texto";
            // 
            // ptbImagem
            // 
            this.ptbImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbImagem.Location = new System.Drawing.Point(214, 3);
            this.ptbImagem.Name = "ptbImagem";
            this.ptbImagem.Size = new System.Drawing.Size(261, 72);
            this.ptbImagem.TabIndex = 1;
            this.ptbImagem.TabStop = false;
            // 
            // TFCaptcha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 78);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "TFCaptcha";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digite o Nome da Imagem";
            this.Load += new System.EventHandler(this.TFCaptcha_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCaptcha_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault texto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_enter;
        private System.Windows.Forms.PictureBox ptbImagem;
    }
}