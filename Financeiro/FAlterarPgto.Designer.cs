namespace Financeiro
{
    partial class TFAlterarPgto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAlterarPgto));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.vl_saldodevolver = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.vl_adtodevolver = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vl_pagamento = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nm_funcionario = new Componentes.EditDefault(this.components);
            this.cd_funcionario = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldodevolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_adtodevolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_pagamento)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(599, 43);
            this.barraMenu.TabIndex = 10;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.vl_saldodevolver);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.vl_adtodevolver);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.vl_pagamento);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.nm_funcionario);
            this.pDados.Controls.Add(this.cd_funcionario);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(599, 58);
            this.pDados.TabIndex = 11;
            // 
            // vl_saldodevolver
            // 
            this.vl_saldodevolver.DecimalPlaces = 2;
            this.vl_saldodevolver.Enabled = false;
            this.vl_saldodevolver.Location = new System.Drawing.Point(494, 30);
            this.vl_saldodevolver.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_saldodevolver.Name = "vl_saldodevolver";
            this.vl_saldodevolver.NM_Alias = "";
            this.vl_saldodevolver.NM_Campo = "";
            this.vl_saldodevolver.NM_Param = "";
            this.vl_saldodevolver.Operador = "";
            this.vl_saldodevolver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_saldodevolver.Size = new System.Drawing.Size(96, 20);
            this.vl_saldodevolver.ST_AutoInc = false;
            this.vl_saldodevolver.ST_DisableAuto = false;
            this.vl_saldodevolver.ST_Gravar = false;
            this.vl_saldodevolver.ST_LimparCampo = true;
            this.vl_saldodevolver.ST_NotNull = false;
            this.vl_saldodevolver.ST_PrimaryKey = false;
            this.vl_saldodevolver.TabIndex = 4;
            this.vl_saldodevolver.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sd. Adto Devolver:";
            // 
            // vl_adtodevolver
            // 
            this.vl_adtodevolver.DecimalPlaces = 2;
            this.vl_adtodevolver.Location = new System.Drawing.Point(293, 30);
            this.vl_adtodevolver.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_adtodevolver.Name = "vl_adtodevolver";
            this.vl_adtodevolver.NM_Alias = "";
            this.vl_adtodevolver.NM_Campo = "";
            this.vl_adtodevolver.NM_Param = "";
            this.vl_adtodevolver.Operador = "";
            this.vl_adtodevolver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_adtodevolver.Size = new System.Drawing.Size(96, 20);
            this.vl_adtodevolver.ST_AutoInc = false;
            this.vl_adtodevolver.ST_DisableAuto = false;
            this.vl_adtodevolver.ST_Gravar = false;
            this.vl_adtodevolver.ST_LimparCampo = true;
            this.vl_adtodevolver.ST_NotNull = false;
            this.vl_adtodevolver.ST_PrimaryKey = false;
            this.vl_adtodevolver.TabIndex = 3;
            this.vl_adtodevolver.ThousandsSeparator = true;
            this.vl_adtodevolver.Leave += new System.EventHandler(this.vl_adtodevolver_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vl. Adto Devolver:";
            // 
            // vl_pagamento
            // 
            this.vl_pagamento.DecimalPlaces = 2;
            this.vl_pagamento.Location = new System.Drawing.Point(88, 30);
            this.vl_pagamento.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_pagamento.Name = "vl_pagamento";
            this.vl_pagamento.NM_Alias = "";
            this.vl_pagamento.NM_Campo = "";
            this.vl_pagamento.NM_Param = "";
            this.vl_pagamento.Operador = "";
            this.vl_pagamento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_pagamento.Size = new System.Drawing.Size(100, 20);
            this.vl_pagamento.ST_AutoInc = false;
            this.vl_pagamento.ST_DisableAuto = false;
            this.vl_pagamento.ST_Gravar = false;
            this.vl_pagamento.ST_LimparCampo = true;
            this.vl_pagamento.ST_NotNull = false;
            this.vl_pagamento.ST_PrimaryKey = false;
            this.vl_pagamento.TabIndex = 2;
            this.vl_pagamento.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vl. Pagamento:";
            // 
            // nm_funcionario
            // 
            this.nm_funcionario.BackColor = System.Drawing.SystemColors.Window;
            this.nm_funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_funcionario.Enabled = false;
            this.nm_funcionario.Location = new System.Drawing.Point(191, 4);
            this.nm_funcionario.Name = "nm_funcionario";
            this.nm_funcionario.NM_Alias = "";
            this.nm_funcionario.NM_Campo = "";
            this.nm_funcionario.NM_CampoBusca = "";
            this.nm_funcionario.NM_Param = "";
            this.nm_funcionario.QTD_Zero = 0;
            this.nm_funcionario.Size = new System.Drawing.Size(399, 20);
            this.nm_funcionario.ST_AutoInc = false;
            this.nm_funcionario.ST_DisableAuto = false;
            this.nm_funcionario.ST_Float = false;
            this.nm_funcionario.ST_Gravar = false;
            this.nm_funcionario.ST_Int = false;
            this.nm_funcionario.ST_LimpaCampo = true;
            this.nm_funcionario.ST_NotNull = false;
            this.nm_funcionario.ST_PrimaryKey = false;
            this.nm_funcionario.TabIndex = 1;
            this.nm_funcionario.TextOld = null;
            // 
            // cd_funcionario
            // 
            this.cd_funcionario.BackColor = System.Drawing.SystemColors.Window;
            this.cd_funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_funcionario.Enabled = false;
            this.cd_funcionario.Location = new System.Drawing.Point(88, 4);
            this.cd_funcionario.Name = "cd_funcionario";
            this.cd_funcionario.NM_Alias = "";
            this.cd_funcionario.NM_Campo = "";
            this.cd_funcionario.NM_CampoBusca = "";
            this.cd_funcionario.NM_Param = "";
            this.cd_funcionario.QTD_Zero = 0;
            this.cd_funcionario.Size = new System.Drawing.Size(100, 20);
            this.cd_funcionario.ST_AutoInc = false;
            this.cd_funcionario.ST_DisableAuto = false;
            this.cd_funcionario.ST_Float = false;
            this.cd_funcionario.ST_Gravar = false;
            this.cd_funcionario.ST_Int = false;
            this.cd_funcionario.ST_LimpaCampo = true;
            this.cd_funcionario.ST_NotNull = false;
            this.cd_funcionario.ST_PrimaryKey = false;
            this.cd_funcionario.TabIndex = 0;
            this.cd_funcionario.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funcionario:";
            // 
            // TFAlterarPgto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 101);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAlterarPgto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Valor Pagamento";
            this.Load += new System.EventHandler(this.TFAlterarPgto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAlterarPgto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldodevolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_adtodevolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_pagamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditFloat vl_pagamento;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nm_funcionario;
        private Componentes.EditDefault cd_funcionario;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat vl_adtodevolver;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat vl_saldodevolver;
        private System.Windows.Forms.Label label4;
    }
}