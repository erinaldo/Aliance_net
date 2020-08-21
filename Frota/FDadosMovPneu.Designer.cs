namespace Frota
{
    partial class TFDadosMovPneu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDadosMovPneu));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.valor_os = new Componentes.EditFloat(this.components);
            this.bsMovPneu = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tp_recap = new Componentes.ComboBoxDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.tp_mov = new Componentes.ComboBoxDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.obs = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.dt_preventrega = new Componentes.EditData(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.nr_os = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nm_recapador = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dt_movimento = new Componentes.EditData(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valor_os)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovPneu)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(682, 43);
            this.barraMenu.TabIndex = 20;
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.valor_os);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.tp_recap);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.tp_mov);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.obs);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.dt_preventrega);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.nr_os);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.nm_recapador);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.dt_movimento);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(682, 194);
            this.pDados.TabIndex = 21;
            // 
            // valor_os
            // 
            this.valor_os.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsMovPneu, "Valor_OS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.valor_os.DecimalPlaces = 2;
            this.valor_os.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valor_os.Location = new System.Drawing.Point(235, 41);
            this.valor_os.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.valor_os.Name = "valor_os";
            this.valor_os.NM_Alias = "";
            this.valor_os.NM_Campo = "Valor OS";
            this.valor_os.NM_Param = "@P_VALOR OS";
            this.valor_os.Operador = "";
            this.valor_os.Size = new System.Drawing.Size(96, 20);
            this.valor_os.ST_AutoInc = false;
            this.valor_os.ST_DisableAuto = false;
            this.valor_os.ST_Gravar = true;
            this.valor_os.ST_LimparCampo = true;
            this.valor_os.ST_NotNull = true;
            this.valor_os.ST_PrimaryKey = false;
            this.valor_os.TabIndex = 7;
            this.valor_os.ThousandsSeparator = true;
            this.valor_os.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // bsMovPneu
            // 
            this.bsMovPneu.DataSource = typeof(CamadaDados.Frota.TList_MovPneu);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(181, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 90;
            this.label9.Text = "Valor OS:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 89;
            this.label8.Text = "Tipo Recap:";
            // 
            // tp_recap
            // 
            this.tp_recap.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMovPneu, "Tp_recap", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_recap.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovPneu, "Tipo_recap", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_recap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_recap.FormattingEnabled = true;
            this.tp_recap.Location = new System.Drawing.Point(356, 67);
            this.tp_recap.Name = "tp_recap";
            this.tp_recap.NM_Alias = "";
            this.tp_recap.NM_Campo = "Tipo Recap";
            this.tp_recap.NM_Param = "@P_TIPO RECAP";
            this.tp_recap.Size = new System.Drawing.Size(146, 21);
            this.tp_recap.ST_Gravar = true;
            this.tp_recap.ST_LimparCampo = true;
            this.tp_recap.ST_NotNull = false;
            this.tp_recap.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 87;
            this.label7.Text = "Tipo Mov.:";
            // 
            // tp_mov
            // 
            this.tp_mov.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMovPneu, "Tp_movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_mov.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovPneu, "Tipo_movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_mov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_mov.FormattingEnabled = true;
            this.tp_mov.Location = new System.Drawing.Point(96, 66);
            this.tp_mov.Name = "tp_mov";
            this.tp_mov.NM_Alias = "";
            this.tp_mov.NM_Campo = "Tipo Movimento";
            this.tp_mov.NM_Param = "@P_TIPO MOVIMENTO";
            this.tp_mov.Size = new System.Drawing.Size(185, 21);
            this.tp_mov.ST_Gravar = true;
            this.tp_mov.ST_LimparCampo = true;
            this.tp_mov.ST_NotNull = true;
            this.tp_mov.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "Obs:";
            // 
            // obs
            // 
            this.obs.BackColor = System.Drawing.SystemColors.Window;
            this.obs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.obs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.obs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovPneu, "Obs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.obs.Location = new System.Drawing.Point(96, 93);
            this.obs.Multiline = true;
            this.obs.Name = "obs";
            this.obs.NM_Alias = "";
            this.obs.NM_Campo = "";
            this.obs.NM_CampoBusca = "";
            this.obs.NM_Param = "";
            this.obs.QTD_Zero = 0;
            this.obs.Size = new System.Drawing.Size(569, 88);
            this.obs.ST_AutoInc = false;
            this.obs.ST_DisableAuto = false;
            this.obs.ST_Float = false;
            this.obs.ST_Gravar = true;
            this.obs.ST_Int = false;
            this.obs.ST_LimpaCampo = true;
            this.obs.ST_NotNull = false;
            this.obs.ST_PrimaryKey = false;
            this.obs.TabIndex = 8;
            this.obs.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 83;
            this.label5.Text = "Dt.Prev. Entrega:";
            // 
            // dt_preventrega
            // 
            this.dt_preventrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_preventrega.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovPneu, "Dt_preventrega", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_preventrega.Location = new System.Drawing.Point(592, 41);
            this.dt_preventrega.Mask = "00/00/0000";
            this.dt_preventrega.Name = "dt_preventrega";
            this.dt_preventrega.NM_Alias = "";
            this.dt_preventrega.NM_Campo = "";
            this.dt_preventrega.NM_CampoBusca = "";
            this.dt_preventrega.NM_Param = "";
            this.dt_preventrega.Operador = "";
            this.dt_preventrega.Size = new System.Drawing.Size(72, 20);
            this.dt_preventrega.ST_Gravar = true;
            this.dt_preventrega.ST_LimpaCampo = true;
            this.dt_preventrega.ST_NotNull = false;
            this.dt_preventrega.ST_PrimaryKey = false;
            this.dt_preventrega.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "Nº OS:";
            // 
            // nr_os
            // 
            this.nr_os.BackColor = System.Drawing.SystemColors.Window;
            this.nr_os.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_os.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_os.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovPneu, "Nr_OS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_os.Location = new System.Drawing.Point(96, 41);
            this.nr_os.Name = "nr_os";
            this.nr_os.NM_Alias = "";
            this.nr_os.NM_Campo = "";
            this.nr_os.NM_CampoBusca = "";
            this.nr_os.NM_Param = "";
            this.nr_os.QTD_Zero = 0;
            this.nr_os.Size = new System.Drawing.Size(80, 20);
            this.nr_os.ST_AutoInc = false;
            this.nr_os.ST_DisableAuto = false;
            this.nr_os.ST_Float = false;
            this.nr_os.ST_Gravar = true;
            this.nr_os.ST_Int = false;
            this.nr_os.ST_LimpaCampo = true;
            this.nr_os.ST_NotNull = false;
            this.nr_os.ST_PrimaryKey = false;
            this.nr_os.TabIndex = 1;
            this.nr_os.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Recapador:";
            // 
            // nm_recapador
            // 
            this.nm_recapador.BackColor = System.Drawing.SystemColors.Window;
            this.nm_recapador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_recapador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_recapador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovPneu, "NM_recapador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_recapador.Location = new System.Drawing.Point(96, 15);
            this.nm_recapador.Name = "nm_recapador";
            this.nm_recapador.NM_Alias = "";
            this.nm_recapador.NM_Campo = "";
            this.nm_recapador.NM_CampoBusca = "";
            this.nm_recapador.NM_Param = "";
            this.nm_recapador.QTD_Zero = 0;
            this.nm_recapador.Size = new System.Drawing.Size(569, 20);
            this.nm_recapador.ST_AutoInc = false;
            this.nm_recapador.ST_DisableAuto = false;
            this.nm_recapador.ST_Float = false;
            this.nm_recapador.ST_Gravar = true;
            this.nm_recapador.ST_Int = false;
            this.nm_recapador.ST_LimpaCampo = true;
            this.nm_recapador.ST_NotNull = false;
            this.nm_recapador.ST_PrimaryKey = false;
            this.nm_recapador.TabIndex = 0;
            this.nm_recapador.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Dt.Movimento:";
            // 
            // dt_movimento
            // 
            this.dt_movimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_movimento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovPneu, "Dt_movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_movimento.Location = new System.Drawing.Point(419, 41);
            this.dt_movimento.Mask = "00/00/0000";
            this.dt_movimento.Name = "dt_movimento";
            this.dt_movimento.NM_Alias = "";
            this.dt_movimento.NM_Campo = "DT.Movimento";
            this.dt_movimento.NM_CampoBusca = "DT.Movimento";
            this.dt_movimento.NM_Param = "@P_DT.MOVIMENTO";
            this.dt_movimento.Operador = "";
            this.dt_movimento.Size = new System.Drawing.Size(72, 20);
            this.dt_movimento.ST_Gravar = true;
            this.dt_movimento.ST_LimpaCampo = true;
            this.dt_movimento.ST_NotNull = true;
            this.dt_movimento.ST_PrimaryKey = false;
            this.dt_movimento.TabIndex = 3;
            // 
            // TFDadosMovPneu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 237);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDadosMovPneu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenção Pneu";
            this.Load += new System.EventHandler(this.TFDadosMovPneu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDadosMovPneu_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valor_os)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovPneu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label2;
        private Componentes.EditData dt_movimento;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nm_recapador;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault nr_os;
        private Componentes.EditDefault obs;
        private System.Windows.Forms.Label label5;
        private Componentes.EditData dt_preventrega;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bsMovPneu;
        private System.Windows.Forms.Label label7;
        private Componentes.ComboBoxDefault tp_mov;
        private System.Windows.Forms.Label label8;
        private Componentes.ComboBoxDefault tp_recap;
        private Componentes.EditFloat valor_os;
        private System.Windows.Forms.Label label9;
    }
}