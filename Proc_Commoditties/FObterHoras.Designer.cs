namespace Proc_Commoditties
{
    partial class FObterHoras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FObterHoras));
            this.label1 = new System.Windows.Forms.Label();
            this.BB_Gravar = new System.Windows.Forms.Button();
            this.BB_Cancelar = new System.Windows.Forms.Button();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.EDT_Tempo = new Componentes.EditMask(this.components);
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tempo pelo serviço:";
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.Location = new System.Drawing.Point(39, 69);
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(117, 47);
            this.BB_Gravar.TabIndex = 2;
            this.BB_Gravar.Text = "Gravar (ENTER)";
            this.BB_Gravar.UseVisualStyleBackColor = true;
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            this.BB_Gravar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BB_Gravar_KeyDown);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.Location = new System.Drawing.Point(162, 69);
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(117, 47);
            this.BB_Cancelar.TabIndex = 3;
            this.BB_Cancelar.Text = "Cancelar (ESC)";
            this.BB_Cancelar.UseVisualStyleBackColor = true;
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            this.BB_Cancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BB_Cancelar_KeyDown);
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.EDT_Tempo);
            this.panelDados1.Controls.Add(this.BB_Gravar);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.BB_Cancelar);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 0);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(320, 127);
            this.panelDados1.TabIndex = 4;
            // 
            // EDT_Tempo
            // 
            this.EDT_Tempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDT_Tempo.Location = new System.Drawing.Point(106, 25);
            this.EDT_Tempo.Mask = "00:00:00";
            this.EDT_Tempo.Name = "EDT_Tempo";
            this.EDT_Tempo.NM_Alias = "";
            this.EDT_Tempo.NM_Campo = "Tempo";
            this.EDT_Tempo.NM_CampoBusca = "Tempo";
            this.EDT_Tempo.NM_Param = "@P_TEMPO";
            this.EDT_Tempo.Size = new System.Drawing.Size(113, 38);
            this.EDT_Tempo.ST_Gravar = false;
            this.EDT_Tempo.ST_LimpaCampo = true;
            this.EDT_Tempo.ST_NotNull = true;
            this.EDT_Tempo.ST_PrimaryKey = false;
            this.EDT_Tempo.TabIndex = 4;
            this.EDT_Tempo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EDT_Tempo_KeyDown);
            // 
            // FObterHoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 127);
            this.Controls.Add(this.panelDados1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FObterHoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Informe o tempo";
            this.Load += new System.EventHandler(this.FObterHoras_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FObterHoras_KeyDown);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BB_Gravar;
        private System.Windows.Forms.Button BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditMask EDT_Tempo;
    }
}