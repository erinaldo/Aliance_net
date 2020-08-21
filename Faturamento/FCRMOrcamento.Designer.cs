namespace Faturamento
{
    partial class TFCRMOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCRMOrcamento));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bbClifor = new System.Windows.Forms.Button();
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.bbContato = new System.Windows.Forms.Button();
            this.fone_contato = new Componentes.EditDefault(this.components);
            this.nm_contato = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.hr_agendamento = new Componentes.EditHora(this.components);
            this.dt_agendamento = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.radioGroup1.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(691, 43);
            this.barraMenu.TabIndex = 13;
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
            this.pDados.Controls.Add(this.bbClifor);
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.ds_historico);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.nm_clifor);
            this.pDados.Controls.Add(this.cd_clifor);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(691, 240);
            this.pDados.TabIndex = 0;
            // 
            // bbClifor
            // 
            this.bbClifor.Image = ((System.Drawing.Image)(resources.GetObject("bbClifor.Image")));
            this.bbClifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbClifor.Location = new System.Drawing.Point(114, 18);
            this.bbClifor.Name = "bbClifor";
            this.bbClifor.Size = new System.Drawing.Size(28, 22);
            this.bbClifor.TabIndex = 1;
            this.bbClifor.UseVisualStyleBackColor = true;
            this.bbClifor.Click += new System.EventHandler(this.bbClifor_Click);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.label6);
            this.radioGroup1.Controls.Add(this.bbContato);
            this.radioGroup1.Controls.Add(this.fone_contato);
            this.radioGroup1.Controls.Add(this.nm_contato);
            this.radioGroup1.Controls.Add(this.label5);
            this.radioGroup1.Controls.Add(this.label4);
            this.radioGroup1.Controls.Add(this.hr_agendamento);
            this.radioGroup1.Controls.Add(this.dt_agendamento);
            this.radioGroup1.Controls.Add(this.label3);
            this.radioGroup1.Location = new System.Drawing.Point(14, 172);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(660, 58);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 3;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Agendamento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(529, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fone";
            // 
            // bbContato
            // 
            this.bbContato.Image = ((System.Drawing.Image)(resources.GetObject("bbContato.Image")));
            this.bbContato.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbContato.Location = new System.Drawing.Point(498, 31);
            this.bbContato.Name = "bbContato";
            this.bbContato.Size = new System.Drawing.Size(28, 20);
            this.bbContato.TabIndex = 4;
            this.bbContato.UseVisualStyleBackColor = true;
            this.bbContato.Click += new System.EventHandler(this.bbContato_Click);
            // 
            // fone_contato
            // 
            this.fone_contato.BackColor = System.Drawing.SystemColors.Window;
            this.fone_contato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fone_contato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fone_contato.Location = new System.Drawing.Point(532, 32);
            this.fone_contato.Name = "fone_contato";
            this.fone_contato.NM_Alias = "";
            this.fone_contato.NM_Campo = "fone";
            this.fone_contato.NM_CampoBusca = "fone";
            this.fone_contato.NM_Param = "@P_FONE";
            this.fone_contato.QTD_Zero = 0;
            this.fone_contato.Size = new System.Drawing.Size(122, 20);
            this.fone_contato.ST_AutoInc = false;
            this.fone_contato.ST_DisableAuto = false;
            this.fone_contato.ST_Float = false;
            this.fone_contato.ST_Gravar = false;
            this.fone_contato.ST_Int = false;
            this.fone_contato.ST_LimpaCampo = true;
            this.fone_contato.ST_NotNull = false;
            this.fone_contato.ST_PrimaryKey = false;
            this.fone_contato.TabIndex = 5;
            this.fone_contato.TextOld = null;
            this.fone_contato.TextChanged += new System.EventHandler(this.fone_contato_TextChanged);
            // 
            // nm_contato
            // 
            this.nm_contato.BackColor = System.Drawing.SystemColors.Window;
            this.nm_contato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_contato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_contato.Location = new System.Drawing.Point(133, 32);
            this.nm_contato.Name = "nm_contato";
            this.nm_contato.NM_Alias = "";
            this.nm_contato.NM_Campo = "nm_contato";
            this.nm_contato.NM_CampoBusca = "nm_contato";
            this.nm_contato.NM_Param = "@P_NM_CONTATO";
            this.nm_contato.QTD_Zero = 0;
            this.nm_contato.Size = new System.Drawing.Size(363, 20);
            this.nm_contato.ST_AutoInc = false;
            this.nm_contato.ST_DisableAuto = false;
            this.nm_contato.ST_Float = false;
            this.nm_contato.ST_Gravar = false;
            this.nm_contato.ST_Int = false;
            this.nm_contato.ST_LimpaCampo = true;
            this.nm_contato.ST_NotNull = false;
            this.nm_contato.ST_PrimaryKey = false;
            this.nm_contato.TabIndex = 3;
            this.nm_contato.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Contato";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hora";
            // 
            // hr_agendamento
            // 
            this.hr_agendamento.Location = new System.Drawing.Point(78, 32);
            this.hr_agendamento.Mask = "00:00";
            this.hr_agendamento.Name = "hr_agendamento";
            this.hr_agendamento.NM_Alias = "";
            this.hr_agendamento.NM_Campo = "";
            this.hr_agendamento.NM_CampoBusca = "";
            this.hr_agendamento.NM_Param = "";
            this.hr_agendamento.Size = new System.Drawing.Size(52, 20);
            this.hr_agendamento.ST_Gravar = false;
            this.hr_agendamento.ST_LimpaCampo = true;
            this.hr_agendamento.ST_NotNull = false;
            this.hr_agendamento.ST_PrimaryKey = false;
            this.hr_agendamento.TabIndex = 2;
            // 
            // dt_agendamento
            // 
            this.dt_agendamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_agendamento.Location = new System.Drawing.Point(9, 32);
            this.dt_agendamento.Mask = "00/00/0000";
            this.dt_agendamento.Name = "dt_agendamento";
            this.dt_agendamento.NM_Alias = "";
            this.dt_agendamento.NM_Campo = "";
            this.dt_agendamento.NM_CampoBusca = "";
            this.dt_agendamento.NM_Param = "";
            this.dt_agendamento.Operador = "";
            this.dt_agendamento.Size = new System.Drawing.Size(66, 20);
            this.dt_agendamento.ST_Gravar = false;
            this.dt_agendamento.ST_LimpaCampo = true;
            this.dt_agendamento.ST_NotNull = false;
            this.dt_agendamento.ST_PrimaryKey = false;
            this.dt_agendamento.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Data";
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.Location = new System.Drawing.Point(14, 59);
            this.ds_historico.Multiline = true;
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "";
            this.ds_historico.NM_CampoBusca = "";
            this.ds_historico.NM_Param = "";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.Size = new System.Drawing.Size(660, 107);
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = false;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = false;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TabIndex = 2;
            this.ds_historico.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Histórico Evento";
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.Location = new System.Drawing.Point(147, 20);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_NM_CLIFOR";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(527, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 2;
            this.nm_clifor.TextOld = null;
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.Location = new System.Drawing.Point(14, 20);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_CLIFOR";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(99, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = false;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 0;
            this.cd_clifor.TextOld = null;
            this.cd_clifor.TextChanged += new System.EventHandler(this.cd_clifor_TextChanged);
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // TFCRMOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 283);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCRMOrcamento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compromisso";
            this.Load += new System.EventHandler(this.TFCRMOrcamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCRMOrcamento_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nm_clifor;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_historico;
        private System.Windows.Forms.Label label2;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.EditDefault fone_contato;
        private Componentes.EditDefault nm_contato;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Componentes.EditHora hr_agendamento;
        private Componentes.EditData dt_agendamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bbContato;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bbClifor;
    }
}