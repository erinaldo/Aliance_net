namespace Faturamento
{
    partial class TFConvertUnid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFConvertUnid));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cd_unidade_orig = new Componentes.EditDefault(this.components);
            this.ds_unidade_orig = new Componentes.EditDefault(this.components);
            this.ds_unidade_dest = new Componentes.EditDefault(this.components);
            this.cd_unidade_dest = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.valor = new Componentes.EditFloat(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.rbMultiplica = new Componentes.RadioButtonDefault(this.components);
            this.rbDivide = new Componentes.RadioButtonDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).BeginInit();
            this.radioGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(473, 43);
            this.barraMenu.TabIndex = 2;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.radioGroup1);
            this.panelDados1.Controls.Add(this.valor);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.ds_unidade_dest);
            this.panelDados1.Controls.Add(this.cd_unidade_dest);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.ds_unidade_orig);
            this.panelDados1.Controls.Add(this.cd_unidade_orig);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(473, 133);
            this.panelDados1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unidade Origem";
            // 
            // cd_unidade_orig
            // 
            this.cd_unidade_orig.BackColor = System.Drawing.SystemColors.Window;
            this.cd_unidade_orig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_unidade_orig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidade_orig.Enabled = false;
            this.cd_unidade_orig.Location = new System.Drawing.Point(12, 22);
            this.cd_unidade_orig.Name = "cd_unidade_orig";
            this.cd_unidade_orig.NM_Alias = "";
            this.cd_unidade_orig.NM_Campo = "";
            this.cd_unidade_orig.NM_CampoBusca = "";
            this.cd_unidade_orig.NM_Param = "";
            this.cd_unidade_orig.QTD_Zero = 0;
            this.cd_unidade_orig.Size = new System.Drawing.Size(46, 20);
            this.cd_unidade_orig.ST_AutoInc = false;
            this.cd_unidade_orig.ST_DisableAuto = false;
            this.cd_unidade_orig.ST_Float = false;
            this.cd_unidade_orig.ST_Gravar = false;
            this.cd_unidade_orig.ST_Int = false;
            this.cd_unidade_orig.ST_LimpaCampo = true;
            this.cd_unidade_orig.ST_NotNull = false;
            this.cd_unidade_orig.ST_PrimaryKey = false;
            this.cd_unidade_orig.TabIndex = 1;
            this.cd_unidade_orig.TextOld = null;
            // 
            // ds_unidade_orig
            // 
            this.ds_unidade_orig.BackColor = System.Drawing.SystemColors.Window;
            this.ds_unidade_orig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_unidade_orig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_unidade_orig.Enabled = false;
            this.ds_unidade_orig.Location = new System.Drawing.Point(64, 22);
            this.ds_unidade_orig.Name = "ds_unidade_orig";
            this.ds_unidade_orig.NM_Alias = "";
            this.ds_unidade_orig.NM_Campo = "";
            this.ds_unidade_orig.NM_CampoBusca = "";
            this.ds_unidade_orig.NM_Param = "";
            this.ds_unidade_orig.QTD_Zero = 0;
            this.ds_unidade_orig.Size = new System.Drawing.Size(397, 20);
            this.ds_unidade_orig.ST_AutoInc = false;
            this.ds_unidade_orig.ST_DisableAuto = false;
            this.ds_unidade_orig.ST_Float = false;
            this.ds_unidade_orig.ST_Gravar = false;
            this.ds_unidade_orig.ST_Int = false;
            this.ds_unidade_orig.ST_LimpaCampo = true;
            this.ds_unidade_orig.ST_NotNull = false;
            this.ds_unidade_orig.ST_PrimaryKey = false;
            this.ds_unidade_orig.TabIndex = 2;
            this.ds_unidade_orig.TextOld = null;
            // 
            // ds_unidade_dest
            // 
            this.ds_unidade_dest.BackColor = System.Drawing.SystemColors.Window;
            this.ds_unidade_dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_unidade_dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_unidade_dest.Enabled = false;
            this.ds_unidade_dest.Location = new System.Drawing.Point(64, 61);
            this.ds_unidade_dest.Name = "ds_unidade_dest";
            this.ds_unidade_dest.NM_Alias = "";
            this.ds_unidade_dest.NM_Campo = "";
            this.ds_unidade_dest.NM_CampoBusca = "";
            this.ds_unidade_dest.NM_Param = "";
            this.ds_unidade_dest.QTD_Zero = 0;
            this.ds_unidade_dest.Size = new System.Drawing.Size(397, 20);
            this.ds_unidade_dest.ST_AutoInc = false;
            this.ds_unidade_dest.ST_DisableAuto = false;
            this.ds_unidade_dest.ST_Float = false;
            this.ds_unidade_dest.ST_Gravar = false;
            this.ds_unidade_dest.ST_Int = false;
            this.ds_unidade_dest.ST_LimpaCampo = true;
            this.ds_unidade_dest.ST_NotNull = false;
            this.ds_unidade_dest.ST_PrimaryKey = false;
            this.ds_unidade_dest.TabIndex = 5;
            this.ds_unidade_dest.TextOld = null;
            // 
            // cd_unidade_dest
            // 
            this.cd_unidade_dest.BackColor = System.Drawing.SystemColors.Window;
            this.cd_unidade_dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_unidade_dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidade_dest.Enabled = false;
            this.cd_unidade_dest.Location = new System.Drawing.Point(12, 61);
            this.cd_unidade_dest.Name = "cd_unidade_dest";
            this.cd_unidade_dest.NM_Alias = "";
            this.cd_unidade_dest.NM_Campo = "";
            this.cd_unidade_dest.NM_CampoBusca = "";
            this.cd_unidade_dest.NM_Param = "";
            this.cd_unidade_dest.QTD_Zero = 0;
            this.cd_unidade_dest.Size = new System.Drawing.Size(46, 20);
            this.cd_unidade_dest.ST_AutoInc = false;
            this.cd_unidade_dest.ST_DisableAuto = false;
            this.cd_unidade_dest.ST_Float = false;
            this.cd_unidade_dest.ST_Gravar = false;
            this.cd_unidade_dest.ST_Int = false;
            this.cd_unidade_dest.ST_LimpaCampo = true;
            this.cd_unidade_dest.ST_NotNull = false;
            this.cd_unidade_dest.ST_PrimaryKey = false;
            this.cd_unidade_dest.TabIndex = 4;
            this.cd_unidade_dest.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Unidade Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valor";
            // 
            // valor
            // 
            this.valor.DecimalPlaces = 5;
            this.valor.Location = new System.Drawing.Point(12, 100);
            this.valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.valor.Name = "valor";
            this.valor.NM_Alias = "";
            this.valor.NM_Campo = "";
            this.valor.NM_Param = "";
            this.valor.Operador = "";
            this.valor.Size = new System.Drawing.Size(120, 20);
            this.valor.ST_AutoInc = false;
            this.valor.ST_DisableAuto = false;
            this.valor.ST_Gravar = false;
            this.valor.ST_LimparCampo = true;
            this.valor.ST_NotNull = false;
            this.valor.ST_PrimaryKey = false;
            this.valor.TabIndex = 7;
            this.valor.ThousandsSeparator = true;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.rbDivide);
            this.radioGroup1.Controls.Add(this.rbMultiplica);
            this.radioGroup1.Location = new System.Drawing.Point(138, 84);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(139, 36);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 8;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Operador";
            // 
            // rbMultiplica
            // 
            this.rbMultiplica.AutoSize = true;
            this.rbMultiplica.Checked = true;
            this.rbMultiplica.Location = new System.Drawing.Point(6, 13);
            this.rbMultiplica.Name = "rbMultiplica";
            this.rbMultiplica.Size = new System.Drawing.Size(69, 17);
            this.rbMultiplica.TabIndex = 0;
            this.rbMultiplica.TabStop = true;
            this.rbMultiplica.Text = "Multiplica";
            this.rbMultiplica.UseVisualStyleBackColor = true;
            this.rbMultiplica.Valor = "";
            // 
            // rbDivide
            // 
            this.rbDivide.AutoSize = true;
            this.rbDivide.Location = new System.Drawing.Point(81, 13);
            this.rbDivide.Name = "rbDivide";
            this.rbDivide.Size = new System.Drawing.Size(55, 17);
            this.rbDivide.TabIndex = 1;
            this.rbDivide.Text = "Divide";
            this.rbDivide.UseVisualStyleBackColor = true;
            this.rbDivide.Valor = "";
            // 
            // TFConvertUnid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 176);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFConvertUnid";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversão Unidade Medida";
            this.Load += new System.EventHandler(this.TFConvertUnid_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFConvertUnid_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).EndInit();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_unidade_orig;
        private Componentes.EditDefault cd_unidade_orig;
        private Componentes.EditFloat valor;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault ds_unidade_dest;
        private Componentes.EditDefault cd_unidade_dest;
        private System.Windows.Forms.Label label2;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.RadioButtonDefault rbDivide;
        private Componentes.RadioButtonDefault rbMultiplica;
    }
}