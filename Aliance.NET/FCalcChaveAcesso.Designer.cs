namespace Aliance.NET
{
    partial class TFCalcChaveAcesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCalcChaveAcesso));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.chave4 = new Componentes.EditDefault(this.components);
            this.chave3 = new Componentes.EditDefault(this.components);
            this.chave2 = new Componentes.EditDefault(this.components);
            this.chave1 = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.NR_CGC = new Componentes.EditMask(this.components);
            this.LB_NR_CGC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dt_ativacao = new Componentes.EditData(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nr_sequencial = new Componentes.EditDefault(this.components);
            this.qt_diasvalidade = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(380, 43);
            this.barraMenu.TabIndex = 534;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.qt_diasvalidade);
            this.pDados.Controls.Add(this.nr_sequencial);
            this.pDados.Controls.Add(this.bb_clifor);
            this.pDados.Controls.Add(this.chave4);
            this.pDados.Controls.Add(this.chave3);
            this.pDados.Controls.Add(this.chave2);
            this.pDados.Controls.Add(this.chave1);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.NR_CGC);
            this.pDados.Controls.Add(this.LB_NR_CGC);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.dt_ativacao);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(380, 85);
            this.pDados.TabIndex = 535;
            // 
            // bb_clifor
            // 
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(206, 5);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(30, 21);
            this.bb_clifor.TabIndex = 1;
            this.bb_clifor.UseVisualStyleBackColor = true;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // chave4
            // 
            this.chave4.BackColor = System.Drawing.SystemColors.Window;
            this.chave4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chave4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.chave4.Location = new System.Drawing.Point(304, 57);
            this.chave4.MaxLength = 6;
            this.chave4.Name = "chave4";
            this.chave4.NM_Alias = "";
            this.chave4.NM_Campo = "";
            this.chave4.NM_CampoBusca = "";
            this.chave4.NM_Param = "";
            this.chave4.QTD_Zero = 0;
            this.chave4.Size = new System.Drawing.Size(68, 20);
            this.chave4.ST_AutoInc = false;
            this.chave4.ST_DisableAuto = false;
            this.chave4.ST_Float = false;
            this.chave4.ST_Gravar = false;
            this.chave4.ST_Int = false;
            this.chave4.ST_LimpaCampo = true;
            this.chave4.ST_NotNull = false;
            this.chave4.ST_PrimaryKey = false;
            this.chave4.TabIndex = 8;
            this.chave4.TextOld = null;
            this.chave4.Leave += new System.EventHandler(this.chave4_Leave);
            // 
            // chave3
            // 
            this.chave3.BackColor = System.Drawing.SystemColors.Window;
            this.chave3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chave3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.chave3.Location = new System.Drawing.Point(234, 57);
            this.chave3.MaxLength = 6;
            this.chave3.Name = "chave3";
            this.chave3.NM_Alias = "";
            this.chave3.NM_Campo = "";
            this.chave3.NM_CampoBusca = "";
            this.chave3.NM_Param = "";
            this.chave3.QTD_Zero = 0;
            this.chave3.Size = new System.Drawing.Size(68, 20);
            this.chave3.ST_AutoInc = false;
            this.chave3.ST_DisableAuto = false;
            this.chave3.ST_Float = false;
            this.chave3.ST_Gravar = false;
            this.chave3.ST_Int = false;
            this.chave3.ST_LimpaCampo = true;
            this.chave3.ST_NotNull = false;
            this.chave3.ST_PrimaryKey = false;
            this.chave3.TabIndex = 7;
            this.chave3.TextOld = null;
            this.chave3.Leave += new System.EventHandler(this.chave3_Leave);
            // 
            // chave2
            // 
            this.chave2.BackColor = System.Drawing.SystemColors.Window;
            this.chave2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chave2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.chave2.Location = new System.Drawing.Point(164, 57);
            this.chave2.MaxLength = 6;
            this.chave2.Name = "chave2";
            this.chave2.NM_Alias = "";
            this.chave2.NM_Campo = "";
            this.chave2.NM_CampoBusca = "";
            this.chave2.NM_Param = "";
            this.chave2.QTD_Zero = 0;
            this.chave2.Size = new System.Drawing.Size(68, 20);
            this.chave2.ST_AutoInc = false;
            this.chave2.ST_DisableAuto = false;
            this.chave2.ST_Float = false;
            this.chave2.ST_Gravar = false;
            this.chave2.ST_Int = false;
            this.chave2.ST_LimpaCampo = true;
            this.chave2.ST_NotNull = false;
            this.chave2.ST_PrimaryKey = false;
            this.chave2.TabIndex = 6;
            this.chave2.TextOld = null;
            this.chave2.Leave += new System.EventHandler(this.chave2_Leave);
            // 
            // chave1
            // 
            this.chave1.BackColor = System.Drawing.SystemColors.Window;
            this.chave1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chave1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.chave1.Location = new System.Drawing.Point(94, 57);
            this.chave1.MaxLength = 6;
            this.chave1.Name = "chave1";
            this.chave1.NM_Alias = "";
            this.chave1.NM_Campo = "";
            this.chave1.NM_CampoBusca = "";
            this.chave1.NM_Param = "";
            this.chave1.QTD_Zero = 0;
            this.chave1.Size = new System.Drawing.Size(68, 20);
            this.chave1.ST_AutoInc = false;
            this.chave1.ST_DisableAuto = false;
            this.chave1.ST_Float = false;
            this.chave1.ST_Gravar = false;
            this.chave1.ST_Int = false;
            this.chave1.ST_LimpaCampo = true;
            this.chave1.ST_NotNull = false;
            this.chave1.ST_PrimaryKey = false;
            this.chave1.TabIndex = 5;
            this.chave1.TextOld = null;
            this.chave1.Leave += new System.EventHandler(this.chave1_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Sequencial:";
            // 
            // NR_CGC
            // 
            this.NR_CGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NR_CGC.Location = new System.Drawing.Point(94, 6);
            this.NR_CGC.Mask = "00\\.000\\.000/0000-00";
            this.NR_CGC.Name = "NR_CGC";
            this.NR_CGC.NM_Alias = "";
            this.NR_CGC.NM_Campo = "NR_CGC_CPF";
            this.NR_CGC.NM_CampoBusca = "NR_CGC";
            this.NR_CGC.NM_Param = "@P_NR_CGC";
            this.NR_CGC.Size = new System.Drawing.Size(112, 20);
            this.NR_CGC.ST_Gravar = true;
            this.NR_CGC.ST_LimpaCampo = true;
            this.NR_CGC.ST_NotNull = false;
            this.NR_CGC.ST_PrimaryKey = false;
            this.NR_CGC.TabIndex = 0;
            this.NR_CGC.Leave += new System.EventHandler(this.NR_CGC_Leave);
            // 
            // LB_NR_CGC
            // 
            this.LB_NR_CGC.AutoSize = true;
            this.LB_NR_CGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_NR_CGC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_NR_CGC.Location = new System.Drawing.Point(50, 9);
            this.LB_NR_CGC.Name = "LB_NR_CGC";
            this.LB_NR_CGC.Size = new System.Drawing.Size(37, 13);
            this.LB_NR_CGC.TabIndex = 52;
            this.LB_NR_CGC.Text = "CNPJ:";
            this.LB_NR_CGC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chave Validade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dias Validade:";
            // 
            // dt_ativacao
            // 
            this.dt_ativacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ativacao.Location = new System.Drawing.Point(94, 31);
            this.dt_ativacao.Mask = "00/00/0000";
            this.dt_ativacao.Name = "dt_ativacao";
            this.dt_ativacao.NM_Alias = "";
            this.dt_ativacao.NM_Campo = "";
            this.dt_ativacao.NM_CampoBusca = "";
            this.dt_ativacao.NM_Param = "";
            this.dt_ativacao.Operador = "";
            this.dt_ativacao.Size = new System.Drawing.Size(68, 20);
            this.dt_ativacao.ST_Gravar = false;
            this.dt_ativacao.ST_LimpaCampo = true;
            this.dt_ativacao.ST_NotNull = false;
            this.dt_ativacao.ST_PrimaryKey = false;
            this.dt_ativacao.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dt. Ativação:";
            // 
            // nr_sequencial
            // 
            this.nr_sequencial.BackColor = System.Drawing.SystemColors.Window;
            this.nr_sequencial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_sequencial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_sequencial.Location = new System.Drawing.Point(309, 6);
            this.nr_sequencial.Name = "nr_sequencial";
            this.nr_sequencial.NM_Alias = "";
            this.nr_sequencial.NM_Campo = "";
            this.nr_sequencial.NM_CampoBusca = "";
            this.nr_sequencial.NM_Param = "";
            this.nr_sequencial.QTD_Zero = 0;
            this.nr_sequencial.Size = new System.Drawing.Size(65, 20);
            this.nr_sequencial.ST_AutoInc = false;
            this.nr_sequencial.ST_DisableAuto = false;
            this.nr_sequencial.ST_Float = false;
            this.nr_sequencial.ST_Gravar = true;
            this.nr_sequencial.ST_Int = true;
            this.nr_sequencial.ST_LimpaCampo = true;
            this.nr_sequencial.ST_NotNull = false;
            this.nr_sequencial.ST_PrimaryKey = false;
            this.nr_sequencial.TabIndex = 2;
            this.nr_sequencial.TextOld = null;
            // 
            // qt_diasvalidade
            // 
            this.qt_diasvalidade.BackColor = System.Drawing.SystemColors.Window;
            this.qt_diasvalidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qt_diasvalidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.qt_diasvalidade.Location = new System.Drawing.Point(249, 31);
            this.qt_diasvalidade.Name = "qt_diasvalidade";
            this.qt_diasvalidade.NM_Alias = "";
            this.qt_diasvalidade.NM_Campo = "";
            this.qt_diasvalidade.NM_CampoBusca = "";
            this.qt_diasvalidade.NM_Param = "";
            this.qt_diasvalidade.QTD_Zero = 0;
            this.qt_diasvalidade.Size = new System.Drawing.Size(65, 20);
            this.qt_diasvalidade.ST_AutoInc = false;
            this.qt_diasvalidade.ST_DisableAuto = false;
            this.qt_diasvalidade.ST_Float = false;
            this.qt_diasvalidade.ST_Gravar = true;
            this.qt_diasvalidade.ST_Int = true;
            this.qt_diasvalidade.ST_LimpaCampo = true;
            this.qt_diasvalidade.ST_NotNull = false;
            this.qt_diasvalidade.ST_PrimaryKey = false;
            this.qt_diasvalidade.TabIndex = 4;
            this.qt_diasvalidade.TextOld = null;
            // 
            // TFCalcChaveAcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 128);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCalcChaveAcesso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ativar o Sistema Aliance.NET";
            this.Load += new System.EventHandler(this.TFCalcChaveAcesso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCalcChaveAcesso_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Componentes.EditData dt_ativacao;
        private System.Windows.Forms.Label label1;
        private Componentes.EditMask NR_CGC;
        private System.Windows.Forms.Label LB_NR_CGC;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault chave4;
        private Componentes.EditDefault chave3;
        private Componentes.EditDefault chave2;
        private Componentes.EditDefault chave1;
        private System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault qt_diasvalidade;
        private Componentes.EditDefault nr_sequencial;
    }
}