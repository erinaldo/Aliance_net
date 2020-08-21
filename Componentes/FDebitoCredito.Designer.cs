namespace Componentes
{
    partial class TFDebitoCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDebitoCredito));
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dsmaquinaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsMaquina = new System.Windows.Forms.BindingSource(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.lblCredito = new System.Windows.Forms.Label();
            this.lblDebito = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsMaquina)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Add";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.St_processar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dsmaquinaDataGridViewTextBoxColumn
            // 
            this.dsmaquinaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmaquinaDataGridViewTextBoxColumn.DataPropertyName = "Ds_maquina";
            this.dsmaquinaDataGridViewTextBoxColumn.HeaderText = "Máquina";
            this.dsmaquinaDataGridViewTextBoxColumn.Name = "dsmaquinaDataGridViewTextBoxColumn";
            this.dsmaquinaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsMaquina
            // 
            this.bsMaquina.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadMaquinaCartao);
            // 
            // panelDados1
            // 
            this.panelDados1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDados1.BackgroundImage")));
            this.panelDados1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.lblCancelar);
            this.panelDados1.Controls.Add(this.lblCredito);
            this.panelDados1.Controls.Add(this.lblDebito);
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(196, 214);
            this.panelDados1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(27, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "F3 - ROTATIVO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblCancelar
            // 
            this.lblCancelar.AutoSize = true;
            this.lblCancelar.BackColor = System.Drawing.Color.Transparent;
            this.lblCancelar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelar.ForeColor = System.Drawing.Color.White;
            this.lblCancelar.Location = new System.Drawing.Point(24, 188);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(149, 19);
            this.lblCancelar.TabIndex = 2;
            this.lblCancelar.Text = "<ESC> CANCELAR";
            this.lblCancelar.Click += new System.EventHandler(this.lblCancelar_Click);
            this.lblCancelar.MouseEnter += new System.EventHandler(this.lblCancelar_MouseEnter);
            this.lblCancelar.MouseLeave += new System.EventHandler(this.lblCancelar_MouseLeave);
            // 
            // lblCredito
            // 
            this.lblCredito.BackColor = System.Drawing.Color.Transparent;
            this.lblCredito.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredito.ForeColor = System.Drawing.Color.Green;
            this.lblCredito.Location = new System.Drawing.Point(30, 88);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(142, 32);
            this.lblCredito.TabIndex = 1;
            this.lblCredito.Text = "F2 - CRÉDITO";
            this.lblCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCredito.Click += new System.EventHandler(this.lblCredito_Click);
            this.lblCredito.MouseEnter += new System.EventHandler(this.lblCredito_MouseEnter);
            this.lblCredito.MouseLeave += new System.EventHandler(this.lblCredito_MouseLeave);
            // 
            // lblDebito
            // 
            this.lblDebito.BackColor = System.Drawing.Color.Transparent;
            this.lblDebito.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebito.ForeColor = System.Drawing.Color.Green;
            this.lblDebito.Location = new System.Drawing.Point(31, 31);
            this.lblDebito.Name = "lblDebito";
            this.lblDebito.Size = new System.Drawing.Size(142, 32);
            this.lblDebito.TabIndex = 0;
            this.lblDebito.Text = "F1 - DÉBITO";
            this.lblDebito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDebito.Click += new System.EventHandler(this.lblDebito_Click);
            this.lblDebito.MouseEnter += new System.EventHandler(this.lblDebito_MouseEnter);
            this.lblDebito.MouseLeave += new System.EventHandler(this.lblDebito_MouseLeave);
            // 
            // TFDebitoCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 219);
            this.Controls.Add(this.panelDados1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDebitoCredito";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FDebitoCredito";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDebitoCredito_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsMaquina)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.Label lblDebito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsMaquina;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmaquinaDataGridViewTextBoxColumn;
    }
}