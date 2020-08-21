namespace Contabil.Cadastros
{
    partial class TFPlanoContas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFPlanoContas));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.st_contadeducao = new Componentes.CheckBoxDefault(this.components);
            this.bsConta = new System.Windows.Forms.BindingSource(this.components);
            this.natureza = new Componentes.ComboBoxDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tp_conta = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_contactbpai = new System.Windows.Forms.Button();
            this.ds_conta_ctbpai = new Componentes.EditDefault(this.components);
            this.cd_contactbpai = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_contactb = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConta)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(650, 43);
            this.barraMenu.TabIndex = 16;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.st_contadeducao);
            this.pDados.Controls.Add(this.natureza);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.tp_conta);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.bb_contactbpai);
            this.pDados.Controls.Add(this.ds_conta_ctbpai);
            this.pDados.Controls.Add(this.cd_contactbpai);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_contactb);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(650, 83);
            this.pDados.TabIndex = 0;
            // 
            // st_contadeducao
            // 
            this.st_contadeducao.AutoSize = true;
            this.st_contadeducao.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.st_contadeducao.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsConta, "St_deducaobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_contadeducao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_contadeducao.Location = new System.Drawing.Point(531, 57);
            this.st_contadeducao.Name = "st_contadeducao";
            this.st_contadeducao.NM_Alias = "";
            this.st_contadeducao.NM_Campo = "";
            this.st_contadeducao.NM_Param = "";
            this.st_contadeducao.Size = new System.Drawing.Size(114, 17);
            this.st_contadeducao.ST_Gravar = false;
            this.st_contadeducao.ST_LimparCampo = true;
            this.st_contadeducao.ST_NotNull = false;
            this.st_contadeducao.TabIndex = 5;
            this.st_contadeducao.Text = "Conta Dedução";
            this.st_contadeducao.UseVisualStyleBackColor = true;
            this.st_contadeducao.Vl_False = "";
            this.st_contadeducao.Vl_True = "";
            // 
            // bsConta
            // 
            this.bsConta.DataSource = typeof(CamadaDados.Contabil.Cadastro.TList_CadPlanoContas);
            // 
            // natureza
            // 
            this.natureza.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsConta, "Natureza", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.natureza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.natureza.FormattingEnabled = true;
            this.natureza.Location = new System.Drawing.Point(345, 55);
            this.natureza.Name = "natureza";
            this.natureza.NM_Alias = "";
            this.natureza.NM_Campo = "";
            this.natureza.NM_Param = "";
            this.natureza.Size = new System.Drawing.Size(180, 21);
            this.natureza.ST_Gravar = true;
            this.natureza.ST_LimparCampo = true;
            this.natureza.ST_NotNull = true;
            this.natureza.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Natureza:";
            // 
            // tp_conta
            // 
            this.tp_conta.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsConta, "Tp_conta", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_conta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_conta.FormattingEnabled = true;
            this.tp_conta.Location = new System.Drawing.Point(106, 55);
            this.tp_conta.Name = "tp_conta";
            this.tp_conta.NM_Alias = "";
            this.tp_conta.NM_Campo = "";
            this.tp_conta.NM_Param = "";
            this.tp_conta.Size = new System.Drawing.Size(174, 21);
            this.tp_conta.ST_Gravar = true;
            this.tp_conta.ST_LimparCampo = true;
            this.tp_conta.ST_NotNull = true;
            this.tp_conta.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo Conta:";
            // 
            // bb_contactbpai
            // 
            this.bb_contactbpai.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_contactbpai.Image = ((System.Drawing.Image)(resources.GetObject("bb_contactbpai.Image")));
            this.bb_contactbpai.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contactbpai.Location = new System.Drawing.Point(172, 28);
            this.bb_contactbpai.Name = "bb_contactbpai";
            this.bb_contactbpai.Size = new System.Drawing.Size(30, 20);
            this.bb_contactbpai.TabIndex = 2;
            this.bb_contactbpai.UseVisualStyleBackColor = true;
            this.bb_contactbpai.Click += new System.EventHandler(this.bb_contactbpai_Click);
            // 
            // ds_conta_ctbpai
            // 
            this.ds_conta_ctbpai.BackColor = System.Drawing.SystemColors.Window;
            this.ds_conta_ctbpai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_conta_ctbpai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_conta_ctbpai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConta, "Ds_contactb_pai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_conta_ctbpai.Enabled = false;
            this.ds_conta_ctbpai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_conta_ctbpai.Location = new System.Drawing.Point(208, 29);
            this.ds_conta_ctbpai.Name = "ds_conta_ctbpai";
            this.ds_conta_ctbpai.NM_Alias = "";
            this.ds_conta_ctbpai.NM_Campo = "DS_Conta_CTBPai";
            this.ds_conta_ctbpai.NM_CampoBusca = "DS_ContaCTB";
            this.ds_conta_ctbpai.NM_Param = "@P_CONTA_CTBPAI";
            this.ds_conta_ctbpai.QTD_Zero = 0;
            this.ds_conta_ctbpai.Size = new System.Drawing.Size(437, 20);
            this.ds_conta_ctbpai.ST_AutoInc = false;
            this.ds_conta_ctbpai.ST_DisableAuto = true;
            this.ds_conta_ctbpai.ST_Float = false;
            this.ds_conta_ctbpai.ST_Gravar = false;
            this.ds_conta_ctbpai.ST_Int = false;
            this.ds_conta_ctbpai.ST_LimpaCampo = true;
            this.ds_conta_ctbpai.ST_NotNull = false;
            this.ds_conta_ctbpai.ST_PrimaryKey = false;
            this.ds_conta_ctbpai.TabIndex = 8;
            this.ds_conta_ctbpai.TextOld = null;
            // 
            // cd_contactbpai
            // 
            this.cd_contactbpai.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contactbpai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contactbpai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contactbpai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConta, "Cd_conta_ctbpaistr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contactbpai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contactbpai.Location = new System.Drawing.Point(106, 29);
            this.cd_contactbpai.MaxLength = 6;
            this.cd_contactbpai.Name = "cd_contactbpai";
            this.cd_contactbpai.NM_Alias = "a";
            this.cd_contactbpai.NM_Campo = "CD_Conta_CTBPai";
            this.cd_contactbpai.NM_CampoBusca = "CD_Conta_CTB";
            this.cd_contactbpai.NM_Param = "@P_CD_CONTA_CTBPAI";
            this.cd_contactbpai.QTD_Zero = 0;
            this.cd_contactbpai.Size = new System.Drawing.Size(60, 20);
            this.cd_contactbpai.ST_AutoInc = false;
            this.cd_contactbpai.ST_DisableAuto = false;
            this.cd_contactbpai.ST_Float = false;
            this.cd_contactbpai.ST_Gravar = true;
            this.cd_contactbpai.ST_Int = true;
            this.cd_contactbpai.ST_LimpaCampo = true;
            this.cd_contactbpai.ST_NotNull = false;
            this.cd_contactbpai.ST_PrimaryKey = false;
            this.cd_contactbpai.TabIndex = 1;
            this.cd_contactbpai.TextOld = null;
            this.cd_contactbpai.Leave += new System.EventHandler(this.cd_contactbpai_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Conta Pai:";
            // 
            // ds_contactb
            // 
            this.ds_contactb.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contactb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contactb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contactb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConta, "Ds_contactb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contactb.Location = new System.Drawing.Point(106, 3);
            this.ds_contactb.Name = "ds_contactb";
            this.ds_contactb.NM_Alias = "";
            this.ds_contactb.NM_Campo = "";
            this.ds_contactb.NM_CampoBusca = "";
            this.ds_contactb.NM_Param = "";
            this.ds_contactb.QTD_Zero = 0;
            this.ds_contactb.Size = new System.Drawing.Size(539, 20);
            this.ds_contactb.ST_AutoInc = false;
            this.ds_contactb.ST_DisableAuto = false;
            this.ds_contactb.ST_Float = false;
            this.ds_contactb.ST_Gravar = true;
            this.ds_contactb.ST_Int = false;
            this.ds_contactb.ST_LimpaCampo = true;
            this.ds_contactb.ST_NotNull = true;
            this.ds_contactb.ST_PrimaryKey = false;
            this.ds_contactb.TabIndex = 0;
            this.ds_contactb.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição Conta:";
            // 
            // TFPlanoContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 126);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFPlanoContas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano Contas Contabeis";
            this.Load += new System.EventHandler(this.TFPlanoContas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFPlanoContas_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_contactb;
        private System.Windows.Forms.BindingSource bsConta;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_conta_ctbpai;
        private Componentes.EditDefault cd_contactbpai;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault natureza;
        private System.Windows.Forms.Label label4;
        private Componentes.ComboBoxDefault tp_conta;
        private Componentes.CheckBoxDefault st_contadeducao;
        private System.Windows.Forms.Button bb_contactbpai;
    }
}