namespace Fiscal.Cadastros
{
    partial class TFCadMovXCmi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadMovXCmi));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.tp_movCMI = new Componentes.EditDefault(this.components);
            this.bs_MovCmi = new System.Windows.Forms.BindingSource(this.components);
            this.tp_movMovimentacao = new Componentes.EditDefault(this.components);
            this.ds_Movimentacao = new Componentes.EditDefault(this.components);
            this.ds_cmi = new Componentes.EditDefault(this.components);
            this.bb_Movimentacao = new System.Windows.Forms.Button();
            this.bb_cmi = new System.Windows.Forms.Button();
            this.LB_CD_Movimentacao = new System.Windows.Forms.Label();
            this.LB_CD_CMI = new System.Windows.Forms.Label();
            this.CD_Movimentacao = new Componentes.EditDefault(this.components);
            this.CD_CMI = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_MovCmi)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(507, 43);
            this.barraMenu.TabIndex = 12;
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.button2);
            this.panelDados1.Controls.Add(this.tp_movCMI);
            this.panelDados1.Controls.Add(this.tp_movMovimentacao);
            this.panelDados1.Controls.Add(this.ds_Movimentacao);
            this.panelDados1.Controls.Add(this.ds_cmi);
            this.panelDados1.Controls.Add(this.bb_Movimentacao);
            this.panelDados1.Controls.Add(this.bb_cmi);
            this.panelDados1.Controls.Add(this.LB_CD_Movimentacao);
            this.panelDados1.Controls.Add(this.LB_CD_CMI);
            this.panelDados1.Controls.Add(this.CD_Movimentacao);
            this.panelDados1.Controls.Add(this.CD_CMI);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(507, 72);
            this.panelDados1.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(206, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 174;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tp_movCMI
            // 
            this.tp_movCMI.BackColor = System.Drawing.SystemColors.Window;
            this.tp_movCMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_movCMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_movCMI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_MovCmi, "Tp_MovCMI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movCMI.Enabled = false;
            this.tp_movCMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_movCMI.Location = new System.Drawing.Point(452, 41);
            this.tp_movCMI.Name = "tp_movCMI";
            this.tp_movCMI.NM_Alias = "";
            this.tp_movCMI.NM_Campo = "tp_movcmi";
            this.tp_movCMI.NM_CampoBusca = "tp_movimento";
            this.tp_movCMI.NM_Param = "@P_TP_MOVIMENTO";
            this.tp_movCMI.QTD_Zero = 0;
            this.tp_movCMI.ReadOnly = true;
            this.tp_movCMI.Size = new System.Drawing.Size(39, 20);
            this.tp_movCMI.ST_AutoInc = false;
            this.tp_movCMI.ST_DisableAuto = false;
            this.tp_movCMI.ST_Float = false;
            this.tp_movCMI.ST_Gravar = false;
            this.tp_movCMI.ST_Int = false;
            this.tp_movCMI.ST_LimpaCampo = true;
            this.tp_movCMI.ST_NotNull = false;
            this.tp_movCMI.ST_PrimaryKey = false;
            this.tp_movCMI.TabIndex = 48;
            this.tp_movCMI.TextOld = null;
            // 
            // bs_MovCmi
            // 
            this.bs_MovCmi.DataSource = typeof(CamadaDados.Fiscal.TList_CadMov_x_CMI);
            // 
            // tp_movMovimentacao
            // 
            this.tp_movMovimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.tp_movMovimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_movMovimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_movMovimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_MovCmi, "Tp_Mov_Movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movMovimentacao.Enabled = false;
            this.tp_movMovimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_movMovimentacao.Location = new System.Drawing.Point(452, 15);
            this.tp_movMovimentacao.Name = "tp_movMovimentacao";
            this.tp_movMovimentacao.NM_Alias = "";
            this.tp_movMovimentacao.NM_Campo = "tp_movMovimento";
            this.tp_movMovimentacao.NM_CampoBusca = "tp_movimento";
            this.tp_movMovimentacao.NM_Param = "@P_TP_MOVIMENTO";
            this.tp_movMovimentacao.QTD_Zero = 0;
            this.tp_movMovimentacao.ReadOnly = true;
            this.tp_movMovimentacao.Size = new System.Drawing.Size(39, 20);
            this.tp_movMovimentacao.ST_AutoInc = false;
            this.tp_movMovimentacao.ST_DisableAuto = false;
            this.tp_movMovimentacao.ST_Float = false;
            this.tp_movMovimentacao.ST_Gravar = false;
            this.tp_movMovimentacao.ST_Int = false;
            this.tp_movMovimentacao.ST_LimpaCampo = true;
            this.tp_movMovimentacao.ST_NotNull = false;
            this.tp_movMovimentacao.ST_PrimaryKey = false;
            this.tp_movMovimentacao.TabIndex = 47;
            this.tp_movMovimentacao.TextOld = null;
            // 
            // ds_Movimentacao
            // 
            this.ds_Movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_Movimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_Movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_Movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_MovCmi, "ds_movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_Movimentacao.Enabled = false;
            this.ds_Movimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_Movimentacao.Location = new System.Drawing.Point(205, 15);
            this.ds_Movimentacao.Name = "ds_Movimentacao";
            this.ds_Movimentacao.NM_Alias = "";
            this.ds_Movimentacao.NM_Campo = "ds_Movimentacao";
            this.ds_Movimentacao.NM_CampoBusca = "ds_Movimentacao";
            this.ds_Movimentacao.NM_Param = "";
            this.ds_Movimentacao.QTD_Zero = 0;
            this.ds_Movimentacao.ReadOnly = true;
            this.ds_Movimentacao.Size = new System.Drawing.Size(241, 20);
            this.ds_Movimentacao.ST_AutoInc = false;
            this.ds_Movimentacao.ST_DisableAuto = false;
            this.ds_Movimentacao.ST_Float = false;
            this.ds_Movimentacao.ST_Gravar = false;
            this.ds_Movimentacao.ST_Int = false;
            this.ds_Movimentacao.ST_LimpaCampo = true;
            this.ds_Movimentacao.ST_NotNull = false;
            this.ds_Movimentacao.ST_PrimaryKey = false;
            this.ds_Movimentacao.TabIndex = 46;
            this.ds_Movimentacao.TextOld = null;
            // 
            // ds_cmi
            // 
            this.ds_cmi.BackColor = System.Drawing.SystemColors.Window;
            this.ds_cmi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_cmi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_cmi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_MovCmi, "ds_cmi", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_cmi.Enabled = false;
            this.ds_cmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_cmi.Location = new System.Drawing.Point(242, 41);
            this.ds_cmi.Name = "ds_cmi";
            this.ds_cmi.NM_Alias = "";
            this.ds_cmi.NM_Campo = "ds_cmi";
            this.ds_cmi.NM_CampoBusca = "ds_cmi";
            this.ds_cmi.NM_Param = "";
            this.ds_cmi.QTD_Zero = 0;
            this.ds_cmi.ReadOnly = true;
            this.ds_cmi.Size = new System.Drawing.Size(204, 20);
            this.ds_cmi.ST_AutoInc = false;
            this.ds_cmi.ST_DisableAuto = false;
            this.ds_cmi.ST_Float = false;
            this.ds_cmi.ST_Gravar = false;
            this.ds_cmi.ST_Int = false;
            this.ds_cmi.ST_LimpaCampo = true;
            this.ds_cmi.ST_NotNull = false;
            this.ds_cmi.ST_PrimaryKey = false;
            this.ds_cmi.TabIndex = 45;
            this.ds_cmi.TextOld = null;
            // 
            // bb_Movimentacao
            // 
            this.bb_Movimentacao.Enabled = false;
            this.bb_Movimentacao.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_Movimentacao.Image = ((System.Drawing.Image)(resources.GetObject("bb_Movimentacao.Image")));
            this.bb_Movimentacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_Movimentacao.Location = new System.Drawing.Point(170, 15);
            this.bb_Movimentacao.Name = "bb_Movimentacao";
            this.bb_Movimentacao.Size = new System.Drawing.Size(30, 20);
            this.bb_Movimentacao.TabIndex = 41;
            this.bb_Movimentacao.UseVisualStyleBackColor = true;
            this.bb_Movimentacao.Click += new System.EventHandler(this.bb_Movimentacao_Click_1);
            // 
            // bb_cmi
            // 
            this.bb_cmi.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_cmi.Image = ((System.Drawing.Image)(resources.GetObject("bb_cmi.Image")));
            this.bb_cmi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_cmi.Location = new System.Drawing.Point(170, 41);
            this.bb_cmi.Name = "bb_cmi";
            this.bb_cmi.Size = new System.Drawing.Size(30, 20);
            this.bb_cmi.TabIndex = 44;
            this.bb_cmi.UseVisualStyleBackColor = true;
            this.bb_cmi.Click += new System.EventHandler(this.bb_cmi_Click_1);
            // 
            // LB_CD_Movimentacao
            // 
            this.LB_CD_Movimentacao.AutoSize = true;
            this.LB_CD_Movimentacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Movimentacao.Location = new System.Drawing.Point(7, 18);
            this.LB_CD_Movimentacao.Name = "LB_CD_Movimentacao";
            this.LB_CD_Movimentacao.Size = new System.Drawing.Size(82, 13);
            this.LB_CD_Movimentacao.TabIndex = 40;
            this.LB_CD_Movimentacao.Text = "Movimentación:";
            // 
            // LB_CD_CMI
            // 
            this.LB_CD_CMI.AutoSize = true;
            this.LB_CD_CMI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_CMI.Location = new System.Drawing.Point(70, 44);
            this.LB_CD_CMI.Name = "LB_CD_CMI";
            this.LB_CD_CMI.Size = new System.Drawing.Size(29, 13);
            this.LB_CD_CMI.TabIndex = 42;
            this.LB_CD_CMI.Text = "CMI:";
            // 
            // CD_Movimentacao
            // 
            this.CD_Movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Movimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_MovCmi, "CD_Movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Movimentacao.Enabled = false;
            this.CD_Movimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Movimentacao.Location = new System.Drawing.Point(104, 15);
            this.CD_Movimentacao.Name = "CD_Movimentacao";
            this.CD_Movimentacao.NM_Alias = "";
            this.CD_Movimentacao.NM_Campo = "CD_Movimentacao";
            this.CD_Movimentacao.NM_CampoBusca = "CD_Movimentacao";
            this.CD_Movimentacao.NM_Param = "@P_CD_MOVIMENTACAO";
            this.CD_Movimentacao.QTD_Zero = 0;
            this.CD_Movimentacao.Size = new System.Drawing.Size(65, 20);
            this.CD_Movimentacao.ST_AutoInc = false;
            this.CD_Movimentacao.ST_DisableAuto = false;
            this.CD_Movimentacao.ST_Float = false;
            this.CD_Movimentacao.ST_Gravar = true;
            this.CD_Movimentacao.ST_Int = false;
            this.CD_Movimentacao.ST_LimpaCampo = true;
            this.CD_Movimentacao.ST_NotNull = true;
            this.CD_Movimentacao.ST_PrimaryKey = true;
            this.CD_Movimentacao.TabIndex = 39;
            this.CD_Movimentacao.TextOld = null;
            this.CD_Movimentacao.Leave += new System.EventHandler(this.CD_Movimentacao_Leave);
            // 
            // CD_CMI
            // 
            this.CD_CMI.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CMI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_MovCmi, "CD_CMI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_CMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_CMI.Location = new System.Drawing.Point(104, 41);
            this.CD_CMI.Name = "CD_CMI";
            this.CD_CMI.NM_Alias = "";
            this.CD_CMI.NM_Campo = "CD_CMI";
            this.CD_CMI.NM_CampoBusca = "CD_CMI";
            this.CD_CMI.NM_Param = "@P_CD_CMI";
            this.CD_CMI.QTD_Zero = 0;
            this.CD_CMI.Size = new System.Drawing.Size(65, 20);
            this.CD_CMI.ST_AutoInc = false;
            this.CD_CMI.ST_DisableAuto = false;
            this.CD_CMI.ST_Float = false;
            this.CD_CMI.ST_Gravar = true;
            this.CD_CMI.ST_Int = false;
            this.CD_CMI.ST_LimpaCampo = true;
            this.CD_CMI.ST_NotNull = true;
            this.CD_CMI.ST_PrimaryKey = true;
            this.CD_CMI.TabIndex = 43;
            this.CD_CMI.TextOld = null;
            this.CD_CMI.Leave += new System.EventHandler(this.CD_CMI_Leave);
            // 
            // TFCadMovXCmi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 115);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.Name = "TFCadMovXCmi";
            this.Text = "Cadastro de Movimentação de cmi";
            this.Load += new System.EventHandler(this.TFCadMovXCmi_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_MovCmi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault tp_movCMI;
        private Componentes.EditDefault tp_movMovimentacao;
        private Componentes.EditDefault ds_Movimentacao;
        private Componentes.EditDefault ds_cmi;
        public System.Windows.Forms.Button bb_Movimentacao;
        public System.Windows.Forms.Button bb_cmi;
        private System.Windows.Forms.Label LB_CD_Movimentacao;
        private System.Windows.Forms.Label LB_CD_CMI;
        private Componentes.EditDefault CD_Movimentacao;
        private Componentes.EditDefault CD_CMI;
        private System.Windows.Forms.BindingSource bs_MovCmi;
        private System.Windows.Forms.Button button2;
    }
}