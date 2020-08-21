namespace Contabil.Cadastros
{
    partial class FCad_PlanoReferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCad_PlanoReferencia));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.comboBoxDefault1 = new Componentes.ComboBoxDefault(this.components);
            this.bsPlanoReferencia = new System.Windows.Forms.BindingSource(this.components);
            this.cbTipoHora = new Componentes.ComboBoxDefault(this.components);
            this.editData2 = new Componentes.EditData(this.components);
            this.editData1 = new Componentes.EditData(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.editDefault4 = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_contactb = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanoReferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(359, 43);
            this.barraMenu.TabIndex = 17;
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.comboBoxDefault1);
            this.panelDados1.Controls.Add(this.cbTipoHora);
            this.panelDados1.Controls.Add(this.editData2);
            this.panelDados1.Controls.Add(this.editData1);
            this.panelDados1.Controls.Add(this.label6);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.editDefault4);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.editDefault1);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.ds_contactb);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(359, 118);
            this.panelDados1.TabIndex = 18;
            // 
            // comboBoxDefault1
            // 
            this.comboBoxDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlanoReferencia, "Nat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxDefault1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDefault1.FormattingEnabled = true;
            this.comboBoxDefault1.Location = new System.Drawing.Point(228, 55);
            this.comboBoxDefault1.Name = "comboBoxDefault1";
            this.comboBoxDefault1.NM_Alias = "";
            this.comboBoxDefault1.NM_Campo = "";
            this.comboBoxDefault1.NM_Param = "";
            this.comboBoxDefault1.Size = new System.Drawing.Size(119, 21);
            this.comboBoxDefault1.ST_Gravar = false;
            this.comboBoxDefault1.ST_LimparCampo = true;
            this.comboBoxDefault1.ST_NotNull = false;
            this.comboBoxDefault1.TabIndex = 16;
            // 
            // bsPlanoReferencia
            // 
            this.bsPlanoReferencia.DataSource = typeof(CamadaDados.Contabil.Cadastro.TList_PlanoReferencial);
            // 
            // cbTipoHora
            // 
            this.cbTipoHora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlanoReferencia, "Tipo_conta", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbTipoHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoHora.FormattingEnabled = true;
            this.cbTipoHora.Location = new System.Drawing.Point(228, 29);
            this.cbTipoHora.Name = "cbTipoHora";
            this.cbTipoHora.NM_Alias = "";
            this.cbTipoHora.NM_Campo = "";
            this.cbTipoHora.NM_Param = "";
            this.cbTipoHora.Size = new System.Drawing.Size(119, 21);
            this.cbTipoHora.ST_Gravar = false;
            this.cbTipoHora.ST_LimparCampo = true;
            this.cbTipoHora.ST_NotNull = false;
            this.cbTipoHora.TabIndex = 15;
            // 
            // editData2
            // 
            this.editData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editData2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlanoReferencia, "Dt_fin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editData2.Location = new System.Drawing.Point(228, 82);
            this.editData2.Mask = "00/00/0000";
            this.editData2.Name = "editData2";
            this.editData2.NM_Alias = "";
            this.editData2.NM_Campo = "dt_final";
            this.editData2.NM_CampoBusca = "dt_final";
            this.editData2.NM_Param = "@P_DT_FINAL";
            this.editData2.Operador = "";
            this.editData2.Size = new System.Drawing.Size(119, 20);
            this.editData2.ST_Gravar = false;
            this.editData2.ST_LimpaCampo = true;
            this.editData2.ST_NotNull = false;
            this.editData2.ST_PrimaryKey = false;
            this.editData2.TabIndex = 14;
            // 
            // editData1
            // 
            this.editData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editData1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlanoReferencia, "Dt_ini", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editData1.Location = new System.Drawing.Point(58, 82);
            this.editData1.Mask = "00/00/0000";
            this.editData1.Name = "editData1";
            this.editData1.NM_Alias = "";
            this.editData1.NM_Campo = "dt_inicio";
            this.editData1.NM_CampoBusca = "dt_inicio";
            this.editData1.NM_Param = "@P_DT_INICIO";
            this.editData1.Operador = "";
            this.editData1.Size = new System.Drawing.Size(100, 20);
            this.editData1.ST_Gravar = false;
            this.editData1.ST_LimpaCampo = true;
            this.editData1.ST_NotNull = false;
            this.editData1.ST_PrimaryKey = false;
            this.editData1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Data Fim:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Data Ini:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Natureza:";
            // 
            // editDefault4
            // 
            this.editDefault4.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlanoReferencia, "Nivel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault4.Location = new System.Drawing.Point(58, 56);
            this.editDefault4.Name = "editDefault4";
            this.editDefault4.NM_Alias = "";
            this.editDefault4.NM_Campo = "Nivel";
            this.editDefault4.NM_CampoBusca = "Nivel";
            this.editDefault4.NM_Param = "@P_NIVEL";
            this.editDefault4.QTD_Zero = 0;
            this.editDefault4.Size = new System.Drawing.Size(100, 20);
            this.editDefault4.ST_AutoInc = false;
            this.editDefault4.ST_DisableAuto = false;
            this.editDefault4.ST_Float = false;
            this.editDefault4.ST_Gravar = true;
            this.editDefault4.ST_Int = false;
            this.editDefault4.ST_LimpaCampo = true;
            this.editDefault4.ST_NotNull = true;
            this.editDefault4.ST_PrimaryKey = false;
            this.editDefault4.TabIndex = 7;
            this.editDefault4.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nivel:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo Conta:";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlanoReferencia, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Location = new System.Drawing.Point(58, 30);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "Nome";
            this.editDefault1.NM_CampoBusca = "Nome";
            this.editDefault1.NM_Param = "@P_NOME";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(100, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = true;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = true;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 3;
            this.editDefault1.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Conta:";
            // 
            // ds_contactb
            // 
            this.ds_contactb.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contactb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contactb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contactb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlanoReferencia, "Cd_referencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contactb.Location = new System.Drawing.Point(58, 4);
            this.ds_contactb.Name = "ds_contactb";
            this.ds_contactb.NM_Alias = "";
            this.ds_contactb.NM_Campo = "Codigo";
            this.ds_contactb.NM_CampoBusca = "Codigo";
            this.ds_contactb.NM_Param = "@P_CODIGO";
            this.ds_contactb.QTD_Zero = 0;
            this.ds_contactb.Size = new System.Drawing.Size(100, 20);
            this.ds_contactb.ST_AutoInc = false;
            this.ds_contactb.ST_DisableAuto = false;
            this.ds_contactb.ST_Float = false;
            this.ds_contactb.ST_Gravar = true;
            this.ds_contactb.ST_Int = false;
            this.ds_contactb.ST_LimpaCampo = true;
            this.ds_contactb.ST_NotNull = true;
            this.ds_contactb.ST_PrimaryKey = false;
            this.ds_contactb.TabIndex = 1;
            this.ds_contactb.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código:";
            // 
            // FCad_PlanoReferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 161);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FCad_PlanoReferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCad_PlanoReferencia";
            this.Load += new System.EventHandler(this.FCad_PlanoReferencia_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCad_PlanoReferencia_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanoReferencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingSource bsPlanoReferencia;
        private Componentes.EditDefault ds_contactb;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault editDefault4;
        private System.Windows.Forms.Label label5;
        private Componentes.EditData editData2;
        private Componentes.EditData editData1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Componentes.ComboBoxDefault cbTipoHora;
        private Componentes.ComboBoxDefault comboBoxDefault1;
    }
}