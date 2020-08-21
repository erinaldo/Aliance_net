namespace Locacao
{
    partial class TFInformarVeiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFInformarVeiculo));
            this.pDados = new Componentes.PanelDados(this.components);
            this.lbCancela = new System.Windows.Forms.Label();
            this.lblConfirma = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ds_obs = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nm_motorista = new Componentes.EditDefault(this.components);
            this.bb_motorista = new System.Windows.Forms.Button();
            this.cd_motorista = new Componentes.EditDefault(this.components);
            this.placa = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_veiculo = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_veiculo = new System.Windows.Forms.Button();
            this.id_veiculo = new Componentes.EditDefault(this.components);
            this.txtHistorico = new System.Windows.Forms.TextBox();
            this.pHistorico = new Componentes.PanelDados(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.pHistorico.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.pHistorico);
            this.pDados.Controls.Add(this.lbCancela);
            this.pDados.Controls.Add(this.lblConfirma);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.ds_obs);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.nm_motorista);
            this.pDados.Controls.Add(this.bb_motorista);
            this.pDados.Controls.Add(this.cd_motorista);
            this.pDados.Controls.Add(this.placa);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_veiculo);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.bb_veiculo);
            this.pDados.Controls.Add(this.id_veiculo);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 0);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(663, 360);
            this.pDados.TabIndex = 3;
            // 
            // lbCancela
            // 
            this.lbCancela.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCancela.ForeColor = System.Drawing.Color.Red;
            this.lbCancela.Location = new System.Drawing.Point(471, 133);
            this.lbCancela.Name = "lbCancela";
            this.lbCancela.Size = new System.Drawing.Size(180, 19);
            this.lbCancela.TabIndex = 133;
            this.lbCancela.Text = "<ESC> CANCELAR";
            this.lbCancela.Click += new System.EventHandler(this.lbCancela_Click);
            this.lbCancela.MouseEnter += new System.EventHandler(this.lbCancela_MouseEnter);
            this.lbCancela.MouseLeave += new System.EventHandler(this.lbCancela_MouseLeave);
            // 
            // lblConfirma
            // 
            this.lblConfirma.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirma.Location = new System.Drawing.Point(158, 133);
            this.lblConfirma.Name = "lblConfirma";
            this.lblConfirma.Size = new System.Drawing.Size(309, 19);
            this.lblConfirma.TabIndex = 6;
            this.lblConfirma.Text = "<ENTER> Confirmar Coleta/Entrega";
            this.lblConfirma.Click += new System.EventHandler(this.lblConfirma_Click);
            this.lblConfirma.MouseEnter += new System.EventHandler(this.lblConfirma_MouseEnter);
            this.lblConfirma.MouseLeave += new System.EventHandler(this.lblConfirma_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 132;
            this.label5.Text = "Obs:";
            // 
            // ds_obs
            // 
            this.ds_obs.BackColor = System.Drawing.SystemColors.Window;
            this.ds_obs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_obs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_obs.Location = new System.Drawing.Point(77, 68);
            this.ds_obs.Multiline = true;
            this.ds_obs.Name = "ds_obs";
            this.ds_obs.NM_Alias = "";
            this.ds_obs.NM_Campo = "";
            this.ds_obs.NM_CampoBusca = "";
            this.ds_obs.NM_Param = "";
            this.ds_obs.QTD_Zero = 0;
            this.ds_obs.Size = new System.Drawing.Size(549, 56);
            this.ds_obs.ST_AutoInc = false;
            this.ds_obs.ST_DisableAuto = false;
            this.ds_obs.ST_Float = false;
            this.ds_obs.ST_Gravar = false;
            this.ds_obs.ST_Int = false;
            this.ds_obs.ST_LimpaCampo = true;
            this.ds_obs.ST_NotNull = false;
            this.ds_obs.ST_PrimaryKey = false;
            this.ds_obs.TabIndex = 5;
            this.ds_obs.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 128;
            this.label1.Text = "Entregador:";
            // 
            // nm_motorista
            // 
            this.nm_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.nm_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_motorista.Enabled = false;
            this.nm_motorista.Location = new System.Drawing.Point(187, 42);
            this.nm_motorista.Name = "nm_motorista";
            this.nm_motorista.NM_Alias = "";
            this.nm_motorista.NM_Campo = "Nm_clifor";
            this.nm_motorista.NM_CampoBusca = "Nm_clifor";
            this.nm_motorista.NM_Param = "@P_NM_CLIFOR";
            this.nm_motorista.QTD_Zero = 0;
            this.nm_motorista.Size = new System.Drawing.Size(439, 20);
            this.nm_motorista.ST_AutoInc = false;
            this.nm_motorista.ST_DisableAuto = false;
            this.nm_motorista.ST_Float = false;
            this.nm_motorista.ST_Gravar = false;
            this.nm_motorista.ST_Int = false;
            this.nm_motorista.ST_LimpaCampo = true;
            this.nm_motorista.ST_NotNull = false;
            this.nm_motorista.ST_PrimaryKey = false;
            this.nm_motorista.TabIndex = 127;
            this.nm_motorista.TextOld = null;
            // 
            // bb_motorista
            // 
            this.bb_motorista.Image = ((System.Drawing.Image)(resources.GetObject("bb_motorista.Image")));
            this.bb_motorista.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_motorista.Location = new System.Drawing.Point(153, 42);
            this.bb_motorista.Name = "bb_motorista";
            this.bb_motorista.Size = new System.Drawing.Size(28, 20);
            this.bb_motorista.TabIndex = 3;
            this.bb_motorista.UseVisualStyleBackColor = true;
            this.bb_motorista.Click += new System.EventHandler(this.bb_motorista_Click);
            // 
            // cd_motorista
            // 
            this.cd_motorista.BackColor = System.Drawing.Color.White;
            this.cd_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_motorista.Location = new System.Drawing.Point(77, 42);
            this.cd_motorista.Name = "cd_motorista";
            this.cd_motorista.NM_Alias = "";
            this.cd_motorista.NM_Campo = "Cd_clifor";
            this.cd_motorista.NM_CampoBusca = "Cd_clifor";
            this.cd_motorista.NM_Param = "@P_CD_CLIFOR";
            this.cd_motorista.QTD_Zero = 0;
            this.cd_motorista.Size = new System.Drawing.Size(72, 20);
            this.cd_motorista.ST_AutoInc = false;
            this.cd_motorista.ST_DisableAuto = false;
            this.cd_motorista.ST_Float = false;
            this.cd_motorista.ST_Gravar = true;
            this.cd_motorista.ST_Int = false;
            this.cd_motorista.ST_LimpaCampo = true;
            this.cd_motorista.ST_NotNull = true;
            this.cd_motorista.ST_PrimaryKey = false;
            this.cd_motorista.TabIndex = 2;
            this.cd_motorista.TextOld = null;
            this.cd_motorista.Leave += new System.EventHandler(this.cd_motorista_Leave);
            // 
            // placa
            // 
            this.placa.BackColor = System.Drawing.SystemColors.Window;
            this.placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.placa.Enabled = false;
            this.placa.Location = new System.Drawing.Point(512, 17);
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "placa";
            this.placa.NM_CampoBusca = "placa";
            this.placa.NM_Param = "@P_DS_VEICULO";
            this.placa.QTD_Zero = 0;
            this.placa.Size = new System.Drawing.Size(114, 20);
            this.placa.ST_AutoInc = false;
            this.placa.ST_DisableAuto = false;
            this.placa.ST_Float = false;
            this.placa.ST_Gravar = false;
            this.placa.ST_Int = false;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = false;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 124;
            this.placa.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(471, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 123;
            this.label2.Text = "Placa:";
            // 
            // ds_veiculo
            // 
            this.ds_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_veiculo.Enabled = false;
            this.ds_veiculo.Location = new System.Drawing.Point(187, 16);
            this.ds_veiculo.Name = "ds_veiculo";
            this.ds_veiculo.NM_Alias = "";
            this.ds_veiculo.NM_Campo = "Ds_veiculo";
            this.ds_veiculo.NM_CampoBusca = "Ds_veiculo";
            this.ds_veiculo.NM_Param = "@P_DS_VEICULO";
            this.ds_veiculo.QTD_Zero = 0;
            this.ds_veiculo.Size = new System.Drawing.Size(263, 20);
            this.ds_veiculo.ST_AutoInc = false;
            this.ds_veiculo.ST_DisableAuto = false;
            this.ds_veiculo.ST_Float = false;
            this.ds_veiculo.ST_Gravar = false;
            this.ds_veiculo.ST_Int = false;
            this.ds_veiculo.ST_LimpaCampo = true;
            this.ds_veiculo.ST_NotNull = false;
            this.ds_veiculo.ST_PrimaryKey = false;
            this.ds_veiculo.TabIndex = 121;
            this.ds_veiculo.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 122;
            this.label3.Text = "Veiculo:";
            // 
            // bb_veiculo
            // 
            this.bb_veiculo.Image = ((System.Drawing.Image)(resources.GetObject("bb_veiculo.Image")));
            this.bb_veiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_veiculo.Location = new System.Drawing.Point(153, 15);
            this.bb_veiculo.Name = "bb_veiculo";
            this.bb_veiculo.Size = new System.Drawing.Size(28, 20);
            this.bb_veiculo.TabIndex = 1;
            this.bb_veiculo.UseVisualStyleBackColor = true;
            this.bb_veiculo.Click += new System.EventHandler(this.bb_veiculo_Click);
            // 
            // id_veiculo
            // 
            this.id_veiculo.BackColor = System.Drawing.Color.White;
            this.id_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculo.Location = new System.Drawing.Point(77, 16);
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.NM_Alias = "";
            this.id_veiculo.NM_Campo = "Id_veiculo";
            this.id_veiculo.NM_CampoBusca = "Id_veiculo";
            this.id_veiculo.NM_Param = "@P_ID_VEICULO";
            this.id_veiculo.QTD_Zero = 0;
            this.id_veiculo.Size = new System.Drawing.Size(72, 20);
            this.id_veiculo.ST_AutoInc = false;
            this.id_veiculo.ST_DisableAuto = false;
            this.id_veiculo.ST_Float = false;
            this.id_veiculo.ST_Gravar = true;
            this.id_veiculo.ST_Int = false;
            this.id_veiculo.ST_LimpaCampo = true;
            this.id_veiculo.ST_NotNull = true;
            this.id_veiculo.ST_PrimaryKey = false;
            this.id_veiculo.TabIndex = 0;
            this.id_veiculo.TextOld = null;
            this.id_veiculo.Leave += new System.EventHandler(this.id_veiculo_Leave);
            // 
            // txtHistorico
            // 
            this.txtHistorico.Location = new System.Drawing.Point(3, 17);
            this.txtHistorico.Multiline = true;
            this.txtHistorico.Name = "txtHistorico";
            this.txtHistorico.ReadOnly = true;
            this.txtHistorico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHistorico.Size = new System.Drawing.Size(543, 158);
            this.txtHistorico.TabIndex = 134;
            this.txtHistorico.TabStop = false;
            // 
            // pHistorico
            // 
            this.pHistorico.Controls.Add(this.txtHistorico);
            this.pHistorico.Location = new System.Drawing.Point(77, 172);
            this.pHistorico.Name = "pHistorico";
            this.pHistorico.NM_ProcDeletar = "";
            this.pHistorico.NM_ProcGravar = "";
            this.pHistorico.Size = new System.Drawing.Size(549, 175);
            this.pHistorico.TabIndex = 135;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 136;
            this.label4.Text = "Histórico";
            // 
            // TFInformarVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 360);
            this.Controls.Add(this.pDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFInformarVeiculo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informar Veículo";
            this.Load += new System.EventHandler(this.TFInformarVeiculo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFInformarVeiculo_KeyDown);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pHistorico.ResumeLayout(false);
            this.pHistorico.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault nm_motorista;
        private System.Windows.Forms.Button bb_motorista;
        private Componentes.EditDefault cd_motorista;
        private Componentes.EditDefault placa;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_veiculo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_veiculo;
        private Componentes.EditDefault id_veiculo;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault ds_obs;
        private System.Windows.Forms.Label lblConfirma;
        private System.Windows.Forms.Label lbCancela;
        private System.Windows.Forms.Label label4;
        private Componentes.PanelDados pHistorico;
        private System.Windows.Forms.TextBox txtHistorico;
    }
}