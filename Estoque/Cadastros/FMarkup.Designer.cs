namespace Estoque.Cadastros
{
    partial class TFMarkup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFMarkup));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.bsMarkup = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.pc_lucro = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.pc_custovariavel = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pc_custofixo = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tp_markup = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ds_markup = new Componentes.EditDefault(this.components);
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarkup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_lucro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_custovariavel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_custofixo)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(523, 43);
            this.barraMenu.TabIndex = 3;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.cbEmpresa);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.editFloat1);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.pc_lucro);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.pc_custovariavel);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.pc_custofixo);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.tp_markup);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_markup);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(523, 112);
            this.pDados.TabIndex = 0;
            // 
            // editFloat1
            // 
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsMarkup, "Pc_indicemarkup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N5"));
            this.editFloat1.DecimalPlaces = 5;
            this.editFloat1.Enabled = false;
            this.editFloat1.Location = new System.Drawing.Point(428, 87);
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.Size = new System.Drawing.Size(90, 20);
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = false;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = false;
            this.editFloat1.ST_PrimaryKey = false;
            this.editFloat1.TabIndex = 11;
            this.editFloat1.ThousandsSeparator = true;
            // 
            // bsMarkup
            // 
            this.bsMarkup.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_Markup);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "% Indice:";
            // 
            // pc_lucro
            // 
            this.pc_lucro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsMarkup, "Pc_lucro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N5"));
            this.pc_lucro.DecimalPlaces = 5;
            this.pc_lucro.Location = new System.Drawing.Point(262, 87);
            this.pc_lucro.Name = "pc_lucro";
            this.pc_lucro.NM_Alias = "";
            this.pc_lucro.NM_Campo = "";
            this.pc_lucro.NM_Param = "";
            this.pc_lucro.Operador = "";
            this.pc_lucro.Size = new System.Drawing.Size(104, 20);
            this.pc_lucro.ST_AutoInc = false;
            this.pc_lucro.ST_DisableAuto = false;
            this.pc_lucro.ST_Gravar = false;
            this.pc_lucro.ST_LimparCampo = true;
            this.pc_lucro.ST_NotNull = false;
            this.pc_lucro.ST_PrimaryKey = false;
            this.pc_lucro.TabIndex = 5;
            this.pc_lucro.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "% Lucro:";
            // 
            // pc_custovariavel
            // 
            this.pc_custovariavel.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsMarkup, "Pc_custovariavel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N5"));
            this.pc_custovariavel.DecimalPlaces = 5;
            this.pc_custovariavel.Location = new System.Drawing.Point(98, 87);
            this.pc_custovariavel.Name = "pc_custovariavel";
            this.pc_custovariavel.NM_Alias = "";
            this.pc_custovariavel.NM_Campo = "";
            this.pc_custovariavel.NM_Param = "";
            this.pc_custovariavel.Operador = "";
            this.pc_custovariavel.Size = new System.Drawing.Size(104, 20);
            this.pc_custovariavel.ST_AutoInc = false;
            this.pc_custovariavel.ST_DisableAuto = false;
            this.pc_custovariavel.ST_Gravar = true;
            this.pc_custovariavel.ST_LimparCampo = true;
            this.pc_custovariavel.ST_NotNull = true;
            this.pc_custovariavel.ST_PrimaryKey = false;
            this.pc_custovariavel.TabIndex = 4;
            this.pc_custovariavel.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "% Custo Variavel:";
            // 
            // pc_custofixo
            // 
            this.pc_custofixo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsMarkup, "Pc_custofixo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N5"));
            this.pc_custofixo.DecimalPlaces = 5;
            this.pc_custofixo.Location = new System.Drawing.Point(283, 60);
            this.pc_custofixo.Name = "pc_custofixo";
            this.pc_custofixo.NM_Alias = "";
            this.pc_custofixo.NM_Campo = "";
            this.pc_custofixo.NM_Param = "";
            this.pc_custofixo.Operador = "";
            this.pc_custofixo.Size = new System.Drawing.Size(104, 20);
            this.pc_custofixo.ST_AutoInc = false;
            this.pc_custofixo.ST_DisableAuto = false;
            this.pc_custofixo.ST_Gravar = true;
            this.pc_custofixo.ST_LimparCampo = true;
            this.pc_custofixo.ST_NotNull = true;
            this.pc_custofixo.ST_PrimaryKey = false;
            this.pc_custofixo.TabIndex = 3;
            this.pc_custofixo.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "% Custo Fixo:";
            // 
            // tp_markup
            // 
            this.tp_markup.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMarkup, "Tp_markup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_markup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_markup.FormattingEnabled = true;
            this.tp_markup.Location = new System.Drawing.Point(80, 60);
            this.tp_markup.Name = "tp_markup";
            this.tp_markup.NM_Alias = "";
            this.tp_markup.NM_Campo = "";
            this.tp_markup.NM_Param = "";
            this.tp_markup.Size = new System.Drawing.Size(121, 21);
            this.tp_markup.ST_Gravar = true;
            this.tp_markup.ST_LimparCampo = true;
            this.tp_markup.ST_NotNull = true;
            this.tp_markup.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "TP. Markup:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Markup:";
            // 
            // ds_markup
            // 
            this.ds_markup.BackColor = System.Drawing.SystemColors.Window;
            this.ds_markup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_markup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_markup.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMarkup, "Ds_markup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_markup.Location = new System.Drawing.Point(80, 34);
            this.ds_markup.Name = "ds_markup";
            this.ds_markup.NM_Alias = "";
            this.ds_markup.NM_Campo = "";
            this.ds_markup.NM_CampoBusca = "";
            this.ds_markup.NM_Param = "";
            this.ds_markup.QTD_Zero = 0;
            this.ds_markup.Size = new System.Drawing.Size(438, 20);
            this.ds_markup.ST_AutoInc = false;
            this.ds_markup.ST_DisableAuto = false;
            this.ds_markup.ST_Float = false;
            this.ds_markup.ST_Gravar = true;
            this.ds_markup.ST_Int = false;
            this.ds_markup.ST_LimpaCampo = true;
            this.ds_markup.ST_NotNull = true;
            this.ds_markup.ST_PrimaryKey = false;
            this.ds_markup.TabIndex = 1;
            this.ds_markup.TextOld = null;
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMarkup, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(80, 7);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(438, 21);
            this.cbEmpresa.ST_Gravar = true;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = true;
            this.cbEmpresa.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(23, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 156;
            this.label8.Text = "Empresa:";
            // 
            // TFMarkup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 155);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFMarkup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Markup";
            this.Load += new System.EventHandler(this.TFMarkup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFMarkup_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarkup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_lucro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_custovariavel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_custofixo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_markup;
        private System.Windows.Forms.BindingSource bsMarkup;
        private System.Windows.Forms.Label label2;
        private Componentes.ComboBoxDefault tp_markup;
        private Componentes.EditFloat pc_custofixo;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat pc_lucro;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat pc_custovariavel;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat editFloat1;
        private System.Windows.Forms.Label label6;
        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.Label label8;
    }
}