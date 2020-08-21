namespace Faturamento
{
    partial class TFCondDevTotal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCondDevTotal));
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.id_condicional = new Componentes.EditDefault(this.components);
            this.bbConfirma = new System.Windows.Forms.Button();
            this.bbCancela = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.cbEmpresa.Size = new System.Drawing.Size(394, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 157;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 156;
            this.label8.Text = "Empresa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 158;
            this.label1.Text = "Nº Condicional";
            // 
            // id_condicional
            // 
            this.id_condicional.BackColor = System.Drawing.SystemColors.Window;
            this.id_condicional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_condicional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_condicional.Location = new System.Drawing.Point(15, 65);
            this.id_condicional.Name = "id_condicional";
            this.id_condicional.NM_Alias = "";
            this.id_condicional.NM_Campo = "";
            this.id_condicional.NM_CampoBusca = "";
            this.id_condicional.NM_Param = "";
            this.id_condicional.QTD_Zero = 0;
            this.id_condicional.Size = new System.Drawing.Size(100, 20);
            this.id_condicional.ST_AutoInc = false;
            this.id_condicional.ST_DisableAuto = false;
            this.id_condicional.ST_Float = false;
            this.id_condicional.ST_Gravar = true;
            this.id_condicional.ST_Int = true;
            this.id_condicional.ST_LimpaCampo = true;
            this.id_condicional.ST_NotNull = false;
            this.id_condicional.ST_PrimaryKey = false;
            this.id_condicional.TabIndex = 159;
            this.id_condicional.TextOld = null;
            // 
            // bbConfirma
            // 
            this.bbConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbConfirma.ForeColor = System.Drawing.Color.Green;
            this.bbConfirma.Image = ((System.Drawing.Image)(resources.GetObject("bbConfirma.Image")));
            this.bbConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bbConfirma.Location = new System.Drawing.Point(90, 108);
            this.bbConfirma.Name = "bbConfirma";
            this.bbConfirma.Size = new System.Drawing.Size(117, 44);
            this.bbConfirma.TabIndex = 160;
            this.bbConfirma.Text = "Confirmar";
            this.bbConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bbConfirma.UseVisualStyleBackColor = true;
            this.bbConfirma.Click += new System.EventHandler(this.bbConfirma_Click);
            // 
            // bbCancela
            // 
            this.bbCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbCancela.ForeColor = System.Drawing.Color.Red;
            this.bbCancela.Image = ((System.Drawing.Image)(resources.GetObject("bbCancela.Image")));
            this.bbCancela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bbCancela.Location = new System.Drawing.Point(213, 108);
            this.bbCancela.Name = "bbCancela";
            this.bbCancela.Size = new System.Drawing.Size(117, 44);
            this.bbCancela.TabIndex = 161;
            this.bbCancela.Text = "Cancelar";
            this.bbCancela.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bbCancela.UseVisualStyleBackColor = true;
            this.bbCancela.Click += new System.EventHandler(this.bbCancela_Click);
            // 
            // TFCondDevTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 163);
            this.ControlBox = false;
            this.Controls.Add(this.bbCancela);
            this.Controls.Add(this.bbConfirma);
            this.Controls.Add(this.id_condicional);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCondDevTotal";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Condicional Devolver";
            this.Load += new System.EventHandler(this.TFCondDevTotal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_condicional;
        private System.Windows.Forms.Button bbConfirma;
        private System.Windows.Forms.Button bbCancela;
    }
}