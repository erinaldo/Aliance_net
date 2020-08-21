namespace Servicos
{
    partial class TFTarefa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTarefa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.Ds_observacao = new Componentes.EditDefault(this.components);
            this.bsAtividade = new System.Windows.Forms.BindingSource(this.components);
            this.DT_Prevista = new Componentes.EditData(this.components);
            this.DT_Atividade = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Ds_atividade = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.BB_Tecnico = new System.Windows.Forms.Button();
            this.DS_Funcao = new Componentes.EditDefault(this.components);
            this.ID_Tecnico = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAtividade)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(720, 43);
            this.barraMenu.TabIndex = 15;
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.Ds_observacao);
            this.pDados.Controls.Add(this.DT_Prevista);
            this.pDados.Controls.Add(this.DT_Atividade);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.Ds_atividade);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.BB_Tecnico);
            this.pDados.Controls.Add(this.DS_Funcao);
            this.pDados.Controls.Add(this.ID_Tecnico);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(720, 259);
            this.pDados.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(45, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 247;
            this.label5.Text = "Obs:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ds_observacao
            // 
            this.Ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_observacao.Location = new System.Drawing.Point(84, 121);
            this.Ds_observacao.Multiline = true;
            this.Ds_observacao.Name = "Ds_observacao";
            this.Ds_observacao.NM_Alias = "";
            this.Ds_observacao.NM_Campo = "";
            this.Ds_observacao.NM_CampoBusca = "";
            this.Ds_observacao.NM_Param = "";
            this.Ds_observacao.QTD_Zero = 0;
            this.Ds_observacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Ds_observacao.Size = new System.Drawing.Size(629, 124);
            this.Ds_observacao.ST_AutoInc = false;
            this.Ds_observacao.ST_DisableAuto = false;
            this.Ds_observacao.ST_Float = false;
            this.Ds_observacao.ST_Gravar = false;
            this.Ds_observacao.ST_Int = false;
            this.Ds_observacao.ST_LimpaCampo = true;
            this.Ds_observacao.ST_NotNull = false;
            this.Ds_observacao.ST_PrimaryKey = false;
            this.Ds_observacao.TabIndex = 246;
            this.Ds_observacao.TextOld = null;
            // 
            // bsAtividade
            // 
            this.bsAtividade.DataSource = typeof(CamadaDados.Servicos.TList_LanAtividades);
            // 
            // DT_Prevista
            // 
            this.DT_Prevista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Prevista.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.DT_Prevista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Dt_PrevConclusao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Prevista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DT_Prevista.Location = new System.Drawing.Point(469, 95);
            this.DT_Prevista.Mask = "00/00/0000";
            this.DT_Prevista.Name = "DT_Prevista";
            this.DT_Prevista.NM_Alias = "";
            this.DT_Prevista.NM_Campo = "";
            this.DT_Prevista.NM_CampoBusca = "";
            this.DT_Prevista.NM_Param = "";
            this.DT_Prevista.Operador = "";
            this.DT_Prevista.Size = new System.Drawing.Size(83, 20);
            this.DT_Prevista.ST_Gravar = true;
            this.DT_Prevista.ST_LimpaCampo = true;
            this.DT_Prevista.ST_NotNull = false;
            this.DT_Prevista.ST_PrimaryKey = false;
            this.DT_Prevista.TabIndex = 241;
            // 
            // DT_Atividade
            // 
            this.DT_Atividade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Atividade.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.DT_Atividade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Dt_atividadestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Atividade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DT_Atividade.Location = new System.Drawing.Point(183, 95);
            this.DT_Atividade.Mask = "00/00/0000";
            this.DT_Atividade.Name = "DT_Atividade";
            this.DT_Atividade.NM_Alias = "";
            this.DT_Atividade.NM_Campo = "";
            this.DT_Atividade.NM_CampoBusca = "";
            this.DT_Atividade.NM_Param = "";
            this.DT_Atividade.Operador = "";
            this.DT_Atividade.Size = new System.Drawing.Size(94, 20);
            this.DT_Atividade.ST_Gravar = true;
            this.DT_Atividade.ST_LimpaCampo = true;
            this.DT_Atividade.ST_NotNull = false;
            this.DT_Atividade.ST_PrimaryKey = false;
            this.DT_Atividade.TabIndex = 240;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(340, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 243;
            this.label8.Text = "Previsão Conclusão:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(81, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 242;
            this.label6.Text = "Dt.Atividade:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "Atividade:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ds_atividade
            // 
            this.Ds_atividade.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_atividade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_atividade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_atividade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Ds_atividade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_atividade.Location = new System.Drawing.Point(84, 37);
            this.Ds_atividade.Multiline = true;
            this.Ds_atividade.Name = "Ds_atividade";
            this.Ds_atividade.NM_Alias = "";
            this.Ds_atividade.NM_Campo = "";
            this.Ds_atividade.NM_CampoBusca = "";
            this.Ds_atividade.NM_Param = "";
            this.Ds_atividade.QTD_Zero = 0;
            this.Ds_atividade.Size = new System.Drawing.Size(627, 52);
            this.Ds_atividade.ST_AutoInc = false;
            this.Ds_atividade.ST_DisableAuto = false;
            this.Ds_atividade.ST_Float = false;
            this.Ds_atividade.ST_Gravar = false;
            this.Ds_atividade.ST_Int = false;
            this.Ds_atividade.ST_LimpaCampo = true;
            this.Ds_atividade.ST_NotNull = false;
            this.Ds_atividade.ST_PrimaryKey = false;
            this.Ds_atividade.TabIndex = 119;
            this.Ds_atividade.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(21, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 118;
            this.label4.Text = "Técnico:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BB_Tecnico
            // 
            this.BB_Tecnico.Image = ((System.Drawing.Image)(resources.GetObject("BB_Tecnico.Image")));
            this.BB_Tecnico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Tecnico.Location = new System.Drawing.Point(150, 12);
            this.BB_Tecnico.Name = "BB_Tecnico";
            this.BB_Tecnico.Size = new System.Drawing.Size(28, 19);
            this.BB_Tecnico.TabIndex = 116;
            this.BB_Tecnico.UseVisualStyleBackColor = true;
            this.BB_Tecnico.Click += new System.EventHandler(this.BB_Tecnico_Click);
            // 
            // DS_Funcao
            // 
            this.DS_Funcao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Funcao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Funcao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Funcao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Ds_tecnico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Funcao.Enabled = false;
            this.DS_Funcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Funcao.Location = new System.Drawing.Point(183, 11);
            this.DS_Funcao.Name = "DS_Funcao";
            this.DS_Funcao.NM_Alias = "";
            this.DS_Funcao.NM_Campo = "nm_clifor";
            this.DS_Funcao.NM_CampoBusca = "nm_clifor";
            this.DS_Funcao.NM_Param = "@P_NM_CLIFOR";
            this.DS_Funcao.QTD_Zero = 0;
            this.DS_Funcao.ReadOnly = true;
            this.DS_Funcao.Size = new System.Drawing.Size(528, 20);
            this.DS_Funcao.ST_AutoInc = false;
            this.DS_Funcao.ST_DisableAuto = false;
            this.DS_Funcao.ST_Float = false;
            this.DS_Funcao.ST_Gravar = false;
            this.DS_Funcao.ST_Int = false;
            this.DS_Funcao.ST_LimpaCampo = true;
            this.DS_Funcao.ST_NotNull = false;
            this.DS_Funcao.ST_PrimaryKey = false;
            this.DS_Funcao.TabIndex = 117;
            this.DS_Funcao.TextOld = null;
            // 
            // ID_Tecnico
            // 
            this.ID_Tecnico.BackColor = System.Drawing.Color.White;
            this.ID_Tecnico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_Tecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Tecnico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Cd_tecnico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_Tecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ID_Tecnico.Location = new System.Drawing.Point(84, 11);
            this.ID_Tecnico.Name = "ID_Tecnico";
            this.ID_Tecnico.NM_Alias = "";
            this.ID_Tecnico.NM_Campo = "cd_clifor";
            this.ID_Tecnico.NM_CampoBusca = "cd_clifor";
            this.ID_Tecnico.NM_Param = "@P_CD_CLIFOR";
            this.ID_Tecnico.QTD_Zero = 0;
            this.ID_Tecnico.Size = new System.Drawing.Size(65, 20);
            this.ID_Tecnico.ST_AutoInc = false;
            this.ID_Tecnico.ST_DisableAuto = false;
            this.ID_Tecnico.ST_Float = false;
            this.ID_Tecnico.ST_Gravar = true;
            this.ID_Tecnico.ST_Int = false;
            this.ID_Tecnico.ST_LimpaCampo = true;
            this.ID_Tecnico.ST_NotNull = false;
            this.ID_Tecnico.ST_PrimaryKey = false;
            this.ID_Tecnico.TabIndex = 115;
            this.ID_Tecnico.TextOld = null;
            this.ID_Tecnico.Leave += new System.EventHandler(this.ID_Tecnico_Leave);
            // 
            // TFTarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 302);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFTarefa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento de Tarefas";
            this.Load += new System.EventHandler(this.TFTarefa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFTarefa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAtividade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        public System.Windows.Forms.Button BB_Tecnico;
        public Componentes.EditDefault DS_Funcao;
        public Componentes.EditDefault ID_Tecnico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault Ds_atividade;
        private Componentes.EditData DT_Prevista;
        private Componentes.EditData DT_Atividade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault Ds_observacao;
        private System.Windows.Forms.BindingSource bsAtividade;
    }
}