namespace PDV
{
    partial class TFDesconto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDesconto));
            this.rbValor = new Componentes.RadioButtonDefault(this.components);
            this.rbPerc = new Componentes.RadioButtonDefault(this.components);
            this.lblLabel = new System.Windows.Forms.Label();
            this.vl_desconto = new Componentes.EditFloat(this.components);
            this.lblCancela = new System.Windows.Forms.Label();
            this.lblConfirma = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vl_desconto)).BeginInit();
            this.SuspendLayout();
            // 
            // rbValor
            // 
            this.rbValor.BackColor = System.Drawing.Color.Transparent;
            this.rbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbValor.Location = new System.Drawing.Point(26, 16);
            this.rbValor.Name = "rbValor";
            this.rbValor.Size = new System.Drawing.Size(157, 33);
            this.rbValor.TabIndex = 1;
            this.rbValor.Text = "(V) Desconto Valor";
            this.rbValor.UseVisualStyleBackColor = false;
            this.rbValor.Valor = "";
            this.rbValor.CheckedChanged += new System.EventHandler(this.rbValor_CheckedChanged);
            // 
            // rbPerc
            // 
            this.rbPerc.BackColor = System.Drawing.Color.Transparent;
            this.rbPerc.Checked = true;
            this.rbPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPerc.Location = new System.Drawing.Point(26, 65);
            this.rbPerc.Name = "rbPerc";
            this.rbPerc.Size = new System.Drawing.Size(146, 33);
            this.rbPerc.TabIndex = 2;
            this.rbPerc.TabStop = true;
            this.rbPerc.Text = "(P) Desconto %";
            this.rbPerc.UseVisualStyleBackColor = false;
            this.rbPerc.Valor = "";
            this.rbPerc.CheckedChanged += new System.EventHandler(this.rbPerc_CheckedChanged);
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel.ForeColor = System.Drawing.Color.White;
            this.lblLabel.Location = new System.Drawing.Point(12, 107);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(153, 24);
            this.lblLabel.TabIndex = 2;
            this.lblLabel.Text = "Valor Desconto";
            // 
            // vl_desconto
            // 
            this.vl_desconto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vl_desconto.DecimalPlaces = 2;
            this.vl_desconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_desconto.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_desconto.Location = new System.Drawing.Point(17, 147);
            this.vl_desconto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_desconto.Name = "vl_desconto";
            this.vl_desconto.NM_Alias = "";
            this.vl_desconto.NM_Campo = "";
            this.vl_desconto.NM_Param = "";
            this.vl_desconto.Operador = "";
            this.vl_desconto.Size = new System.Drawing.Size(166, 34);
            this.vl_desconto.ST_AutoInc = false;
            this.vl_desconto.ST_DisableAuto = false;
            this.vl_desconto.ST_Gravar = false;
            this.vl_desconto.ST_LimparCampo = true;
            this.vl_desconto.ST_NotNull = false;
            this.vl_desconto.ST_PrimaryKey = false;
            this.vl_desconto.TabIndex = 0;
            this.vl_desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vl_desconto.ThousandsSeparator = true;
            this.vl_desconto.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblCancela
            // 
            this.lblCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancela.Location = new System.Drawing.Point(10, 225);
            this.lblCancela.Name = "lblCancela";
            this.lblCancela.Size = new System.Drawing.Size(176, 18);
            this.lblCancela.TabIndex = 5;
            this.lblCancela.Text = "<ESC> Sair";
            this.lblCancela.Click += new System.EventHandler(this.lblCancela_Click);
            this.lblCancela.MouseEnter += new System.EventHandler(this.lblCancela_MouseEnter);
            this.lblCancela.MouseLeave += new System.EventHandler(this.lblCancela_MouseLeave);
            // 
            // lblConfirma
            // 
            this.lblConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirma.Location = new System.Drawing.Point(10, 202);
            this.lblConfirma.Name = "lblConfirma";
            this.lblConfirma.Size = new System.Drawing.Size(176, 19);
            this.lblConfirma.TabIndex = 4;
            this.lblConfirma.Text = "<ENTER> Confirmar";
            this.lblConfirma.Click += new System.EventHandler(this.lblConfirma_Click);
            this.lblConfirma.MouseEnter += new System.EventHandler(this.lblConfirma_MouseEnter);
            this.lblConfirma.MouseLeave += new System.EventHandler(this.lblConfirma_MouseLeave);
            // 
            // TFDesconto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(197, 250);
            this.Controls.Add(this.lblCancela);
            this.Controls.Add(this.lblConfirma);
            this.Controls.Add(this.vl_desconto);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.rbPerc);
            this.Controls.Add(this.rbValor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFDesconto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TFDesconto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDesconto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.vl_desconto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.RadioButtonDefault rbValor;
        private Componentes.RadioButtonDefault rbPerc;
        private System.Windows.Forms.Label lblLabel;
        private Componentes.EditFloat vl_desconto;
        private System.Windows.Forms.Label lblCancela;
        private System.Windows.Forms.Label lblConfirma;
    }
}