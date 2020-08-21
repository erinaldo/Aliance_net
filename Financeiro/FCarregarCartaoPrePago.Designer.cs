namespace Financeiro
{
    partial class TFCarregarCartaoPrePago
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
            System.Windows.Forms.Label valor;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCarregarCartaoPrePago));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.vl_carga = new Componentes.EditFloat(this.components);
            this.bsCarregarPrePago = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Obs = new Componentes.EditDefault(this.components);
            this.dt_carga = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.ds_contager = new Componentes.EditDefault(this.components);
            this.bb_contager = new System.Windows.Forms.Button();
            this.cd_contager = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nr_cartao = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bb_cartao = new System.Windows.Forms.Button();
            this.id_cartao = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            valor = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_carga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarregarPrePago)).BeginInit();
            this.SuspendLayout();
            // 
            // valor
            // 
            valor.AutoSize = true;
            valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            valor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            valor.Location = new System.Drawing.Point(471, 69);
            valor.Name = "valor";
            valor.Size = new System.Drawing.Size(34, 13);
            valor.TabIndex = 587;
            valor.Text = "Valor:";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(616, 43);
            this.barraMenu.TabIndex = 11;
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.vl_carga);
            this.pDados.Controls.Add(valor);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.Obs);
            this.pDados.Controls.Add(this.dt_carga);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.ds_contager);
            this.pDados.Controls.Add(this.bb_contager);
            this.pDados.Controls.Add(this.cd_contager);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.nr_cartao);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.bb_cartao);
            this.pDados.Controls.Add(this.id_cartao);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.cbEmpresa);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(616, 161);
            this.pDados.TabIndex = 12;
            // 
            // vl_carga
            // 
            this.vl_carga.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCarregarPrePago, "Vl_carga", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_carga.DecimalPlaces = 2;
            this.vl_carga.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_carga.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_carga.Location = new System.Drawing.Point(511, 67);
            this.vl_carga.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_carga.Name = "vl_carga";
            this.vl_carga.NM_Alias = "";
            this.vl_carga.NM_Campo = "";
            this.vl_carga.NM_Param = "";
            this.vl_carga.Operador = "";
            this.vl_carga.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_carga.Size = new System.Drawing.Size(92, 20);
            this.vl_carga.ST_AutoInc = false;
            this.vl_carga.ST_DisableAuto = false;
            this.vl_carga.ST_Gravar = true;
            this.vl_carga.ST_LimparCampo = true;
            this.vl_carga.ST_NotNull = true;
            this.vl_carga.ST_PrimaryKey = false;
            this.vl_carga.TabIndex = 6;
            this.vl_carga.ThousandsSeparator = true;
            this.vl_carga.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // bsCarregarPrePago
            // 
            this.bsCarregarPrePago.DataSource = typeof(CamadaDados.Financeiro.Cartao.TList_CarregaCartaoPre);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(38, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 585;
            this.label2.Text = "Obs:";
            // 
            // Obs
            // 
            this.Obs.BackColor = System.Drawing.SystemColors.Window;
            this.Obs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Obs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Obs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarregarPrePago, "Obs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Obs.Location = new System.Drawing.Point(75, 91);
            this.Obs.Multiline = true;
            this.Obs.Name = "Obs";
            this.Obs.NM_Alias = "";
            this.Obs.NM_Campo = "";
            this.Obs.NM_CampoBusca = "";
            this.Obs.NM_Param = "";
            this.Obs.QTD_Zero = 0;
            this.Obs.Size = new System.Drawing.Size(528, 57);
            this.Obs.ST_AutoInc = false;
            this.Obs.ST_DisableAuto = false;
            this.Obs.ST_Float = false;
            this.Obs.ST_Gravar = false;
            this.Obs.ST_Int = false;
            this.Obs.ST_LimpaCampo = true;
            this.Obs.ST_NotNull = false;
            this.Obs.ST_PrimaryKey = false;
            this.Obs.TabIndex = 7;
            this.Obs.TextOld = null;
            // 
            // dt_carga
            // 
            this.dt_carga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_carga.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarregarPrePago, "Dt_cargastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_carga.Location = new System.Drawing.Point(536, 40);
            this.dt_carga.Mask = "00/00/0000";
            this.dt_carga.Name = "dt_carga";
            this.dt_carga.NM_Alias = "";
            this.dt_carga.NM_Campo = "Dt.Carga";
            this.dt_carga.NM_CampoBusca = "Dt.Carga";
            this.dt_carga.NM_Param = "@P_DT.CARGA";
            this.dt_carga.Operador = "";
            this.dt_carga.Size = new System.Drawing.Size(67, 20);
            this.dt_carga.ST_Gravar = true;
            this.dt_carga.ST_LimpaCampo = true;
            this.dt_carga.ST_NotNull = true;
            this.dt_carga.ST_PrimaryKey = false;
            this.dt_carga.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(473, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 583;
            this.label8.Text = "Dt. Lancto:";
            // 
            // ds_contager
            // 
            this.ds_contager.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarregarPrePago, "Ds_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contager.Enabled = false;
            this.ds_contager.Location = new System.Drawing.Point(189, 65);
            this.ds_contager.Name = "ds_contager";
            this.ds_contager.NM_Alias = "";
            this.ds_contager.NM_Campo = "ds_contager";
            this.ds_contager.NM_CampoBusca = "ds_contager";
            this.ds_contager.NM_Param = "@P_CD_EMPRESA";
            this.ds_contager.QTD_Zero = 0;
            this.ds_contager.Size = new System.Drawing.Size(278, 20);
            this.ds_contager.ST_AutoInc = false;
            this.ds_contager.ST_DisableAuto = false;
            this.ds_contager.ST_Float = false;
            this.ds_contager.ST_Gravar = true;
            this.ds_contager.ST_Int = false;
            this.ds_contager.ST_LimpaCampo = true;
            this.ds_contager.ST_NotNull = true;
            this.ds_contager.ST_PrimaryKey = false;
            this.ds_contager.TabIndex = 581;
            this.ds_contager.TextOld = null;
            // 
            // bb_contager
            // 
            this.bb_contager.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contager.Image = ((System.Drawing.Image)(resources.GetObject("bb_contager.Image")));
            this.bb_contager.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contager.Location = new System.Drawing.Point(155, 64);
            this.bb_contager.Name = "bb_contager";
            this.bb_contager.Size = new System.Drawing.Size(28, 21);
            this.bb_contager.TabIndex = 5;
            this.bb_contager.UseVisualStyleBackColor = false;
            this.bb_contager.Click += new System.EventHandler(this.bb_contager_Click);
            // 
            // cd_contager
            // 
            this.cd_contager.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarregarPrePago, "Cd_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contager.Location = new System.Drawing.Point(75, 65);
            this.cd_contager.Name = "cd_contager";
            this.cd_contager.NM_Alias = "";
            this.cd_contager.NM_Campo = "Conta Ger.";
            this.cd_contager.NM_CampoBusca = "cd_contager";
            this.cd_contager.NM_Param = "@P_CD_EMPRESA";
            this.cd_contager.QTD_Zero = 0;
            this.cd_contager.Size = new System.Drawing.Size(79, 20);
            this.cd_contager.ST_AutoInc = false;
            this.cd_contager.ST_DisableAuto = false;
            this.cd_contager.ST_Float = false;
            this.cd_contager.ST_Gravar = true;
            this.cd_contager.ST_Int = false;
            this.cd_contager.ST_LimpaCampo = true;
            this.cd_contager.ST_NotNull = true;
            this.cd_contager.ST_PrimaryKey = true;
            this.cd_contager.TabIndex = 4;
            this.cd_contager.TextOld = null;
            this.cd_contager.Leave += new System.EventHandler(this.cd_contager_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 580;
            this.label3.Text = "Conta Ger.:";
            // 
            // nr_cartao
            // 
            this.nr_cartao.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cartao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_cartao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cartao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarregarPrePago, "Nr_cartao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_cartao.Location = new System.Drawing.Point(223, 39);
            this.nr_cartao.Name = "nr_cartao";
            this.nr_cartao.NM_Alias = "";
            this.nr_cartao.NM_Campo = "nr_cartao";
            this.nr_cartao.NM_CampoBusca = "nr_cartao";
            this.nr_cartao.NM_Param = "@P_CD_EMPRESA";
            this.nr_cartao.QTD_Zero = 0;
            this.nr_cartao.Size = new System.Drawing.Size(244, 20);
            this.nr_cartao.ST_AutoInc = false;
            this.nr_cartao.ST_DisableAuto = false;
            this.nr_cartao.ST_Float = false;
            this.nr_cartao.ST_Gravar = true;
            this.nr_cartao.ST_Int = false;
            this.nr_cartao.ST_LimpaCampo = true;
            this.nr_cartao.ST_NotNull = false;
            this.nr_cartao.ST_PrimaryKey = false;
            this.nr_cartao.TabIndex = 547;
            this.nr_cartao.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(163, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 549;
            this.label1.Text = "Nº Cartão:";
            // 
            // bb_cartao
            // 
            this.bb_cartao.BackColor = System.Drawing.SystemColors.Control;
            this.bb_cartao.Image = ((System.Drawing.Image)(resources.GetObject("bb_cartao.Image")));
            this.bb_cartao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_cartao.Location = new System.Drawing.Point(129, 39);
            this.bb_cartao.Name = "bb_cartao";
            this.bb_cartao.Size = new System.Drawing.Size(28, 19);
            this.bb_cartao.TabIndex = 2;
            this.bb_cartao.UseVisualStyleBackColor = false;
            this.bb_cartao.Click += new System.EventHandler(this.bb_cartao_Click);
            // 
            // id_cartao
            // 
            this.id_cartao.BackColor = System.Drawing.SystemColors.Window;
            this.id_cartao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_cartao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_cartao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarregarPrePago, "Id_cartaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_cartao.Location = new System.Drawing.Point(76, 39);
            this.id_cartao.Name = "id_cartao";
            this.id_cartao.NM_Alias = "";
            this.id_cartao.NM_Campo = "id_cartao";
            this.id_cartao.NM_CampoBusca = "id_cartao";
            this.id_cartao.NM_Param = "@P_CD_EMPRESA";
            this.id_cartao.QTD_Zero = 0;
            this.id_cartao.Size = new System.Drawing.Size(52, 20);
            this.id_cartao.ST_AutoInc = false;
            this.id_cartao.ST_DisableAuto = false;
            this.id_cartao.ST_Float = false;
            this.id_cartao.ST_Gravar = true;
            this.id_cartao.ST_Int = false;
            this.id_cartao.ST_LimpaCampo = true;
            this.id_cartao.ST_NotNull = true;
            this.id_cartao.ST_PrimaryKey = false;
            this.id_cartao.TabIndex = 1;
            this.id_cartao.TextOld = null;
            this.id_cartao.Leave += new System.EventHandler(this.id_cartao_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(11, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 548;
            this.label4.Text = "Id. Cartão:";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCarregarPrePago, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarregarPrePago, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(76, 12);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "Empresa";
            this.cbEmpresa.NM_Param = "@P_EMPRESA";
            this.cbEmpresa.Size = new System.Drawing.Size(527, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = true;
            this.cbEmpresa.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(19, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 149;
            this.label5.Text = "Empresa:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFCarregarCartaoPrePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 204);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCarregarCartaoPrePago";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carregar Cartão Pré-Pago";
            this.Load += new System.EventHandler(this.TFCarregarCartaoPrePago_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCarregarCartaoPrePago_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_carga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarregarPrePago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault nr_cartao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_cartao;
        private Componentes.EditDefault id_cartao;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault ds_contager;
        private System.Windows.Forms.Button bb_contager;
        private Componentes.EditDefault cd_contager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault Obs;
        private Componentes.EditData dt_carga;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bsCarregarPrePago;
        private Componentes.EditFloat vl_carga;
    }
}