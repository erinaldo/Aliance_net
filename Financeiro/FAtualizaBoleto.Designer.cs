namespace Financeiro
{
    partial class TFAtualizaBoleto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAtualizaBoleto));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_banco = new System.Windows.Forms.TextBox();
            this.ds_banco = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nosso_numero = new System.Windows.Forms.TextBox();
            this.documento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nm_sacado = new System.Windows.Forms.TextBox();
            this.cd_sacado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.vl_atualizado = new Componentes.EditFloat(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.vl_jurocalc = new Componentes.EditFloat(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.vl_multacalc = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.dt_atualizada = new Componentes.EditData(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.vl_documento = new Componentes.EditFloat(this.components);
            this.bsBoleto = new System.Windows.Forms.BindingSource(this.components);
            this.dt_vencto = new Componentes.EditData(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_atualizado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_jurocalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_multacalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBoleto)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(449, 43);
            this.barraMenu.TabIndex = 9;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Banco";
            // 
            // cd_banco
            // 
            this.cd_banco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBoleto, "Cd_banco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_banco.Enabled = false;
            this.cd_banco.Location = new System.Drawing.Point(15, 65);
            this.cd_banco.Name = "cd_banco";
            this.cd_banco.Size = new System.Drawing.Size(39, 20);
            this.cd_banco.TabIndex = 11;
            // 
            // ds_banco
            // 
            this.ds_banco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBoleto, "Nome_banco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_banco.Enabled = false;
            this.ds_banco.Location = new System.Drawing.Point(57, 65);
            this.ds_banco.Name = "ds_banco";
            this.ds_banco.Size = new System.Drawing.Size(380, 20);
            this.ds_banco.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nosso Numero";
            // 
            // nosso_numero
            // 
            this.nosso_numero.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBoleto, "Nosso_numero", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nosso_numero.Enabled = false;
            this.nosso_numero.Location = new System.Drawing.Point(15, 143);
            this.nosso_numero.Name = "nosso_numero";
            this.nosso_numero.Size = new System.Drawing.Size(160, 20);
            this.nosso_numero.TabIndex = 14;
            // 
            // documento
            // 
            this.documento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBoleto, "NumeroDocumento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.documento.Enabled = false;
            this.documento.Location = new System.Drawing.Point(181, 143);
            this.documento.Name = "documento";
            this.documento.Size = new System.Drawing.Size(72, 20);
            this.documento.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Documento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Vencimento";
            // 
            // nm_sacado
            // 
            this.nm_sacado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBoleto, "Nm_sacado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_sacado.Enabled = false;
            this.nm_sacado.Location = new System.Drawing.Point(113, 104);
            this.nm_sacado.Name = "nm_sacado";
            this.nm_sacado.Size = new System.Drawing.Size(324, 20);
            this.nm_sacado.TabIndex = 21;
            // 
            // cd_sacado
            // 
            this.cd_sacado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBoleto, "Cd_sacado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_sacado.Enabled = false;
            this.cd_sacado.Location = new System.Drawing.Point(15, 104);
            this.cd_sacado.Name = "cd_sacado";
            this.cd_sacado.Size = new System.Drawing.Size(95, 20);
            this.cd_sacado.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Sacado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Valor Documento";
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.vl_atualizado);
            this.panelDados1.Controls.Add(this.label10);
            this.panelDados1.Controls.Add(this.vl_jurocalc);
            this.panelDados1.Controls.Add(this.label9);
            this.panelDados1.Controls.Add(this.vl_multacalc);
            this.panelDados1.Controls.Add(this.label8);
            this.panelDados1.Controls.Add(this.dt_atualizada);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Location = new System.Drawing.Point(15, 169);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(422, 52);
            this.panelDados1.TabIndex = 24;
            // 
            // vl_atualizado
            // 
            this.vl_atualizado.DecimalPlaces = 2;
            this.vl_atualizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_atualizado.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_atualizado.Location = new System.Drawing.Point(312, 22);
            this.vl_atualizado.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_atualizado.Name = "vl_atualizado";
            this.vl_atualizado.NM_Alias = "";
            this.vl_atualizado.NM_Campo = "";
            this.vl_atualizado.NM_Param = "";
            this.vl_atualizado.Operador = "";
            this.vl_atualizado.ReadOnly = true;
            this.vl_atualizado.Size = new System.Drawing.Size(105, 22);
            this.vl_atualizado.ST_AutoInc = false;
            this.vl_atualizado.ST_DisableAuto = false;
            this.vl_atualizado.ST_Gravar = false;
            this.vl_atualizado.ST_LimparCampo = true;
            this.vl_atualizado.ST_NotNull = false;
            this.vl_atualizado.ST_PrimaryKey = false;
            this.vl_atualizado.TabIndex = 21;
            this.vl_atualizado.ThousandsSeparator = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(309, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Vl. Atualizado";
            // 
            // vl_jurocalc
            // 
            this.vl_jurocalc.DecimalPlaces = 2;
            this.vl_jurocalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_jurocalc.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_jurocalc.Location = new System.Drawing.Point(212, 22);
            this.vl_jurocalc.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_jurocalc.Name = "vl_jurocalc";
            this.vl_jurocalc.NM_Alias = "";
            this.vl_jurocalc.NM_Campo = "";
            this.vl_jurocalc.NM_Param = "";
            this.vl_jurocalc.Operador = "";
            this.vl_jurocalc.ReadOnly = true;
            this.vl_jurocalc.Size = new System.Drawing.Size(93, 22);
            this.vl_jurocalc.ST_AutoInc = false;
            this.vl_jurocalc.ST_DisableAuto = false;
            this.vl_jurocalc.ST_Gravar = false;
            this.vl_jurocalc.ST_LimparCampo = true;
            this.vl_jurocalc.ST_NotNull = false;
            this.vl_jurocalc.ST_PrimaryKey = false;
            this.vl_jurocalc.TabIndex = 19;
            this.vl_jurocalc.ThousandsSeparator = true;
            this.vl_jurocalc.ValueChanged += new System.EventHandler(this.vl_jurocalc_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(209, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Vl. Juro";
            // 
            // vl_multacalc
            // 
            this.vl_multacalc.DecimalPlaces = 2;
            this.vl_multacalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_multacalc.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_multacalc.Location = new System.Drawing.Point(113, 22);
            this.vl_multacalc.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_multacalc.Name = "vl_multacalc";
            this.vl_multacalc.NM_Alias = "";
            this.vl_multacalc.NM_Campo = "";
            this.vl_multacalc.NM_Param = "";
            this.vl_multacalc.Operador = "";
            this.vl_multacalc.ReadOnly = true;
            this.vl_multacalc.Size = new System.Drawing.Size(93, 22);
            this.vl_multacalc.ST_AutoInc = false;
            this.vl_multacalc.ST_DisableAuto = false;
            this.vl_multacalc.ST_Gravar = false;
            this.vl_multacalc.ST_LimparCampo = true;
            this.vl_multacalc.ST_NotNull = false;
            this.vl_multacalc.ST_PrimaryKey = false;
            this.vl_multacalc.TabIndex = 17;
            this.vl_multacalc.ThousandsSeparator = true;
            this.vl_multacalc.ValueChanged += new System.EventHandler(this.vl_multacalc_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(110, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Vl. Multa";
            // 
            // dt_atualizada
            // 
            this.dt_atualizada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_atualizada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_atualizada.Location = new System.Drawing.Point(6, 22);
            this.dt_atualizada.Mask = "00/00/0000";
            this.dt_atualizada.Name = "dt_atualizada";
            this.dt_atualizada.NM_Alias = "";
            this.dt_atualizada.NM_Campo = "";
            this.dt_atualizada.NM_CampoBusca = "";
            this.dt_atualizada.NM_Param = "";
            this.dt_atualizada.Operador = "";
            this.dt_atualizada.Size = new System.Drawing.Size(101, 22);
            this.dt_atualizada.ST_Gravar = false;
            this.dt_atualizada.ST_LimpaCampo = true;
            this.dt_atualizada.ST_NotNull = false;
            this.dt_atualizada.ST_PrimaryKey = false;
            this.dt_atualizada.TabIndex = 15;
            this.dt_atualizada.Leave += new System.EventHandler(this.dt_atualizada_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Dt. Atualizada";
            // 
            // vl_documento
            // 
            this.vl_documento.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBoleto, "Vl_atual", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_documento.DecimalPlaces = 2;
            this.vl_documento.Enabled = false;
            this.vl_documento.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_documento.Location = new System.Drawing.Point(335, 143);
            this.vl_documento.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_documento.Name = "vl_documento";
            this.vl_documento.NM_Alias = "";
            this.vl_documento.NM_Campo = "";
            this.vl_documento.NM_Param = "";
            this.vl_documento.Operador = "";
            this.vl_documento.Size = new System.Drawing.Size(102, 20);
            this.vl_documento.ST_AutoInc = false;
            this.vl_documento.ST_DisableAuto = false;
            this.vl_documento.ST_Gravar = false;
            this.vl_documento.ST_LimparCampo = true;
            this.vl_documento.ST_NotNull = false;
            this.vl_documento.ST_PrimaryKey = false;
            this.vl_documento.TabIndex = 23;
            this.vl_documento.ThousandsSeparator = true;
            // 
            // bsBoleto
            // 
            this.bsBoleto.DataSource = typeof(CamadaDados.Financeiro.Bloqueto.blListaTitulo);
            // 
            // dt_vencto
            // 
            this.dt_vencto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_vencto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBoleto, "Dt_vencimentostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_vencto.Enabled = false;
            this.dt_vencto.Location = new System.Drawing.Point(259, 143);
            this.dt_vencto.Mask = "00/00/0000";
            this.dt_vencto.Name = "dt_vencto";
            this.dt_vencto.NM_Alias = "";
            this.dt_vencto.NM_Campo = "";
            this.dt_vencto.NM_CampoBusca = "";
            this.dt_vencto.NM_Param = "";
            this.dt_vencto.Operador = "";
            this.dt_vencto.Size = new System.Drawing.Size(70, 20);
            this.dt_vencto.ST_Gravar = false;
            this.dt_vencto.ST_LimpaCampo = true;
            this.dt_vencto.ST_NotNull = false;
            this.dt_vencto.ST_PrimaryKey = false;
            this.dt_vencto.TabIndex = 17;
            // 
            // TFAtualizaBoleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 232);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.vl_documento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nm_sacado);
            this.Controls.Add(this.cd_sacado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dt_vencto);
            this.Controls.Add(this.documento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nosso_numero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ds_banco);
            this.Controls.Add(this.cd_banco);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAtualizaBoleto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizar Boleto";
            this.Load += new System.EventHandler(this.TFAtualizaBoleto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAtualizaBoleto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_atualizado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_jurocalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_multacalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBoleto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.BindingSource bsBoleto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cd_banco;
        private System.Windows.Forms.TextBox ds_banco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nosso_numero;
        private System.Windows.Forms.TextBox documento;
        private System.Windows.Forms.Label label3;
        private Componentes.EditData dt_vencto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nm_sacado;
        private System.Windows.Forms.TextBox cd_sacado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat vl_documento;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditFloat vl_multacalc;
        private System.Windows.Forms.Label label8;
        private Componentes.EditData dt_atualizada;
        private System.Windows.Forms.Label label7;
        private Componentes.EditFloat vl_atualizado;
        private System.Windows.Forms.Label label10;
        private Componentes.EditFloat vl_jurocalc;
        private System.Windows.Forms.Label label9;
    }
}