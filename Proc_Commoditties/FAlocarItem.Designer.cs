namespace Proc_Commoditties
{
    partial class TFAlocarItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAlocarItem));
            System.Windows.Forms.Label label1;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_almox = new System.Windows.Forms.Button();
            this.ds_almoxarifado = new Componentes.EditDefault(this.components);
            this.id_almox = new Componentes.EditDefault(this.components);
            this.id_rua = new Componentes.EditDefault(this.components);
            this.ds_rua = new Componentes.EditDefault(this.components);
            this.id_secao = new Componentes.EditDefault(this.components);
            this.ds_secao = new Componentes.EditDefault(this.components);
            this.id_celula = new Componentes.EditDefault(this.components);
            this.ds_celula = new Componentes.EditDefault(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.quantidade = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(555, 43);
            this.barraMenu.TabIndex = 13;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.sigla_unidade);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.quantidade);
            this.pDados.Controls.Add(this.id_rua);
            this.pDados.Controls.Add(this.ds_rua);
            this.pDados.Controls.Add(this.id_secao);
            this.pDados.Controls.Add(this.ds_secao);
            this.pDados.Controls.Add(this.id_celula);
            this.pDados.Controls.Add(this.ds_celula);
            this.pDados.Controls.Add(this.label13);
            this.pDados.Controls.Add(this.label14);
            this.pDados.Controls.Add(this.label15);
            this.pDados.Controls.Add(this.bb_almox);
            this.pDados.Controls.Add(this.ds_almoxarifado);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.id_almox);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(555, 154);
            this.pDados.TabIndex = 14;
            // 
            // bb_almox
            // 
            this.bb_almox.BackColor = System.Drawing.SystemColors.Control;
            this.bb_almox.Image = ((System.Drawing.Image)(resources.GetObject("bb_almox.Image")));
            this.bb_almox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_almox.Location = new System.Drawing.Point(134, 29);
            this.bb_almox.Name = "bb_almox";
            this.bb_almox.Size = new System.Drawing.Size(28, 19);
            this.bb_almox.TabIndex = 1;
            this.bb_almox.UseVisualStyleBackColor = false;
            this.bb_almox.Click += new System.EventHandler(this.bb_almox_Click);
            // 
            // ds_almoxarifado
            // 
            this.ds_almoxarifado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_almoxarifado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_almoxarifado.Enabled = false;
            this.ds_almoxarifado.Location = new System.Drawing.Point(168, 29);
            this.ds_almoxarifado.Name = "ds_almoxarifado";
            this.ds_almoxarifado.NM_Alias = "";
            this.ds_almoxarifado.NM_Campo = "ds_almoxarifado";
            this.ds_almoxarifado.NM_CampoBusca = "ds_almoxarifado";
            this.ds_almoxarifado.NM_Param = "@P_NM_EMPRESA";
            this.ds_almoxarifado.QTD_Zero = 0;
            this.ds_almoxarifado.Size = new System.Drawing.Size(382, 20);
            this.ds_almoxarifado.ST_AutoInc = false;
            this.ds_almoxarifado.ST_DisableAuto = false;
            this.ds_almoxarifado.ST_Float = false;
            this.ds_almoxarifado.ST_Gravar = false;
            this.ds_almoxarifado.ST_Int = false;
            this.ds_almoxarifado.ST_LimpaCampo = true;
            this.ds_almoxarifado.ST_NotNull = false;
            this.ds_almoxarifado.ST_PrimaryKey = false;
            this.ds_almoxarifado.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(5, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(70, 13);
            label1.TabIndex = 14;
            label1.Text = "Almoxarifado:";
            // 
            // id_almox
            // 
            this.id_almox.BackColor = System.Drawing.SystemColors.Window;
            this.id_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_almox.Location = new System.Drawing.Point(81, 29);
            this.id_almox.Name = "id_almox";
            this.id_almox.NM_Alias = "";
            this.id_almox.NM_Campo = "id_almox";
            this.id_almox.NM_CampoBusca = "id_almox";
            this.id_almox.NM_Param = "@P_CD_EMPRESA";
            this.id_almox.QTD_Zero = 0;
            this.id_almox.Size = new System.Drawing.Size(51, 20);
            this.id_almox.ST_AutoInc = false;
            this.id_almox.ST_DisableAuto = false;
            this.id_almox.ST_Float = false;
            this.id_almox.ST_Gravar = true;
            this.id_almox.ST_Int = false;
            this.id_almox.ST_LimpaCampo = true;
            this.id_almox.ST_NotNull = true;
            this.id_almox.ST_PrimaryKey = false;
            this.id_almox.TabIndex = 0;
            this.id_almox.Leave += new System.EventHandler(this.id_almox_Leave);
            // 
            // id_rua
            // 
            this.id_rua.BackColor = System.Drawing.SystemColors.Window;
            this.id_rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_rua.Enabled = false;
            this.id_rua.Location = new System.Drawing.Point(81, 55);
            this.id_rua.Name = "id_rua";
            this.id_rua.NM_Alias = "";
            this.id_rua.NM_Campo = "id_rua";
            this.id_rua.NM_CampoBusca = "id_rua";
            this.id_rua.NM_Param = "@P_ID_RUA";
            this.id_rua.QTD_Zero = 0;
            this.id_rua.Size = new System.Drawing.Size(51, 20);
            this.id_rua.ST_AutoInc = false;
            this.id_rua.ST_DisableAuto = false;
            this.id_rua.ST_Float = false;
            this.id_rua.ST_Gravar = false;
            this.id_rua.ST_Int = false;
            this.id_rua.ST_LimpaCampo = true;
            this.id_rua.ST_NotNull = false;
            this.id_rua.ST_PrimaryKey = false;
            this.id_rua.TabIndex = 153;
            // 
            // ds_rua
            // 
            this.ds_rua.BackColor = System.Drawing.Color.White;
            this.ds_rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_rua.Enabled = false;
            this.ds_rua.Location = new System.Drawing.Point(134, 55);
            this.ds_rua.Name = "ds_rua";
            this.ds_rua.NM_Alias = "";
            this.ds_rua.NM_Campo = "ds_rua";
            this.ds_rua.NM_CampoBusca = "ds_rua";
            this.ds_rua.NM_Param = "@P_DS_RUA";
            this.ds_rua.QTD_Zero = 0;
            this.ds_rua.Size = new System.Drawing.Size(416, 20);
            this.ds_rua.ST_AutoInc = false;
            this.ds_rua.ST_DisableAuto = false;
            this.ds_rua.ST_Float = false;
            this.ds_rua.ST_Gravar = false;
            this.ds_rua.ST_Int = false;
            this.ds_rua.ST_LimpaCampo = true;
            this.ds_rua.ST_NotNull = false;
            this.ds_rua.ST_PrimaryKey = false;
            this.ds_rua.TabIndex = 161;
            // 
            // id_secao
            // 
            this.id_secao.BackColor = System.Drawing.SystemColors.Window;
            this.id_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_secao.Enabled = false;
            this.id_secao.Location = new System.Drawing.Point(81, 78);
            this.id_secao.Name = "id_secao";
            this.id_secao.NM_Alias = "";
            this.id_secao.NM_Campo = "id_secao";
            this.id_secao.NM_CampoBusca = "id_secao";
            this.id_secao.NM_Param = "@P_ID_SECAO";
            this.id_secao.QTD_Zero = 0;
            this.id_secao.Size = new System.Drawing.Size(51, 20);
            this.id_secao.ST_AutoInc = false;
            this.id_secao.ST_DisableAuto = false;
            this.id_secao.ST_Float = false;
            this.id_secao.ST_Gravar = false;
            this.id_secao.ST_Int = false;
            this.id_secao.ST_LimpaCampo = true;
            this.id_secao.ST_NotNull = false;
            this.id_secao.ST_PrimaryKey = false;
            this.id_secao.TabIndex = 154;
            // 
            // ds_secao
            // 
            this.ds_secao.BackColor = System.Drawing.Color.White;
            this.ds_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_secao.Enabled = false;
            this.ds_secao.Location = new System.Drawing.Point(134, 78);
            this.ds_secao.Name = "ds_secao";
            this.ds_secao.NM_Alias = "";
            this.ds_secao.NM_Campo = "ds_secao";
            this.ds_secao.NM_CampoBusca = "ds_secao";
            this.ds_secao.NM_Param = "@P_DS_SECAO";
            this.ds_secao.QTD_Zero = 0;
            this.ds_secao.Size = new System.Drawing.Size(416, 20);
            this.ds_secao.ST_AutoInc = false;
            this.ds_secao.ST_DisableAuto = false;
            this.ds_secao.ST_Float = false;
            this.ds_secao.ST_Gravar = false;
            this.ds_secao.ST_Int = false;
            this.ds_secao.ST_LimpaCampo = true;
            this.ds_secao.ST_NotNull = false;
            this.ds_secao.ST_PrimaryKey = false;
            this.ds_secao.TabIndex = 160;
            // 
            // id_celula
            // 
            this.id_celula.BackColor = System.Drawing.SystemColors.Window;
            this.id_celula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_celula.Enabled = false;
            this.id_celula.Location = new System.Drawing.Point(81, 103);
            this.id_celula.Name = "id_celula";
            this.id_celula.NM_Alias = "";
            this.id_celula.NM_Campo = "id_nivel";
            this.id_celula.NM_CampoBusca = "id_nivel";
            this.id_celula.NM_Param = "@P_ID_NIVEL";
            this.id_celula.QTD_Zero = 0;
            this.id_celula.Size = new System.Drawing.Size(51, 20);
            this.id_celula.ST_AutoInc = false;
            this.id_celula.ST_DisableAuto = false;
            this.id_celula.ST_Float = false;
            this.id_celula.ST_Gravar = false;
            this.id_celula.ST_Int = false;
            this.id_celula.ST_LimpaCampo = true;
            this.id_celula.ST_NotNull = false;
            this.id_celula.ST_PrimaryKey = false;
            this.id_celula.TabIndex = 155;
            // 
            // ds_celula
            // 
            this.ds_celula.BackColor = System.Drawing.Color.White;
            this.ds_celula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_celula.Enabled = false;
            this.ds_celula.Location = new System.Drawing.Point(134, 103);
            this.ds_celula.Name = "ds_celula";
            this.ds_celula.NM_Alias = "";
            this.ds_celula.NM_Campo = "ds_nivel";
            this.ds_celula.NM_CampoBusca = "ds_nivel";
            this.ds_celula.NM_Param = "@P_DS_NIVEL";
            this.ds_celula.QTD_Zero = 0;
            this.ds_celula.Size = new System.Drawing.Size(416, 20);
            this.ds_celula.ST_AutoInc = false;
            this.ds_celula.ST_DisableAuto = false;
            this.ds_celula.ST_Float = false;
            this.ds_celula.ST_Gravar = false;
            this.ds_celula.ST_Int = false;
            this.ds_celula.ST_LimpaCampo = true;
            this.ds_celula.ST_NotNull = false;
            this.ds_celula.ST_PrimaryKey = false;
            this.ds_celula.TabIndex = 159;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 158;
            this.label13.Text = "Rua:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 157;
            this.label14.Text = "Seção:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(37, 106);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 156;
            this.label15.Text = "Celula:";
            // 
            // quantidade
            // 
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Location = new System.Drawing.Point(81, 129);
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
            this.quantidade.Size = new System.Drawing.Size(120, 20);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = false;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = false;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 2;
            this.quantidade.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 163;
            this.label2.Text = "Quantidade:";
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Enabled = false;
            this.cd_produto.Location = new System.Drawing.Point(81, 3);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "id_rua";
            this.cd_produto.NM_CampoBusca = "id_rua";
            this.cd_produto.NM_Param = "@P_ID_RUA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(51, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = false;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 164;
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.Color.White;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(134, 3);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_rua";
            this.ds_produto.NM_CampoBusca = "ds_rua";
            this.ds_produto.NM_Param = "@P_DS_RUA";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(416, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 166;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 165;
            this.label3.Text = "Produto:";
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.Color.White;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Location = new System.Drawing.Point(203, 129);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "ds_rua";
            this.sigla_unidade.NM_CampoBusca = "ds_rua";
            this.sigla_unidade.NM_Param = "@P_DS_RUA";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.Size = new System.Drawing.Size(36, 20);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 167;
            // 
            // TFAlocarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 197);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAlocarItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alocar Item Almoxarifado";
            this.Load += new System.EventHandler(this.TFAlocarItem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAlocarItem_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Button bb_almox;
        private Componentes.EditDefault ds_almoxarifado;
        private Componentes.EditDefault id_almox;
        private Componentes.EditDefault id_rua;
        private Componentes.EditDefault ds_rua;
        private Componentes.EditDefault id_secao;
        private Componentes.EditDefault ds_secao;
        private Componentes.EditDefault id_celula;
        private Componentes.EditDefault ds_celula;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat quantidade;
        private Componentes.EditDefault sigla_unidade;
    }
}