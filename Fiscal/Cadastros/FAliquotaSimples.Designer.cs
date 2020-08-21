namespace Fiscal.Cadastros
{
    partial class TFAliquotaSimples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAliquotaSimples));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.ds_aliquota = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bsAliq = new System.Windows.Forms.BindingSource(this.components);
            this.pc_aliquota = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pc_irpj = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pc_csll = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.pc_cofins = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.pc_pis = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.pc_iss = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.pc_ipi = new Componentes.EditFloat(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.pc_icms = new Componentes.EditFloat(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.pc_cpp = new Componentes.EditFloat(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAliq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_aliquota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_irpj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_csll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_cofins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_pis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_iss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_ipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_icms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_cpp)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(427, 43);
            this.barraMenu.TabIndex = 21;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Confirmar";
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
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Controls.Add(this.pc_iss);
            this.panelDados1.Controls.Add(this.label8);
            this.panelDados1.Controls.Add(this.pc_ipi);
            this.panelDados1.Controls.Add(this.label9);
            this.panelDados1.Controls.Add(this.pc_icms);
            this.panelDados1.Controls.Add(this.label10);
            this.panelDados1.Controls.Add(this.pc_cpp);
            this.panelDados1.Controls.Add(this.label6);
            this.panelDados1.Controls.Add(this.pc_pis);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.pc_cofins);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.pc_csll);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.pc_irpj);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.pc_aliquota);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.ds_aliquota);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(427, 131);
            this.panelDados1.TabIndex = 22;
            // 
            // ds_aliquota
            // 
            this.ds_aliquota.BackColor = System.Drawing.SystemColors.Window;
            this.ds_aliquota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_aliquota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_aliquota.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAliq, "Ds_aliquota", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_aliquota.Location = new System.Drawing.Point(15, 20);
            this.ds_aliquota.Name = "ds_aliquota";
            this.ds_aliquota.NM_Alias = "";
            this.ds_aliquota.NM_Campo = "";
            this.ds_aliquota.NM_CampoBusca = "";
            this.ds_aliquota.NM_Param = "";
            this.ds_aliquota.QTD_Zero = 0;
            this.ds_aliquota.Size = new System.Drawing.Size(297, 20);
            this.ds_aliquota.ST_AutoInc = false;
            this.ds_aliquota.ST_DisableAuto = false;
            this.ds_aliquota.ST_Float = false;
            this.ds_aliquota.ST_Gravar = false;
            this.ds_aliquota.ST_Int = false;
            this.ds_aliquota.ST_LimpaCampo = true;
            this.ds_aliquota.ST_NotNull = false;
            this.ds_aliquota.ST_PrimaryKey = false;
            this.ds_aliquota.TabIndex = 0;
            this.ds_aliquota.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aliquota";
            // 
            // bsAliq
            // 
            this.bsAliq.DataSource = typeof(CamadaDados.Fiscal.TList_AliquotaSimples);
            // 
            // pc_aliquota
            // 
            this.pc_aliquota.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAliq, "Pc_aliquota", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.pc_aliquota.DecimalPlaces = 2;
            this.pc_aliquota.Location = new System.Drawing.Point(318, 20);
            this.pc_aliquota.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_aliquota.Name = "pc_aliquota";
            this.pc_aliquota.NM_Alias = "";
            this.pc_aliquota.NM_Campo = "";
            this.pc_aliquota.NM_Param = "";
            this.pc_aliquota.Operador = "";
            this.pc_aliquota.Size = new System.Drawing.Size(95, 20);
            this.pc_aliquota.ST_AutoInc = false;
            this.pc_aliquota.ST_DisableAuto = false;
            this.pc_aliquota.ST_Gravar = false;
            this.pc_aliquota.ST_LimparCampo = true;
            this.pc_aliquota.ST_NotNull = false;
            this.pc_aliquota.ST_PrimaryKey = false;
            this.pc_aliquota.TabIndex = 1;
            this.pc_aliquota.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "% Aliquota";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "% IRPJ";
            // 
            // pc_irpj
            // 
            this.pc_irpj.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAliq, "Pc_irpj", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.pc_irpj.DecimalPlaces = 2;
            this.pc_irpj.Location = new System.Drawing.Point(15, 59);
            this.pc_irpj.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_irpj.Name = "pc_irpj";
            this.pc_irpj.NM_Alias = "";
            this.pc_irpj.NM_Campo = "";
            this.pc_irpj.NM_Param = "";
            this.pc_irpj.Operador = "";
            this.pc_irpj.Size = new System.Drawing.Size(95, 20);
            this.pc_irpj.ST_AutoInc = false;
            this.pc_irpj.ST_DisableAuto = false;
            this.pc_irpj.ST_Gravar = false;
            this.pc_irpj.ST_LimparCampo = true;
            this.pc_irpj.ST_NotNull = false;
            this.pc_irpj.ST_PrimaryKey = false;
            this.pc_irpj.TabIndex = 2;
            this.pc_irpj.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "% CSLL";
            // 
            // pc_csll
            // 
            this.pc_csll.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAliq, "Pc_csll", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.pc_csll.DecimalPlaces = 2;
            this.pc_csll.Location = new System.Drawing.Point(116, 59);
            this.pc_csll.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_csll.Name = "pc_csll";
            this.pc_csll.NM_Alias = "";
            this.pc_csll.NM_Campo = "";
            this.pc_csll.NM_Param = "";
            this.pc_csll.Operador = "";
            this.pc_csll.Size = new System.Drawing.Size(95, 20);
            this.pc_csll.ST_AutoInc = false;
            this.pc_csll.ST_DisableAuto = false;
            this.pc_csll.ST_Gravar = false;
            this.pc_csll.ST_LimparCampo = true;
            this.pc_csll.ST_NotNull = false;
            this.pc_csll.ST_PrimaryKey = false;
            this.pc_csll.TabIndex = 3;
            this.pc_csll.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "% COFINS";
            // 
            // pc_cofins
            // 
            this.pc_cofins.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAliq, "Pc_cofins", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.pc_cofins.DecimalPlaces = 2;
            this.pc_cofins.Location = new System.Drawing.Point(217, 59);
            this.pc_cofins.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_cofins.Name = "pc_cofins";
            this.pc_cofins.NM_Alias = "";
            this.pc_cofins.NM_Campo = "";
            this.pc_cofins.NM_Param = "";
            this.pc_cofins.Operador = "";
            this.pc_cofins.Size = new System.Drawing.Size(95, 20);
            this.pc_cofins.ST_AutoInc = false;
            this.pc_cofins.ST_DisableAuto = false;
            this.pc_cofins.ST_Gravar = false;
            this.pc_cofins.ST_LimparCampo = true;
            this.pc_cofins.ST_NotNull = false;
            this.pc_cofins.ST_PrimaryKey = false;
            this.pc_cofins.TabIndex = 4;
            this.pc_cofins.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "% PIS";
            // 
            // pc_pis
            // 
            this.pc_pis.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAliq, "Pc_pis", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.pc_pis.DecimalPlaces = 2;
            this.pc_pis.Location = new System.Drawing.Point(318, 59);
            this.pc_pis.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_pis.Name = "pc_pis";
            this.pc_pis.NM_Alias = "";
            this.pc_pis.NM_Campo = "";
            this.pc_pis.NM_Param = "";
            this.pc_pis.Operador = "";
            this.pc_pis.Size = new System.Drawing.Size(95, 20);
            this.pc_pis.ST_AutoInc = false;
            this.pc_pis.ST_DisableAuto = false;
            this.pc_pis.ST_Gravar = false;
            this.pc_pis.ST_LimparCampo = true;
            this.pc_pis.ST_NotNull = false;
            this.pc_pis.ST_PrimaryKey = false;
            this.pc_pis.TabIndex = 5;
            this.pc_pis.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "% ISS";
            // 
            // pc_iss
            // 
            this.pc_iss.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAliq, "Pc_iss", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.pc_iss.DecimalPlaces = 2;
            this.pc_iss.Location = new System.Drawing.Point(318, 98);
            this.pc_iss.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_iss.Name = "pc_iss";
            this.pc_iss.NM_Alias = "";
            this.pc_iss.NM_Campo = "";
            this.pc_iss.NM_Param = "";
            this.pc_iss.Operador = "";
            this.pc_iss.Size = new System.Drawing.Size(95, 20);
            this.pc_iss.ST_AutoInc = false;
            this.pc_iss.ST_DisableAuto = false;
            this.pc_iss.ST_Gravar = false;
            this.pc_iss.ST_LimparCampo = true;
            this.pc_iss.ST_NotNull = false;
            this.pc_iss.ST_PrimaryKey = false;
            this.pc_iss.TabIndex = 9;
            this.pc_iss.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(214, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "% IPI";
            // 
            // pc_ipi
            // 
            this.pc_ipi.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAliq, "Pc_ipi", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.pc_ipi.DecimalPlaces = 2;
            this.pc_ipi.Location = new System.Drawing.Point(217, 98);
            this.pc_ipi.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_ipi.Name = "pc_ipi";
            this.pc_ipi.NM_Alias = "";
            this.pc_ipi.NM_Campo = "";
            this.pc_ipi.NM_Param = "";
            this.pc_ipi.Operador = "";
            this.pc_ipi.Size = new System.Drawing.Size(95, 20);
            this.pc_ipi.ST_AutoInc = false;
            this.pc_ipi.ST_DisableAuto = false;
            this.pc_ipi.ST_Gravar = false;
            this.pc_ipi.ST_LimparCampo = true;
            this.pc_ipi.ST_NotNull = false;
            this.pc_ipi.ST_PrimaryKey = false;
            this.pc_ipi.TabIndex = 8;
            this.pc_ipi.ThousandsSeparator = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(113, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "% ICMS";
            // 
            // pc_icms
            // 
            this.pc_icms.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAliq, "Pc_icms", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.pc_icms.DecimalPlaces = 2;
            this.pc_icms.Location = new System.Drawing.Point(116, 98);
            this.pc_icms.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_icms.Name = "pc_icms";
            this.pc_icms.NM_Alias = "";
            this.pc_icms.NM_Campo = "";
            this.pc_icms.NM_Param = "";
            this.pc_icms.Operador = "";
            this.pc_icms.Size = new System.Drawing.Size(95, 20);
            this.pc_icms.ST_AutoInc = false;
            this.pc_icms.ST_DisableAuto = false;
            this.pc_icms.ST_Gravar = false;
            this.pc_icms.ST_LimparCampo = true;
            this.pc_icms.ST_NotNull = false;
            this.pc_icms.ST_PrimaryKey = false;
            this.pc_icms.TabIndex = 7;
            this.pc_icms.ThousandsSeparator = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "% CPP";
            // 
            // pc_cpp
            // 
            this.pc_cpp.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAliq, "Pc_cpp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.pc_cpp.DecimalPlaces = 2;
            this.pc_cpp.Location = new System.Drawing.Point(15, 98);
            this.pc_cpp.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_cpp.Name = "pc_cpp";
            this.pc_cpp.NM_Alias = "";
            this.pc_cpp.NM_Campo = "";
            this.pc_cpp.NM_Param = "";
            this.pc_cpp.Operador = "";
            this.pc_cpp.Size = new System.Drawing.Size(95, 20);
            this.pc_cpp.ST_AutoInc = false;
            this.pc_cpp.ST_DisableAuto = false;
            this.pc_cpp.ST_Gravar = false;
            this.pc_cpp.ST_LimparCampo = true;
            this.pc_cpp.ST_NotNull = false;
            this.pc_cpp.ST_PrimaryKey = false;
            this.pc_cpp.TabIndex = 6;
            this.pc_cpp.ThousandsSeparator = true;
            // 
            // TFAliquotaSimples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 174);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAliquotaSimples";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aliquota Simples Nacional";
            this.Load += new System.EventHandler(this.TFAliquotaSimples_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAliquotaSimples_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAliq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_aliquota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_irpj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_csll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_cofins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_pis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_iss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_ipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_icms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_cpp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_aliquota;
        private System.Windows.Forms.BindingSource bsAliq;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat pc_aliquota;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat pc_pis;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat pc_cofins;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat pc_csll;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat pc_irpj;
        private System.Windows.Forms.Label label7;
        private Componentes.EditFloat pc_iss;
        private System.Windows.Forms.Label label8;
        private Componentes.EditFloat pc_ipi;
        private System.Windows.Forms.Label label9;
        private Componentes.EditFloat pc_icms;
        private System.Windows.Forms.Label label10;
        private Componentes.EditFloat pc_cpp;
    }
}