namespace PostoCombustivel
{
    partial class TFPlacaKM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFPlacaKM));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.cpf_motorista = new Componentes.EditDefault(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.nr_requisicao = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.placa = new Componentes.EditMask(this.components);
            this.nr_frota = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nm_motorista = new Componentes.EditDefault(this.components);
            this.km = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.km)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(689, 43);
            this.barraMenu.TabIndex = 15;
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
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.Transparent;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.label20);
            this.panelDados1.Controls.Add(this.cpf_motorista);
            this.panelDados1.Controls.Add(this.label17);
            this.panelDados1.Controls.Add(this.nr_requisicao);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.placa);
            this.panelDados1.Controls.Add(this.nr_frota);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.nm_motorista);
            this.panelDados1.Controls.Add(this.km);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(689, 62);
            this.panelDados1.TabIndex = 17;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(160, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 440;
            this.label20.Text = "Motorista:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cpf_motorista
            // 
            this.cpf_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.cpf_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpf_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cpf_motorista.Location = new System.Drawing.Point(59, 31);
            this.cpf_motorista.Name = "cpf_motorista";
            this.cpf_motorista.NM_Alias = "";
            this.cpf_motorista.NM_Campo = "nr_cpf";
            this.cpf_motorista.NM_CampoBusca = "nr_cpf";
            this.cpf_motorista.NM_Param = "@P_NR_CPF";
            this.cpf_motorista.QTD_Zero = 0;
            this.cpf_motorista.Size = new System.Drawing.Size(100, 20);
            this.cpf_motorista.ST_AutoInc = false;
            this.cpf_motorista.ST_DisableAuto = false;
            this.cpf_motorista.ST_Float = false;
            this.cpf_motorista.ST_Gravar = false;
            this.cpf_motorista.ST_Int = false;
            this.cpf_motorista.ST_LimpaCampo = true;
            this.cpf_motorista.ST_NotNull = false;
            this.cpf_motorista.ST_PrimaryKey = false;
            this.cpf_motorista.TabIndex = 4;
            this.cpf_motorista.TextOld = null;
            this.cpf_motorista.TextChanged += new System.EventHandler(this.cpf_motorista_TextChanged);
            this.cpf_motorista.Leave += new System.EventHandler(this.cpf_motorista_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(488, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 438;
            this.label17.Text = "Nº Requisição:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nr_requisicao
            // 
            this.nr_requisicao.BackColor = System.Drawing.SystemColors.Window;
            this.nr_requisicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_requisicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_requisicao.Location = new System.Drawing.Point(572, 4);
            this.nr_requisicao.Name = "nr_requisicao";
            this.nr_requisicao.NM_Alias = "";
            this.nr_requisicao.NM_Campo = "";
            this.nr_requisicao.NM_CampoBusca = "";
            this.nr_requisicao.NM_Param = "";
            this.nr_requisicao.QTD_Zero = 0;
            this.nr_requisicao.Size = new System.Drawing.Size(100, 20);
            this.nr_requisicao.ST_AutoInc = false;
            this.nr_requisicao.ST_DisableAuto = false;
            this.nr_requisicao.ST_Float = false;
            this.nr_requisicao.ST_Gravar = false;
            this.nr_requisicao.ST_Int = false;
            this.nr_requisicao.ST_LimpaCampo = true;
            this.nr_requisicao.ST_NotNull = false;
            this.nr_requisicao.ST_PrimaryKey = false;
            this.nr_requisicao.TabIndex = 3;
            this.nr_requisicao.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(339, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 431;
            this.label5.Text = "Nº Frota:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // placa
            // 
            this.placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placa.Location = new System.Drawing.Point(59, 5);
            this.placa.Mask = "AAA-AAAA";
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "";
            this.placa.NM_CampoBusca = "";
            this.placa.NM_Param = "";
            this.placa.Size = new System.Drawing.Size(75, 20);
            this.placa.ST_Gravar = true;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = false;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 0;
            this.placa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.placa_KeyPress);
            // 
            // nr_frota
            // 
            this.nr_frota.BackColor = System.Drawing.SystemColors.Window;
            this.nr_frota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_frota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_frota.Location = new System.Drawing.Point(394, 4);
            this.nr_frota.Name = "nr_frota";
            this.nr_frota.NM_Alias = "";
            this.nr_frota.NM_Campo = "";
            this.nr_frota.NM_CampoBusca = "";
            this.nr_frota.NM_Param = "";
            this.nr_frota.QTD_Zero = 0;
            this.nr_frota.Size = new System.Drawing.Size(88, 20);
            this.nr_frota.ST_AutoInc = false;
            this.nr_frota.ST_DisableAuto = false;
            this.nr_frota.ST_Float = false;
            this.nr_frota.ST_Gravar = false;
            this.nr_frota.ST_Int = false;
            this.nr_frota.ST_LimpaCampo = true;
            this.nr_frota.ST_NotNull = false;
            this.nr_frota.ST_PrimaryKey = false;
            this.nr_frota.TabIndex = 2;
            this.nr_frota.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 426;
            this.label2.Text = "Placa:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(181, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 427;
            this.label3.Text = "KM:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nm_motorista
            // 
            this.nm_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.nm_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_motorista.Location = new System.Drawing.Point(213, 31);
            this.nm_motorista.Name = "nm_motorista";
            this.nm_motorista.NM_Alias = "";
            this.nm_motorista.NM_Campo = "nm_clifor";
            this.nm_motorista.NM_CampoBusca = "nm_clifor";
            this.nm_motorista.NM_Param = "@P_NM_CLIFOR";
            this.nm_motorista.QTD_Zero = 0;
            this.nm_motorista.Size = new System.Drawing.Size(459, 20);
            this.nm_motorista.ST_AutoInc = false;
            this.nm_motorista.ST_DisableAuto = false;
            this.nm_motorista.ST_Float = false;
            this.nm_motorista.ST_Gravar = false;
            this.nm_motorista.ST_Int = false;
            this.nm_motorista.ST_LimpaCampo = true;
            this.nm_motorista.ST_NotNull = false;
            this.nm_motorista.ST_PrimaryKey = false;
            this.nm_motorista.TabIndex = 5;
            this.nm_motorista.TextOld = null;
            // 
            // km
            // 
            this.km.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.km.Location = new System.Drawing.Point(213, 5);
            this.km.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.km.Name = "km";
            this.km.NM_Alias = "";
            this.km.NM_Campo = "";
            this.km.NM_Param = "";
            this.km.Operador = "";
            this.km.Size = new System.Drawing.Size(120, 20);
            this.km.ST_AutoInc = false;
            this.km.ST_DisableAuto = false;
            this.km.ST_Gravar = true;
            this.km.ST_LimparCampo = true;
            this.km.ST_NotNull = false;
            this.km.ST_PrimaryKey = false;
            this.km.TabIndex = 1;
            this.km.ThousandsSeparator = true;
            this.km.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(0, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 428;
            this.label4.Text = "CPF Mot.:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFPlacaKM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 105);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "TFPlacaKM";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dados Abastecimento";
            this.Load += new System.EventHandler(this.TFPlacaKM_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFPlacaKM_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.km)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label20;
        private Componentes.EditDefault cpf_motorista;
        private System.Windows.Forms.Label label17;
        private Componentes.EditDefault nr_requisicao;
        private System.Windows.Forms.Label label5;
        private Componentes.EditMask placa;
        private Componentes.EditDefault nr_frota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nm_motorista;
        private Componentes.EditFloat km;
        private System.Windows.Forms.Label label4;
    }
}