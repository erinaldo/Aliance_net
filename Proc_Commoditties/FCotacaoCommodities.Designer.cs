namespace Proc_Commoditties
{
    partial class TFCotacaoCommodities
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCotacaoCommodities));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.ds_unidade = new Componentes.EditDefault(this.components);
            this.bb_unidade = new System.Windows.Forms.Button();
            this.cd_unidade = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.vl_precovenda = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vl_precocompra = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dt_cotacao = new Componentes.EditMask(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_precovenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_precocompra)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(444, 43);
            this.barraMenu.TabIndex = 14;
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.dt_cotacao);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.ds_unidade);
            this.panelDados1.Controls.Add(this.bb_unidade);
            this.panelDados1.Controls.Add(this.cd_unidade);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.vl_precovenda);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.vl_precocompra);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.ds_produto);
            this.panelDados1.Controls.Add(this.cd_produto);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(444, 138);
            this.panelDados1.TabIndex = 0;
            // 
            // ds_unidade
            // 
            this.ds_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.ds_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_unidade.Enabled = false;
            this.ds_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_unidade.Location = new System.Drawing.Point(123, 66);
            this.ds_unidade.Name = "ds_unidade";
            this.ds_unidade.NM_Alias = "";
            this.ds_unidade.NM_Campo = "ds_unidade";
            this.ds_unidade.NM_CampoBusca = "ds_unidade";
            this.ds_unidade.NM_Param = "@P_NM_EMPRESA";
            this.ds_unidade.QTD_Zero = 0;
            this.ds_unidade.ReadOnly = true;
            this.ds_unidade.Size = new System.Drawing.Size(309, 20);
            this.ds_unidade.ST_AutoInc = false;
            this.ds_unidade.ST_DisableAuto = false;
            this.ds_unidade.ST_Float = false;
            this.ds_unidade.ST_Gravar = false;
            this.ds_unidade.ST_Int = false;
            this.ds_unidade.ST_LimpaCampo = true;
            this.ds_unidade.ST_NotNull = false;
            this.ds_unidade.ST_PrimaryKey = false;
            this.ds_unidade.TabIndex = 427;
            this.ds_unidade.TextOld = null;
            // 
            // bb_unidade
            // 
            this.bb_unidade.Image = ((System.Drawing.Image)(resources.GetObject("bb_unidade.Image")));
            this.bb_unidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_unidade.Location = new System.Drawing.Point(92, 66);
            this.bb_unidade.Name = "bb_unidade";
            this.bb_unidade.Size = new System.Drawing.Size(28, 19);
            this.bb_unidade.TabIndex = 1;
            this.bb_unidade.UseVisualStyleBackColor = true;
            this.bb_unidade.Click += new System.EventHandler(this.bb_unidade_Click);
            // 
            // cd_unidade
            // 
            this.cd_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.cd_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_unidade.Location = new System.Drawing.Point(15, 66);
            this.cd_unidade.Name = "cd_unidade";
            this.cd_unidade.NM_Alias = "";
            this.cd_unidade.NM_Campo = "cd_unidade";
            this.cd_unidade.NM_CampoBusca = "cd_unidade";
            this.cd_unidade.NM_Param = "@P_CD_EMPRESA";
            this.cd_unidade.QTD_Zero = 0;
            this.cd_unidade.Size = new System.Drawing.Size(75, 20);
            this.cd_unidade.ST_AutoInc = false;
            this.cd_unidade.ST_DisableAuto = false;
            this.cd_unidade.ST_Float = false;
            this.cd_unidade.ST_Gravar = true;
            this.cd_unidade.ST_Int = true;
            this.cd_unidade.ST_LimpaCampo = true;
            this.cd_unidade.ST_NotNull = true;
            this.cd_unidade.ST_PrimaryKey = false;
            this.cd_unidade.TabIndex = 0;
            this.cd_unidade.TextOld = null;
            this.cd_unidade.Leave += new System.EventHandler(this.cd_unidade_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Unidade";
            // 
            // vl_precovenda
            // 
            this.vl_precovenda.DecimalPlaces = 2;
            this.vl_precovenda.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_precovenda.Location = new System.Drawing.Point(141, 105);
            this.vl_precovenda.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_precovenda.Name = "vl_precovenda";
            this.vl_precovenda.NM_Alias = "";
            this.vl_precovenda.NM_Campo = "";
            this.vl_precovenda.NM_Param = "";
            this.vl_precovenda.Operador = "";
            this.vl_precovenda.Size = new System.Drawing.Size(120, 20);
            this.vl_precovenda.ST_AutoInc = false;
            this.vl_precovenda.ST_DisableAuto = false;
            this.vl_precovenda.ST_Gravar = false;
            this.vl_precovenda.ST_LimparCampo = true;
            this.vl_precovenda.ST_NotNull = false;
            this.vl_precovenda.ST_PrimaryKey = false;
            this.vl_precovenda.TabIndex = 3;
            this.vl_precovenda.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vl. Venda";
            // 
            // vl_precocompra
            // 
            this.vl_precocompra.DecimalPlaces = 2;
            this.vl_precocompra.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_precocompra.Location = new System.Drawing.Point(15, 105);
            this.vl_precocompra.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_precocompra.Name = "vl_precocompra";
            this.vl_precocompra.NM_Alias = "";
            this.vl_precocompra.NM_Campo = "";
            this.vl_precocompra.NM_Param = "";
            this.vl_precocompra.Operador = "";
            this.vl_precocompra.Size = new System.Drawing.Size(120, 20);
            this.vl_precocompra.ST_AutoInc = false;
            this.vl_precocompra.ST_DisableAuto = false;
            this.vl_precocompra.ST_Gravar = false;
            this.vl_precocompra.ST_LimparCampo = true;
            this.vl_precocompra.ST_NotNull = false;
            this.vl_precocompra.ST_PrimaryKey = false;
            this.vl_precocompra.TabIndex = 2;
            this.vl_precocompra.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vl. Compra";
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(102, 27);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "";
            this.ds_produto.NM_CampoBusca = "";
            this.ds_produto.NM_Param = "";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(330, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 2;
            this.ds_produto.TextOld = null;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Enabled = false;
            this.cd_produto.Location = new System.Drawing.Point(15, 27);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "";
            this.cd_produto.NM_CampoBusca = "";
            this.cd_produto.NM_Param = "";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(84, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = false;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 1;
            this.cd_produto.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 428;
            this.label5.Text = "Dt. Cotação";
            // 
            // dt_cotacao
            // 
            this.dt_cotacao.Location = new System.Drawing.Point(267, 105);
            this.dt_cotacao.Mask = "00/00/0000 90:00";
            this.dt_cotacao.Name = "dt_cotacao";
            this.dt_cotacao.NM_Alias = "";
            this.dt_cotacao.NM_Campo = "";
            this.dt_cotacao.NM_CampoBusca = "";
            this.dt_cotacao.NM_Param = "";
            this.dt_cotacao.Size = new System.Drawing.Size(101, 20);
            this.dt_cotacao.ST_Gravar = false;
            this.dt_cotacao.ST_LimpaCampo = true;
            this.dt_cotacao.ST_NotNull = false;
            this.dt_cotacao.ST_PrimaryKey = false;
            this.dt_cotacao.TabIndex = 429;
            this.dt_cotacao.ValidatingType = typeof(System.DateTime);
            // 
            // TFCotacaoCommodities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 181);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCotacaoCommodities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizar Cotação Commodities";
            this.Load += new System.EventHandler(this.TFCotacaoCommodities_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCotacaoCommodities_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_precovenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_precocompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditFloat vl_precovenda;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat vl_precocompra;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault ds_unidade;
        private System.Windows.Forms.Button bb_unidade;
        private Componentes.EditDefault cd_unidade;
        private Componentes.EditMask dt_cotacao;
        private System.Windows.Forms.Label label5;
    }
}