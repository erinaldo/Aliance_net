namespace PDV
{
    partial class TFRetiradaCaixa
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRetiradaCaixa));
            System.Windows.Forms.Label label5;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.tp_registro = new Componentes.ComboBoxDefault(this.components);
            this.bsRetirada = new System.Windows.Forms.BindingSource(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.vl_retirada = new Componentes.EditFloat(this.components);
            this.id_caixa = new Componentes.EditDefault(this.components);
            this.bb_portador = new System.Windows.Forms.Button();
            this.cd_portador = new Componentes.EditDefault(this.components);
            this.ds_portador = new Componentes.EditDefault(this.components);
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRetirada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_retirada)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(262, 24);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(97, 13);
            label3.TabIndex = 95;
            label3.Text = "Tipo Movimento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(10, 96);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(79, 13);
            label4.TabIndex = 94;
            label4.Text = "Observação:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(49, 42);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 13);
            label1.TabIndex = 92;
            label1.Text = "Valor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(47, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 13);
            label2.TabIndex = 87;
            label2.Text = "Caixa:";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(485, 43);
            this.barraMenu.TabIndex = 10;
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
            this.pDados.Controls.Add(this.bb_portador);
            this.pDados.Controls.Add(this.cd_portador);
            this.pDados.Controls.Add(this.ds_portador);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(this.tp_registro);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.vl_retirada);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.id_caixa);
            this.pDados.Controls.Add(label2);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(485, 158);
            this.pDados.TabIndex = 11;
            // 
            // tp_registro
            // 
            this.tp_registro.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRetirada, "Tp_registro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_registro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_registro.FormattingEnabled = true;
            this.tp_registro.Location = new System.Drawing.Point(262, 40);
            this.tp_registro.Name = "tp_registro";
            this.tp_registro.NM_Alias = "";
            this.tp_registro.NM_Campo = "";
            this.tp_registro.NM_Param = "";
            this.tp_registro.Size = new System.Drawing.Size(215, 21);
            this.tp_registro.ST_Gravar = true;
            this.tp_registro.ST_LimparCampo = true;
            this.tp_registro.ST_NotNull = true;
            this.tp_registro.TabIndex = 2;
            // 
            // bsRetirada
            // 
            this.bsRetirada.DataSource = typeof(CamadaDados.Faturamento.PDV.TList_RetiradaCaixa);
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRetirada, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(95, 93);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(382, 58);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 5;
            this.ds_observacao.TextOld = null;
            // 
            // vl_retirada
            // 
            this.vl_retirada.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRetirada, "Vl_retirada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_retirada.DecimalPlaces = 2;
            this.vl_retirada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_retirada.Location = new System.Drawing.Point(95, 32);
            this.vl_retirada.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_retirada.Name = "vl_retirada";
            this.vl_retirada.NM_Alias = "";
            this.vl_retirada.NM_Campo = "";
            this.vl_retirada.NM_Param = "";
            this.vl_retirada.Operador = "";
            this.vl_retirada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_retirada.Size = new System.Drawing.Size(161, 29);
            this.vl_retirada.ST_AutoInc = false;
            this.vl_retirada.ST_DisableAuto = false;
            this.vl_retirada.ST_Gravar = false;
            this.vl_retirada.ST_LimparCampo = true;
            this.vl_retirada.ST_NotNull = false;
            this.vl_retirada.ST_PrimaryKey = false;
            this.vl_retirada.TabIndex = 1;
            this.vl_retirada.ThousandsSeparator = true;
            // 
            // id_caixa
            // 
            this.id_caixa.BackColor = System.Drawing.SystemColors.Window;
            this.id_caixa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_caixa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_caixa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRetirada, "Id_caixastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_caixa.Enabled = false;
            this.id_caixa.Location = new System.Drawing.Point(95, 6);
            this.id_caixa.Name = "id_caixa";
            this.id_caixa.NM_Alias = "";
            this.id_caixa.NM_Campo = "";
            this.id_caixa.NM_CampoBusca = "";
            this.id_caixa.NM_Param = "";
            this.id_caixa.QTD_Zero = 0;
            this.id_caixa.Size = new System.Drawing.Size(60, 20);
            this.id_caixa.ST_AutoInc = false;
            this.id_caixa.ST_DisableAuto = false;
            this.id_caixa.ST_Float = false;
            this.id_caixa.ST_Gravar = false;
            this.id_caixa.ST_Int = false;
            this.id_caixa.ST_LimpaCampo = true;
            this.id_caixa.ST_NotNull = false;
            this.id_caixa.ST_PrimaryKey = false;
            this.id_caixa.TabIndex = 0;
            this.id_caixa.TextOld = null;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(30, 70);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(59, 13);
            label5.TabIndex = 96;
            label5.Text = "Portador:";
            // 
            // bb_portador
            // 
            this.bb_portador.BackColor = System.Drawing.SystemColors.Control;
            this.bb_portador.Image = ((System.Drawing.Image)(resources.GetObject("bb_portador.Image")));
            this.bb_portador.Location = new System.Drawing.Point(161, 67);
            this.bb_portador.Name = "bb_portador";
            this.bb_portador.Size = new System.Drawing.Size(28, 19);
            this.bb_portador.TabIndex = 4;
            this.bb_portador.UseVisualStyleBackColor = false;
            this.bb_portador.Click += new System.EventHandler(this.bb_portador_Click);
            // 
            // cd_portador
            // 
            this.cd_portador.BackColor = System.Drawing.SystemColors.Window;
            this.cd_portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_portador.Location = new System.Drawing.Point(95, 67);
            this.cd_portador.MaxLength = 10;
            this.cd_portador.Name = "cd_portador";
            this.cd_portador.NM_Alias = "";
            this.cd_portador.NM_Campo = "cd_portador";
            this.cd_portador.NM_CampoBusca = "cd_portador";
            this.cd_portador.NM_Param = "@P_CD_CLIFOR";
            this.cd_portador.QTD_Zero = 0;
            this.cd_portador.Size = new System.Drawing.Size(60, 20);
            this.cd_portador.ST_AutoInc = false;
            this.cd_portador.ST_DisableAuto = false;
            this.cd_portador.ST_Float = false;
            this.cd_portador.ST_Gravar = true;
            this.cd_portador.ST_Int = false;
            this.cd_portador.ST_LimpaCampo = true;
            this.cd_portador.ST_NotNull = false;
            this.cd_portador.ST_PrimaryKey = false;
            this.cd_portador.TabIndex = 3;
            this.cd_portador.TextOld = null;
            this.cd_portador.Leave += new System.EventHandler(this.cd_portador_Leave);
            // 
            // ds_portador
            // 
            this.ds_portador.BackColor = System.Drawing.SystemColors.Window;
            this.ds_portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_portador.Enabled = false;
            this.ds_portador.Location = new System.Drawing.Point(195, 67);
            this.ds_portador.Name = "ds_portador";
            this.ds_portador.NM_Alias = "";
            this.ds_portador.NM_Campo = "ds_portador";
            this.ds_portador.NM_CampoBusca = "ds_portador";
            this.ds_portador.NM_Param = "@P_NM_CLIFOR";
            this.ds_portador.QTD_Zero = 0;
            this.ds_portador.Size = new System.Drawing.Size(282, 20);
            this.ds_portador.ST_AutoInc = false;
            this.ds_portador.ST_DisableAuto = false;
            this.ds_portador.ST_Float = false;
            this.ds_portador.ST_Gravar = false;
            this.ds_portador.ST_Int = false;
            this.ds_portador.ST_LimpaCampo = true;
            this.ds_portador.ST_NotNull = false;
            this.ds_portador.ST_PrimaryKey = false;
            this.ds_portador.TabIndex = 97;
            this.ds_portador.TextOld = null;
            // 
            // TFRetiradaCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 201);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFRetiradaCaixa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suprimento/Retirada Caixa PDV";
            this.Load += new System.EventHandler(this.TFRetiradaCaixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRetiradaCaixa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRetirada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_retirada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_observacao;
        private Componentes.EditFloat vl_retirada;
        private Componentes.EditDefault id_caixa;
        private System.Windows.Forms.BindingSource bsRetirada;
        private Componentes.ComboBoxDefault tp_registro;
        private System.Windows.Forms.Button bb_portador;
        private Componentes.EditDefault cd_portador;
        private Componentes.EditDefault ds_portador;
    }
}