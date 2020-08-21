namespace Proc_Commoditties
{
    partial class TFChaveNFCe
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.cbMes = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbSerie = new Componentes.ComboBoxDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.id_cupomini = new Componentes.EditDefault(this.components);
            this.id_cupomfin = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.nr_cupomfin = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.nr_cupomini = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.lbChave = new System.Windows.Forms.ListBox();
            this.bbGerar = new System.Windows.Forms.Button();
            this.lblTotChaves = new System.Windows.Forms.Label();
            this.bbValidar = new System.Windows.Forms.Button();
            this.lblChave = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(15, 25);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(414, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 156;
            // 
            // cbMes
            // 
            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(15, 105);
            this.cbMes.Name = "cbMes";
            this.cbMes.NM_Alias = "";
            this.cbMes.NM_Campo = "";
            this.cbMes.NM_Param = "";
            this.cbMes.Size = new System.Drawing.Size(202, 21);
            this.cbMes.ST_Gravar = false;
            this.cbMes.ST_LimparCampo = true;
            this.cbMes.ST_NotNull = false;
            this.cbMes.TabIndex = 157;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 158;
            this.label2.Text = "Mês";
            // 
            // cbSerie
            // 
            this.cbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerie.FormattingEnabled = true;
            this.cbSerie.Location = new System.Drawing.Point(15, 65);
            this.cbSerie.Name = "cbSerie";
            this.cbSerie.NM_Alias = "";
            this.cbSerie.NM_Campo = "";
            this.cbSerie.NM_Param = "";
            this.cbSerie.Size = new System.Drawing.Size(414, 21);
            this.cbSerie.ST_Gravar = false;
            this.cbSerie.ST_LimparCampo = true;
            this.cbSerie.ST_NotNull = false;
            this.cbSerie.TabIndex = 162;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 161;
            this.label4.Text = "Série";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 163;
            this.label5.Text = "Id. NFC-e Ini.";
            // 
            // id_cupomini
            // 
            this.id_cupomini.BackColor = System.Drawing.SystemColors.Window;
            this.id_cupomini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_cupomini.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_cupomini.Location = new System.Drawing.Point(223, 106);
            this.id_cupomini.MaxLength = 10;
            this.id_cupomini.Name = "id_cupomini";
            this.id_cupomini.NM_Alias = "";
            this.id_cupomini.NM_Campo = "";
            this.id_cupomini.NM_CampoBusca = "";
            this.id_cupomini.NM_Param = "";
            this.id_cupomini.QTD_Zero = 0;
            this.id_cupomini.Size = new System.Drawing.Size(100, 20);
            this.id_cupomini.ST_AutoInc = false;
            this.id_cupomini.ST_DisableAuto = false;
            this.id_cupomini.ST_Float = false;
            this.id_cupomini.ST_Gravar = false;
            this.id_cupomini.ST_Int = true;
            this.id_cupomini.ST_LimpaCampo = true;
            this.id_cupomini.ST_NotNull = false;
            this.id_cupomini.ST_PrimaryKey = false;
            this.id_cupomini.TabIndex = 164;
            this.id_cupomini.TextOld = null;
            // 
            // id_cupomfin
            // 
            this.id_cupomfin.BackColor = System.Drawing.SystemColors.Window;
            this.id_cupomfin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_cupomfin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_cupomfin.Location = new System.Drawing.Point(329, 106);
            this.id_cupomfin.MaxLength = 10;
            this.id_cupomfin.Name = "id_cupomfin";
            this.id_cupomfin.NM_Alias = "";
            this.id_cupomfin.NM_Campo = "";
            this.id_cupomfin.NM_CampoBusca = "";
            this.id_cupomfin.NM_Param = "";
            this.id_cupomfin.QTD_Zero = 0;
            this.id_cupomfin.Size = new System.Drawing.Size(100, 20);
            this.id_cupomfin.ST_AutoInc = false;
            this.id_cupomfin.ST_DisableAuto = false;
            this.id_cupomfin.ST_Float = false;
            this.id_cupomfin.ST_Gravar = false;
            this.id_cupomfin.ST_Int = true;
            this.id_cupomfin.ST_LimpaCampo = true;
            this.id_cupomfin.ST_NotNull = false;
            this.id_cupomfin.ST_PrimaryKey = false;
            this.id_cupomfin.TabIndex = 166;
            this.id_cupomfin.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 165;
            this.label6.Text = "Id. NFC-e Fin.";
            // 
            // nr_cupomfin
            // 
            this.nr_cupomfin.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cupomfin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_cupomfin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cupomfin.Location = new System.Drawing.Point(121, 146);
            this.nr_cupomfin.MaxLength = 10;
            this.nr_cupomfin.Name = "nr_cupomfin";
            this.nr_cupomfin.NM_Alias = "";
            this.nr_cupomfin.NM_Campo = "";
            this.nr_cupomfin.NM_CampoBusca = "";
            this.nr_cupomfin.NM_Param = "";
            this.nr_cupomfin.QTD_Zero = 0;
            this.nr_cupomfin.Size = new System.Drawing.Size(100, 20);
            this.nr_cupomfin.ST_AutoInc = false;
            this.nr_cupomfin.ST_DisableAuto = false;
            this.nr_cupomfin.ST_Float = false;
            this.nr_cupomfin.ST_Gravar = false;
            this.nr_cupomfin.ST_Int = true;
            this.nr_cupomfin.ST_LimpaCampo = true;
            this.nr_cupomfin.ST_NotNull = false;
            this.nr_cupomfin.ST_PrimaryKey = false;
            this.nr_cupomfin.TabIndex = 170;
            this.nr_cupomfin.TextOld = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 169;
            this.label7.Text = "Nº NFC-e Fin.";
            // 
            // nr_cupomini
            // 
            this.nr_cupomini.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cupomini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_cupomini.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cupomini.Location = new System.Drawing.Point(15, 146);
            this.nr_cupomini.MaxLength = 10;
            this.nr_cupomini.Name = "nr_cupomini";
            this.nr_cupomini.NM_Alias = "";
            this.nr_cupomini.NM_Campo = "";
            this.nr_cupomini.NM_CampoBusca = "";
            this.nr_cupomini.NM_Param = "";
            this.nr_cupomini.QTD_Zero = 0;
            this.nr_cupomini.Size = new System.Drawing.Size(100, 20);
            this.nr_cupomini.ST_AutoInc = false;
            this.nr_cupomini.ST_DisableAuto = false;
            this.nr_cupomini.ST_Float = false;
            this.nr_cupomini.ST_Gravar = false;
            this.nr_cupomini.ST_Int = true;
            this.nr_cupomini.ST_LimpaCampo = true;
            this.nr_cupomini.ST_NotNull = false;
            this.nr_cupomini.ST_PrimaryKey = false;
            this.nr_cupomini.TabIndex = 168;
            this.nr_cupomini.TextOld = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 167;
            this.label8.Text = "Nº NFC-e Ini.";
            // 
            // lbChave
            // 
            this.lbChave.FormattingEnabled = true;
            this.lbChave.Location = new System.Drawing.Point(435, 9);
            this.lbChave.Name = "lbChave";
            this.lbChave.Size = new System.Drawing.Size(442, 459);
            this.lbChave.TabIndex = 171;
            // 
            // bbGerar
            // 
            this.bbGerar.Location = new System.Drawing.Point(227, 143);
            this.bbGerar.Name = "bbGerar";
            this.bbGerar.Size = new System.Drawing.Size(96, 23);
            this.bbGerar.TabIndex = 172;
            this.bbGerar.Text = "Gerar Chave";
            this.bbGerar.UseVisualStyleBackColor = true;
            this.bbGerar.Click += new System.EventHandler(this.bbGerar_Click);
            // 
            // lblTotChaves
            // 
            this.lblTotChaves.AutoSize = true;
            this.lblTotChaves.Location = new System.Drawing.Point(432, 471);
            this.lblTotChaves.Name = "lblTotChaves";
            this.lblTotChaves.Size = new System.Drawing.Size(76, 13);
            this.lblTotChaves.TabIndex = 173;
            this.lblTotChaves.Text = "Total Chaves: ";
            // 
            // bbValidar
            // 
            this.bbValidar.Location = new System.Drawing.Point(333, 143);
            this.bbValidar.Name = "bbValidar";
            this.bbValidar.Size = new System.Drawing.Size(96, 23);
            this.bbValidar.TabIndex = 174;
            this.bbValidar.Text = "Validar Chaves";
            this.bbValidar.UseVisualStyleBackColor = true;
            this.bbValidar.Click += new System.EventHandler(this.bbValidar_Click);
            // 
            // lblChave
            // 
            this.lblChave.AutoSize = true;
            this.lblChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChave.ForeColor = System.Drawing.Color.Green;
            this.lblChave.Location = new System.Drawing.Point(12, 270);
            this.lblChave.Name = "lblChave";
            this.lblChave.Size = new System.Drawing.Size(0, 20);
            this.lblChave.TabIndex = 175;
            // 
            // TFChaveNFCe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 484);
            this.Controls.Add(this.lblChave);
            this.Controls.Add(this.bbValidar);
            this.Controls.Add(this.lblTotChaves);
            this.Controls.Add(this.bbGerar);
            this.Controls.Add(this.lbChave);
            this.Controls.Add(this.nr_cupomfin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nr_cupomini);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.id_cupomfin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.id_cupomini);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbSerie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbMes);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFChaveNFCe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chave Acesso NFC-e";
            this.Load += new System.EventHandler(this.TFChaveNFCe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault cbEmpresa;
        private Componentes.ComboBoxDefault cbMes;
        private System.Windows.Forms.Label label2;
        private Componentes.ComboBoxDefault cbSerie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault id_cupomini;
        private Componentes.EditDefault id_cupomfin;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault nr_cupomfin;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault nr_cupomini;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lbChave;
        private System.Windows.Forms.Button bbGerar;
        private System.Windows.Forms.Label lblTotChaves;
        private System.Windows.Forms.Button bbValidar;
        private System.Windows.Forms.Label lblChave;
    }
}