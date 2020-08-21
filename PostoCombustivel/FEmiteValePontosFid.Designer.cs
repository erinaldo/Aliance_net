namespace PostoCombustivel
{
    partial class TFEmiteValePontosFid
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
            this.placa = new Componentes.EditMask(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pontos_resgatar = new Componentes.EditFloat(this.components);
            this.bb_resgatar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.vales_impressos = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.CdCliente = new Componentes.EditDefault(this.components);
            this.NmCliente = new Componentes.EditDefault(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pontos_resgatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vales_impressos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Placa:";
            // 
            // placa
            // 
            this.placa.Enabled = false;
            this.placa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placa.Location = new System.Drawing.Point(79, 6);
            this.placa.Mask = "AAA-AAAA";
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "";
            this.placa.NM_CampoBusca = "";
            this.placa.NM_Param = "";
            this.placa.Size = new System.Drawing.Size(91, 29);
            this.placa.ST_Gravar = false;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = false;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pontos Resgatar";
            // 
            // pontos_resgatar
            // 
            this.pontos_resgatar.DecimalPlaces = 3;
            this.pontos_resgatar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pontos_resgatar.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pontos_resgatar.Location = new System.Drawing.Point(16, 100);
            this.pontos_resgatar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pontos_resgatar.Name = "pontos_resgatar";
            this.pontos_resgatar.NM_Alias = "";
            this.pontos_resgatar.NM_Campo = "";
            this.pontos_resgatar.NM_Param = "";
            this.pontos_resgatar.Operador = "";
            this.pontos_resgatar.ReadOnly = true;
            this.pontos_resgatar.Size = new System.Drawing.Size(143, 29);
            this.pontos_resgatar.ST_AutoInc = false;
            this.pontos_resgatar.ST_DisableAuto = false;
            this.pontos_resgatar.ST_Gravar = false;
            this.pontos_resgatar.ST_LimparCampo = true;
            this.pontos_resgatar.ST_NotNull = false;
            this.pontos_resgatar.ST_PrimaryKey = false;
            this.pontos_resgatar.TabIndex = 3;
            this.pontos_resgatar.TabStop = false;
            this.pontos_resgatar.ThousandsSeparator = true;
            this.pontos_resgatar.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // bb_resgatar
            // 
            this.bb_resgatar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_resgatar.ForeColor = System.Drawing.Color.Green;
            this.bb_resgatar.Location = new System.Drawing.Point(16, 135);
            this.bb_resgatar.Name = "bb_resgatar";
            this.bb_resgatar.Size = new System.Drawing.Size(345, 67);
            this.bb_resgatar.TabIndex = 4;
            this.bb_resgatar.Text = "Imprimir Vale";
            this.bb_resgatar.UseVisualStyleBackColor = true;
            this.bb_resgatar.Click += new System.EventHandler(this.bb_resgatar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vales Impressos Hoje:";
            // 
            // vales_impressos
            // 
            this.vales_impressos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vales_impressos.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vales_impressos.Location = new System.Drawing.Point(216, 215);
            this.vales_impressos.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vales_impressos.Name = "vales_impressos";
            this.vales_impressos.NM_Alias = "";
            this.vales_impressos.NM_Campo = "";
            this.vales_impressos.NM_Param = "";
            this.vales_impressos.Operador = "";
            this.vales_impressos.ReadOnly = true;
            this.vales_impressos.Size = new System.Drawing.Size(112, 29);
            this.vales_impressos.ST_AutoInc = false;
            this.vales_impressos.ST_DisableAuto = false;
            this.vales_impressos.ST_Gravar = false;
            this.vales_impressos.ST_LimparCampo = true;
            this.vales_impressos.ST_NotNull = false;
            this.vales_impressos.ST_PrimaryKey = false;
            this.vales_impressos.TabIndex = 6;
            this.vales_impressos.TabStop = false;
            this.vales_impressos.ThousandsSeparator = true;
            this.vales_impressos.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(176, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cliente";
            // 
            // CdCliente
            // 
            this.CdCliente.BackColor = System.Drawing.SystemColors.Window;
            this.CdCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CdCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CdCliente.Enabled = false;
            this.CdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CdCliente.Location = new System.Drawing.Point(250, 7);
            this.CdCliente.Name = "CdCliente";
            this.CdCliente.NM_Alias = "";
            this.CdCliente.NM_Campo = "";
            this.CdCliente.NM_CampoBusca = "";
            this.CdCliente.NM_Param = "";
            this.CdCliente.QTD_Zero = 0;
            this.CdCliente.Size = new System.Drawing.Size(110, 29);
            this.CdCliente.ST_AutoInc = false;
            this.CdCliente.ST_DisableAuto = false;
            this.CdCliente.ST_Float = false;
            this.CdCliente.ST_Gravar = false;
            this.CdCliente.ST_Int = false;
            this.CdCliente.ST_LimpaCampo = true;
            this.CdCliente.ST_NotNull = false;
            this.CdCliente.ST_PrimaryKey = false;
            this.CdCliente.TabIndex = 8;
            this.CdCliente.TextOld = null;
            // 
            // NmCliente
            // 
            this.NmCliente.BackColor = System.Drawing.SystemColors.Window;
            this.NmCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NmCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NmCliente.Enabled = false;
            this.NmCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NmCliente.Location = new System.Drawing.Point(16, 41);
            this.NmCliente.Name = "NmCliente";
            this.NmCliente.NM_Alias = "";
            this.NmCliente.NM_Campo = "";
            this.NmCliente.NM_CampoBusca = "";
            this.NmCliente.NM_Param = "";
            this.NmCliente.QTD_Zero = 0;
            this.NmCliente.Size = new System.Drawing.Size(344, 29);
            this.NmCliente.ST_AutoInc = false;
            this.NmCliente.ST_DisableAuto = false;
            this.NmCliente.ST_Float = false;
            this.NmCliente.ST_Gravar = false;
            this.NmCliente.ST_Int = false;
            this.NmCliente.ST_LimpaCampo = true;
            this.NmCliente.ST_NotNull = false;
            this.NmCliente.ST_PrimaryKey = false;
            this.NmCliente.TabIndex = 9;
            this.NmCliente.TextOld = null;
            // 
            // TFEmiteValePontosFid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 255);
            this.Controls.Add(this.NmCliente);
            this.Controls.Add(this.CdCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vales_impressos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bb_resgatar);
            this.Controls.Add(this.pontos_resgatar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.placa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFEmiteValePontosFid";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emitir Vale Pontos Fidelização";
            this.Load += new System.EventHandler(this.TFEmiteValePontosFid_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFEmiteValePontosFid_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pontos_resgatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vales_impressos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Componentes.EditMask placa;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat pontos_resgatar;
        private System.Windows.Forms.Button bb_resgatar;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat vales_impressos;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault CdCliente;
        private Componentes.EditDefault NmCliente;
    }
}