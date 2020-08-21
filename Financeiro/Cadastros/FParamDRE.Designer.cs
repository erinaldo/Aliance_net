namespace Financeiro.Cadastros
{
    partial class TFParamDRE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFParamDRE));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.operador = new Componentes.ComboBoxDefault(this.components);
            this.bsParamDRE = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tp_conta = new Componentes.ComboBoxDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_parampai = new System.Windows.Forms.Button();
            this.ds_parampai = new Componentes.EditDefault(this.components);
            this.id_parampai = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ds_param = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsParamDRE)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(446, 43);
            this.barraMenu.TabIndex = 12;
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
            this.pDados.Controls.Add(this.operador);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.tp_conta);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.bb_parampai);
            this.pDados.Controls.Add(this.ds_parampai);
            this.pDados.Controls.Add(this.id_parampai);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_param);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(446, 134);
            this.pDados.TabIndex = 13;
            // 
            // operador
            // 
            this.operador.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsParamDRE, "Operador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.operador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operador.FormattingEnabled = true;
            this.operador.Location = new System.Drawing.Point(192, 99);
            this.operador.Name = "operador";
            this.operador.NM_Alias = "";
            this.operador.NM_Campo = "";
            this.operador.NM_Param = "";
            this.operador.Size = new System.Drawing.Size(174, 21);
            this.operador.ST_Gravar = true;
            this.operador.ST_LimparCampo = true;
            this.operador.ST_NotNull = true;
            this.operador.TabIndex = 4;
            // 
            // bsParamDRE
            // 
            this.bsParamDRE.DataSource = typeof(CamadaDados.Financeiro.DRE.TList_paramDRE);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Operador";
            // 
            // tp_conta
            // 
            this.tp_conta.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsParamDRE, "Tp_conta", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_conta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_conta.FormattingEnabled = true;
            this.tp_conta.Location = new System.Drawing.Point(12, 99);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tipo Parâmetro";
            // 
            // bb_parampai
            // 
            this.bb_parampai.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_parampai.Image = ((System.Drawing.Image)(resources.GetObject("bb_parampai.Image")));
            this.bb_parampai.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_parampai.Location = new System.Drawing.Point(78, 59);
            this.bb_parampai.Name = "bb_parampai";
            this.bb_parampai.Size = new System.Drawing.Size(30, 20);
            this.bb_parampai.TabIndex = 2;
            this.bb_parampai.UseVisualStyleBackColor = true;
            this.bb_parampai.Click += new System.EventHandler(this.bb_parampai_Click);
            // 
            // ds_parampai
            // 
            this.ds_parampai.BackColor = System.Drawing.SystemColors.Window;
            this.ds_parampai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_parampai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_parampai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsParamDRE, "Ds_parampai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_parampai.Enabled = false;
            this.ds_parampai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_parampai.Location = new System.Drawing.Point(114, 60);
            this.ds_parampai.Name = "ds_parampai";
            this.ds_parampai.NM_Alias = "";
            this.ds_parampai.NM_Campo = "ds_param";
            this.ds_parampai.NM_CampoBusca = "ds_param";
            this.ds_parampai.NM_Param = "@P_CONTA_CTBPAI";
            this.ds_parampai.QTD_Zero = 0;
            this.ds_parampai.Size = new System.Drawing.Size(317, 20);
            this.ds_parampai.ST_AutoInc = false;
            this.ds_parampai.ST_DisableAuto = true;
            this.ds_parampai.ST_Float = false;
            this.ds_parampai.ST_Gravar = false;
            this.ds_parampai.ST_Int = false;
            this.ds_parampai.ST_LimpaCampo = true;
            this.ds_parampai.ST_NotNull = false;
            this.ds_parampai.ST_PrimaryKey = false;
            this.ds_parampai.TabIndex = 12;
            this.ds_parampai.TextOld = null;
            // 
            // id_parampai
            // 
            this.id_parampai.BackColor = System.Drawing.SystemColors.Window;
            this.id_parampai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_parampai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_parampai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsParamDRE, "Id_parampaistr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_parampai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_parampai.Location = new System.Drawing.Point(12, 60);
            this.id_parampai.MaxLength = 6;
            this.id_parampai.Name = "id_parampai";
            this.id_parampai.NM_Alias = "a";
            this.id_parampai.NM_Campo = "id_param";
            this.id_parampai.NM_CampoBusca = "id_param";
            this.id_parampai.NM_Param = "@P_CD_CONTA_CTBPAI";
            this.id_parampai.QTD_Zero = 0;
            this.id_parampai.Size = new System.Drawing.Size(60, 20);
            this.id_parampai.ST_AutoInc = false;
            this.id_parampai.ST_DisableAuto = false;
            this.id_parampai.ST_Float = false;
            this.id_parampai.ST_Gravar = true;
            this.id_parampai.ST_Int = true;
            this.id_parampai.ST_LimpaCampo = true;
            this.id_parampai.ST_NotNull = false;
            this.id_parampai.ST_PrimaryKey = false;
            this.id_parampai.TabIndex = 1;
            this.id_parampai.TextOld = null;
            this.id_parampai.Leave += new System.EventHandler(this.id_parampai_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-73, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Conta Pai:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parâmetro Pai";
            // 
            // ds_param
            // 
            this.ds_param.BackColor = System.Drawing.SystemColors.Window;
            this.ds_param.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_param.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_param.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsParamDRE, "ds_param", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_param.Location = new System.Drawing.Point(12, 21);
            this.ds_param.Name = "ds_param";
            this.ds_param.NM_Alias = "";
            this.ds_param.NM_Campo = "";
            this.ds_param.NM_CampoBusca = "";
            this.ds_param.NM_Param = "";
            this.ds_param.QTD_Zero = 0;
            this.ds_param.Size = new System.Drawing.Size(419, 20);
            this.ds_param.ST_AutoInc = false;
            this.ds_param.ST_DisableAuto = false;
            this.ds_param.ST_Float = false;
            this.ds_param.ST_Gravar = false;
            this.ds_param.ST_Int = false;
            this.ds_param.ST_LimpaCampo = true;
            this.ds_param.ST_NotNull = false;
            this.ds_param.ST_PrimaryKey = false;
            this.ds_param.TabIndex = 0;
            this.ds_param.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parâmetro";
            // 
            // TFParamDRE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 177);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFParamDRE";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parâmetros DRE";
            this.Load += new System.EventHandler(this.TFParamDRE_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFParamDRE_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsParamDRE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.BindingSource bsParamDRE;
        private Componentes.PanelDados pDados;
        private Componentes.ComboBoxDefault operador;
        private System.Windows.Forms.Label label5;
        private Componentes.ComboBoxDefault tp_conta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_parampai;
        private Componentes.EditDefault ds_parampai;
        private Componentes.EditDefault id_parampai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_param;
        private System.Windows.Forms.Label label1;
    }
}