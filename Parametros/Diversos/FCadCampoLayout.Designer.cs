namespace Parametros.Diversos
{
    partial class FCadCampoLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadCampoLayout));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.comboBoxDefault2 = new Componentes.ComboBoxDefault(this.components);
            this.bsCampo = new System.Windows.Forms.BindingSource(this.components);
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoHora = new Componentes.ComboBoxDefault(this.components);
            this.editFloat3 = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.editFloat2 = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.editFloat4 = new Componentes.EditFloat(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCampo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat4)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(440, 43);
            this.barraMenu.TabIndex = 537;
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.editFloat4);
            this.panelDados1.Controls.Add(this.comboBoxDefault2);
            this.panelDados1.Controls.Add(this.editFloat1);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Controls.Add(this.label6);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.cbTipoHora);
            this.panelDados1.Controls.Add(this.editFloat3);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.editFloat2);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.editDefault1);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(440, 197);
            this.panelDados1.TabIndex = 538;
            // 
            // comboBoxDefault2
            // 
            this.comboBoxDefault2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCampo, "ds_campo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCampo, "ds_campo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxDefault2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDefault2.FormattingEnabled = true;
            this.comboBoxDefault2.Location = new System.Drawing.Point(118, 26);
            this.comboBoxDefault2.Name = "comboBoxDefault2";
            this.comboBoxDefault2.NM_Alias = "";
            this.comboBoxDefault2.NM_Campo = "";
            this.comboBoxDefault2.NM_Param = "";
            this.comboBoxDefault2.Size = new System.Drawing.Size(310, 21);
            this.comboBoxDefault2.ST_Gravar = false;
            this.comboBoxDefault2.ST_LimparCampo = true;
            this.comboBoxDefault2.ST_NotNull = false;
            this.comboBoxDefault2.TabIndex = 66;
            // 
            // bsCampo
            // 
            this.bsCampo.DataSource = typeof(CamadaDados.Diversos.TList_CamposEtiqueta);
            // 
            // editFloat1
            // 
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCampo, "coluna", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat1.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat1.Location = new System.Drawing.Point(224, 70);
            this.editFloat1.Maximum = new decimal(new int[] {
            -1593835520,
            466537709,
            54210,
            0});
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.Size = new System.Drawing.Size(100, 20);
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = false;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = false;
            this.editFloat1.ST_PrimaryKey = false;
            this.editFloat1.TabIndex = 65;
            this.editFloat1.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Coluna";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "Tipo Fonte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Tipo Campo";
            // 
            // cbTipoHora
            // 
            this.cbTipoHora.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCampo, "St_campo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbTipoHora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCampo, "Status", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbTipoHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoHora.FormattingEnabled = true;
            this.cbTipoHora.Location = new System.Drawing.Point(12, 111);
            this.cbTipoHora.Name = "cbTipoHora";
            this.cbTipoHora.NM_Alias = "";
            this.cbTipoHora.NM_Campo = "";
            this.cbTipoHora.NM_Param = "";
            this.cbTipoHora.Size = new System.Drawing.Size(390, 21);
            this.cbTipoHora.ST_Gravar = false;
            this.cbTipoHora.ST_LimparCampo = true;
            this.cbTipoHora.ST_NotNull = false;
            this.cbTipoHora.TabIndex = 60;
            // 
            // editFloat3
            // 
            this.editFloat3.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCampo, "posy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat3.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat3.Location = new System.Drawing.Point(118, 70);
            this.editFloat3.Maximum = new decimal(new int[] {
            -1593835520,
            466537709,
            54210,
            0});
            this.editFloat3.Name = "editFloat3";
            this.editFloat3.NM_Alias = "";
            this.editFloat3.NM_Campo = "";
            this.editFloat3.NM_Param = "";
            this.editFloat3.Operador = "";
            this.editFloat3.Size = new System.Drawing.Size(100, 20);
            this.editFloat3.ST_AutoInc = false;
            this.editFloat3.ST_DisableAuto = false;
            this.editFloat3.ST_Gravar = false;
            this.editFloat3.ST_LimparCampo = true;
            this.editFloat3.ST_NotNull = false;
            this.editFloat3.ST_PrimaryKey = false;
            this.editFloat3.TabIndex = 59;
            this.editFloat3.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Y";
            // 
            // editFloat2
            // 
            this.editFloat2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCampo, "posx", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat2.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat2.Location = new System.Drawing.Point(12, 70);
            this.editFloat2.Maximum = new decimal(new int[] {
            -469762048,
            -590869294,
            5421010,
            0});
            this.editFloat2.Name = "editFloat2";
            this.editFloat2.NM_Alias = "";
            this.editFloat2.NM_Campo = "";
            this.editFloat2.NM_Param = "";
            this.editFloat2.Operador = "";
            this.editFloat2.Size = new System.Drawing.Size(100, 20);
            this.editFloat2.ST_AutoInc = false;
            this.editFloat2.ST_DisableAuto = false;
            this.editFloat2.ST_Gravar = false;
            this.editFloat2.ST_LimparCampo = true;
            this.editFloat2.ST_NotNull = false;
            this.editFloat2.ST_PrimaryKey = false;
            this.editFloat2.TabIndex = 57;
            this.editFloat2.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Campo";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCampo, "id_campo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Location = new System.Drawing.Point(12, 27);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(100, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 52;
            this.editDefault1.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Id. Campo";
            // 
            // editFloat4
            // 
            this.editFloat4.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCampo, "Tp_Fonte", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat4.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat4.Location = new System.Drawing.Point(12, 153);
            this.editFloat4.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.editFloat4.Name = "editFloat4";
            this.editFloat4.NM_Alias = "";
            this.editFloat4.NM_Campo = "";
            this.editFloat4.NM_Param = "";
            this.editFloat4.Operador = "";
            this.editFloat4.Size = new System.Drawing.Size(390, 20);
            this.editFloat4.ST_AutoInc = false;
            this.editFloat4.ST_DisableAuto = false;
            this.editFloat4.ST_Gravar = false;
            this.editFloat4.ST_LimparCampo = true;
            this.editFloat4.ST_NotNull = false;
            this.editFloat4.ST_PrimaryKey = false;
            this.editFloat4.TabIndex = 67;
            this.editFloat4.ThousandsSeparator = true;
            // 
            // FCadCampoLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 240);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FCadCampoLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCadCampoLayout";
            this.Load += new System.EventHandler(this.FCadCampoLayout_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCadCampoLayout_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCampo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditFloat editFloat3;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat editFloat2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Componentes.ComboBoxDefault cbTipoHora;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bsCampo;
        private Componentes.EditFloat editFloat1;
        private System.Windows.Forms.Label label7;
        private Componentes.ComboBoxDefault comboBoxDefault2;
        private Componentes.EditFloat editFloat4;
    }
}