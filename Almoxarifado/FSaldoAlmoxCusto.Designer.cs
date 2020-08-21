namespace Almoxarifado
{
    partial class TFSaldoAlmoxCusto
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label cd_empresaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFSaldoAlmoxCusto));
            this.pSaldoAlmox = new Componentes.PanelDados(this.components);
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.quantidade = new Componentes.EditFloat(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.bb_almox = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ds_almox = new Componentes.EditDefault(this.components);
            this.id_almox = new Componentes.EditDefault(this.components);
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            this.pSaldoAlmox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pSaldoAlmox
            // 
            this.pSaldoAlmox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSaldoAlmox.Controls.Add(this.bb_almox);
            this.pSaldoAlmox.Controls.Add(this.label5);
            this.pSaldoAlmox.Controls.Add(this.ds_almox);
            this.pSaldoAlmox.Controls.Add(this.id_almox);
            this.pSaldoAlmox.Controls.Add(this.vl_subtotal);
            this.pSaldoAlmox.Controls.Add(label4);
            this.pSaldoAlmox.Controls.Add(this.vl_unitario);
            this.pSaldoAlmox.Controls.Add(label3);
            this.pSaldoAlmox.Controls.Add(this.quantidade);
            this.pSaldoAlmox.Controls.Add(label2);
            this.pSaldoAlmox.Controls.Add(this.nm_empresa);
            this.pSaldoAlmox.Controls.Add(this.bb_empresa);
            this.pSaldoAlmox.Controls.Add(this.cd_empresa);
            this.pSaldoAlmox.Controls.Add(cd_empresaLabel);
            this.pSaldoAlmox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSaldoAlmox.Location = new System.Drawing.Point(0, 43);
            this.pSaldoAlmox.Name = "pSaldoAlmox";
            this.pSaldoAlmox.NM_ProcDeletar = "";
            this.pSaldoAlmox.NM_ProcGravar = "";
            this.pSaldoAlmox.Size = new System.Drawing.Size(470, 131);
            this.pSaldoAlmox.TabIndex = 5;
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Enabled = false;
            this.vl_subtotal.Location = new System.Drawing.Point(257, 97);
            this.vl_subtotal.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_subtotal.Name = "vl_subtotal";
            this.vl_subtotal.NM_Alias = "";
            this.vl_subtotal.NM_Campo = "";
            this.vl_subtotal.NM_Param = "";
            this.vl_subtotal.Operador = "";
            this.vl_subtotal.Size = new System.Drawing.Size(107, 20);
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = false;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = false;
            this.vl_subtotal.ST_PrimaryKey = false;
            this.vl_subtotal.TabIndex = 129;
            this.vl_subtotal.ThousandsSeparator = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(254, 81);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(61, 13);
            label4.TabIndex = 128;
            label4.Text = "Custo Total";
            // 
            // vl_unitario
            // 
            this.vl_unitario.DecimalPlaces = 5;
            this.vl_unitario.Location = new System.Drawing.Point(122, 97);
            this.vl_unitario.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_unitario.Name = "vl_unitario";
            this.vl_unitario.NM_Alias = "";
            this.vl_unitario.NM_Campo = "";
            this.vl_unitario.NM_Param = "";
            this.vl_unitario.Operador = "";
            this.vl_unitario.Size = new System.Drawing.Size(107, 20);
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = false;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = false;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.TabIndex = 5;
            this.vl_unitario.ThousandsSeparator = true;
            this.vl_unitario.Leave += new System.EventHandler(this.vl_unitario_Leave);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(119, 81);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 13);
            label3.TabIndex = 126;
            label3.Text = "Vl. Custo";
            // 
            // quantidade
            // 
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Location = new System.Drawing.Point(9, 97);
            this.quantidade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.quantidade.Name = "quantidade";
            this.quantidade.NM_Alias = "";
            this.quantidade.NM_Campo = "";
            this.quantidade.NM_Param = "";
            this.quantidade.Operador = "";
            this.quantidade.Size = new System.Drawing.Size(107, 20);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = false;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = false;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 4;
            this.quantidade.ThousandsSeparator = true;
            this.quantidade.Leave += new System.EventHandler(this.quantidade_Leave);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(6, 81);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 13);
            label2.TabIndex = 124;
            label2.Text = "Quantidade";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(108, 19);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(349, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 119;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(74, 19);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(6, 19);
            this.cd_empresa.MaxLength = 4;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(67, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(3, 3);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(48, 13);
            cd_empresaLabel.TabIndex = 118;
            cd_empresaLabel.Text = "Empresa";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(470, 43);
            this.barraMenu.TabIndex = 6;
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
            // bb_almox
            // 
            this.bb_almox.BackColor = System.Drawing.SystemColors.Control;
            this.bb_almox.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_almox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_almox.Image = ((System.Drawing.Image)(resources.GetObject("bb_almox.Image")));
            this.bb_almox.Location = new System.Drawing.Point(74, 58);
            this.bb_almox.Name = "bb_almox";
            this.bb_almox.Size = new System.Drawing.Size(28, 19);
            this.bb_almox.TabIndex = 131;
            this.bb_almox.UseVisualStyleBackColor = false;
            this.bb_almox.Click += new System.EventHandler(this.bb_almox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 133;
            this.label5.Text = "Almoxarifado:";
            // 
            // ds_almox
            // 
            this.ds_almox.BackColor = System.Drawing.SystemColors.Window;
            this.ds_almox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_almox.Enabled = false;
            this.ds_almox.Location = new System.Drawing.Point(108, 58);
            this.ds_almox.MaxLength = 20;
            this.ds_almox.Name = "ds_almox";
            this.ds_almox.NM_Alias = "";
            this.ds_almox.NM_Campo = "ds_almoxarifado";
            this.ds_almox.NM_CampoBusca = "ds_almoxarifado";
            this.ds_almox.NM_Param = "";
            this.ds_almox.QTD_Zero = 0;
            this.ds_almox.Size = new System.Drawing.Size(349, 20);
            this.ds_almox.ST_AutoInc = false;
            this.ds_almox.ST_DisableAuto = false;
            this.ds_almox.ST_Float = false;
            this.ds_almox.ST_Gravar = false;
            this.ds_almox.ST_Int = false;
            this.ds_almox.ST_LimpaCampo = true;
            this.ds_almox.ST_NotNull = false;
            this.ds_almox.ST_PrimaryKey = false;
            this.ds_almox.TabIndex = 132;
            this.ds_almox.TextOld = null;
            // 
            // id_almox
            // 
            this.id_almox.BackColor = System.Drawing.SystemColors.Window;
            this.id_almox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_almox.Location = new System.Drawing.Point(6, 58);
            this.id_almox.MaxLength = 5;
            this.id_almox.Name = "id_almox";
            this.id_almox.NM_Alias = "a";
            this.id_almox.NM_Campo = "id_almox";
            this.id_almox.NM_CampoBusca = "id_almox";
            this.id_almox.NM_Param = "@P_ID_ALMOX";
            this.id_almox.QTD_Zero = 0;
            this.id_almox.Size = new System.Drawing.Size(67, 20);
            this.id_almox.ST_AutoInc = false;
            this.id_almox.ST_DisableAuto = false;
            this.id_almox.ST_Float = false;
            this.id_almox.ST_Gravar = true;
            this.id_almox.ST_Int = true;
            this.id_almox.ST_LimpaCampo = true;
            this.id_almox.ST_NotNull = true;
            this.id_almox.ST_PrimaryKey = false;
            this.id_almox.TabIndex = 130;
            this.id_almox.TextOld = null;
            this.id_almox.Leave += new System.EventHandler(this.id_almox_Leave);
            // 
            // TFSaldoAlmoxCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 174);
            this.Controls.Add(this.pSaldoAlmox);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFSaldoAlmoxCusto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saldo Almoxarifado/ Custo Produto";
            this.Load += new System.EventHandler(this.TFSaldoAlmoxCusto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFSaldoAlmoxCusto_KeyDown);
            this.pSaldoAlmox.ResumeLayout(false);
            this.pSaldoAlmox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.PanelDados pSaldoAlmox;
        private Componentes.EditFloat vl_subtotal;
        private Componentes.EditFloat vl_unitario;
        private Componentes.EditFloat quantidade;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        public System.Windows.Forms.Button bb_almox;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault ds_almox;
        private Componentes.EditDefault id_almox;
    }
}