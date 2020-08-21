namespace Estoque.Cadastros
{
    partial class TFCodBarra
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
            this.pDados = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cd_codbarra = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_codbarra);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 0);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(360, 70);
            this.pDados.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo Barra";
            // 
            // cd_codbarra
            // 
            this.cd_codbarra.BackColor = System.Drawing.SystemColors.Window;
            this.cd_codbarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_codbarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_codbarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_codbarra.Location = new System.Drawing.Point(10, 34);
            this.cd_codbarra.Name = "cd_codbarra";
            this.cd_codbarra.NM_Alias = "";
            this.cd_codbarra.NM_Campo = "";
            this.cd_codbarra.NM_CampoBusca = "";
            this.cd_codbarra.NM_Param = "";
            this.cd_codbarra.QTD_Zero = 0;
            this.cd_codbarra.Size = new System.Drawing.Size(343, 29);
            this.cd_codbarra.ST_AutoInc = false;
            this.cd_codbarra.ST_DisableAuto = false;
            this.cd_codbarra.ST_Float = false;
            this.cd_codbarra.ST_Gravar = false;
            this.cd_codbarra.ST_Int = false;
            this.cd_codbarra.ST_LimpaCampo = true;
            this.cd_codbarra.ST_NotNull = false;
            this.cd_codbarra.ST_PrimaryKey = false;
            this.cd_codbarra.TabIndex = 0;
            this.cd_codbarra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_codbarra_KeyDown);
            // 
            // TFCodBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 70);
            this.Controls.Add(this.pDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCodBarra";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Codigo Barra";
            this.Load += new System.EventHandler(this.TFCodBarra_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_codbarra;
    }
}