namespace Servicos
{
    partial class TFNumeroOS
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
            this.id_os = new Componentes.EditDefault(this.components);
            this.bb_abrir = new System.Windows.Forms.Button();
            this.bb_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero da OS";
            // 
            // id_os
            // 
            this.id_os.BackColor = System.Drawing.SystemColors.Window;
            this.id_os.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_os.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_os.Location = new System.Drawing.Point(15, 32);
            this.id_os.Name = "id_os";
            this.id_os.NM_Alias = "";
            this.id_os.NM_Campo = "";
            this.id_os.NM_CampoBusca = "";
            this.id_os.NM_Param = "";
            this.id_os.QTD_Zero = 0;
            this.id_os.Size = new System.Drawing.Size(235, 26);
            this.id_os.ST_AutoInc = false;
            this.id_os.ST_DisableAuto = false;
            this.id_os.ST_Float = false;
            this.id_os.ST_Gravar = true;
            this.id_os.ST_Int = true;
            this.id_os.ST_LimpaCampo = true;
            this.id_os.ST_NotNull = false;
            this.id_os.ST_PrimaryKey = false;
            this.id_os.TabIndex = 0;
            this.id_os.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bb_abrir
            // 
            this.bb_abrir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bb_abrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_abrir.Location = new System.Drawing.Point(16, 64);
            this.bb_abrir.Name = "bb_abrir";
            this.bb_abrir.Size = new System.Drawing.Size(107, 23);
            this.bb_abrir.TabIndex = 1;
            this.bb_abrir.Text = "Abrir";
            this.bb_abrir.UseVisualStyleBackColor = true;
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.Location = new System.Drawing.Point(143, 64);
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(107, 23);
            this.bb_cancelar.TabIndex = 2;
            this.bb_cancelar.Text = "Cancelar";
            this.bb_cancelar.UseVisualStyleBackColor = true;
            // 
            // TFNumeroOS
            // 
            this.AcceptButton = this.bb_abrir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bb_cancelar;
            this.ClientSize = new System.Drawing.Size(262, 97);
            this.ControlBox = false;
            this.Controls.Add(this.bb_cancelar);
            this.Controls.Add(this.bb_abrir);
            this.Controls.Add(this.id_os);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFNumeroOS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informar Numero OS";
            this.Load += new System.EventHandler(this.TFNumeroOS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_os;
        private System.Windows.Forms.Button bb_abrir;
        private System.Windows.Forms.Button bb_cancelar;
    }
}