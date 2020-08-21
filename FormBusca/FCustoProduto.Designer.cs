namespace FormBusca
{
    partial class TFCustoProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCustoProduto));
            this.pDados = new Componentes.PanelDados(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.vl_medio = new Componentes.EditFloat(this.components);
            this.und = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.qtd_estoque = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vl_ultimacompra = new Componentes.EditFloat(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.pDados.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_medio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_estoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_ultimacompra)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.panelDados1);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 0);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(558, 164);
            this.pDados.TabIndex = 0;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.vl_medio);
            this.panelDados1.Controls.Add(this.und);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.qtd_estoque);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.vl_ultimacompra);
            this.panelDados1.Location = new System.Drawing.Point(15, 90);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(531, 58);
            this.panelDados1.TabIndex = 13;
            // 
            // vl_medio
            // 
            this.vl_medio.DecimalPlaces = 2;
            this.vl_medio.Enabled = false;
            this.vl_medio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_medio.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_medio.Location = new System.Drawing.Point(364, 25);
            this.vl_medio.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_medio.Name = "vl_medio";
            this.vl_medio.NM_Alias = "";
            this.vl_medio.NM_Campo = "";
            this.vl_medio.NM_Param = "";
            this.vl_medio.Operador = "";
            this.vl_medio.Size = new System.Drawing.Size(155, 26);
            this.vl_medio.ST_AutoInc = false;
            this.vl_medio.ST_DisableAuto = false;
            this.vl_medio.ST_Gravar = false;
            this.vl_medio.ST_LimparCampo = true;
            this.vl_medio.ST_NotNull = false;
            this.vl_medio.ST_PrimaryKey = false;
            this.vl_medio.TabIndex = 11;
            this.vl_medio.ThousandsSeparator = true;
            // 
            // und
            // 
            this.und.BackColor = System.Drawing.SystemColors.Window;
            this.und.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.und.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.und.Enabled = false;
            this.und.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.und.Location = new System.Drawing.Point(167, 25);
            this.und.Name = "und";
            this.und.NM_Alias = "";
            this.und.NM_Campo = "";
            this.und.NM_CampoBusca = "";
            this.und.NM_Param = "";
            this.und.QTD_Zero = 0;
            this.und.Size = new System.Drawing.Size(59, 26);
            this.und.ST_AutoInc = false;
            this.und.ST_DisableAuto = false;
            this.und.ST_Float = false;
            this.und.ST_Gravar = false;
            this.und.ST_Int = false;
            this.und.ST_LimpaCampo = true;
            this.und.ST_NotNull = false;
            this.und.ST_PrimaryKey = false;
            this.und.TabIndex = 12;
            this.und.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quantidade Estoque";
            // 
            // qtd_estoque
            // 
            this.qtd_estoque.DecimalPlaces = 3;
            this.qtd_estoque.Enabled = false;
            this.qtd_estoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtd_estoque.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qtd_estoque.Location = new System.Drawing.Point(13, 25);
            this.qtd_estoque.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_estoque.Name = "qtd_estoque";
            this.qtd_estoque.NM_Alias = "";
            this.qtd_estoque.NM_Campo = "";
            this.qtd_estoque.NM_Param = "";
            this.qtd_estoque.Operador = "";
            this.qtd_estoque.Size = new System.Drawing.Size(153, 26);
            this.qtd_estoque.ST_AutoInc = false;
            this.qtd_estoque.ST_DisableAuto = false;
            this.qtd_estoque.ST_Gravar = false;
            this.qtd_estoque.ST_LimparCampo = true;
            this.qtd_estoque.ST_NotNull = false;
            this.qtd_estoque.ST_PrimaryKey = false;
            this.qtd_estoque.TabIndex = 7;
            this.qtd_estoque.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(361, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Valor Médio Estoque";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(229, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ultima Compra";
            // 
            // vl_ultimacompra
            // 
            this.vl_ultimacompra.DecimalPlaces = 2;
            this.vl_ultimacompra.Enabled = false;
            this.vl_ultimacompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_ultimacompra.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_ultimacompra.Location = new System.Drawing.Point(232, 25);
            this.vl_ultimacompra.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_ultimacompra.Name = "vl_ultimacompra";
            this.vl_ultimacompra.NM_Alias = "";
            this.vl_ultimacompra.NM_Campo = "";
            this.vl_ultimacompra.NM_Param = "";
            this.vl_ultimacompra.Operador = "";
            this.vl_ultimacompra.Size = new System.Drawing.Size(126, 26);
            this.vl_ultimacompra.ST_AutoInc = false;
            this.vl_ultimacompra.ST_DisableAuto = false;
            this.vl_ultimacompra.ST_Gravar = false;
            this.vl_ultimacompra.ST_LimparCampo = true;
            this.vl_ultimacompra.ST_NotNull = false;
            this.vl_ultimacompra.ST_PrimaryKey = false;
            this.vl_ultimacompra.TabIndex = 9;
            this.vl_ultimacompra.ThousandsSeparator = true;
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(115, 64);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "";
            this.ds_produto.NM_CampoBusca = "";
            this.ds_produto.NM_Param = "";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(431, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 5;
            this.ds_produto.TextOld = null;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Enabled = false;
            this.cd_produto.Location = new System.Drawing.Point(15, 64);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "";
            this.cd_produto.NM_CampoBusca = "";
            this.cd_produto.NM_Param = "";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(98, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = false;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 4;
            this.cd_produto.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Produto";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(97, 25);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(449, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 2;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(15, 25);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(45, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 1;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa";
            // 
            // bb_empresa
            // 
            this.bb_empresa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(61, 24);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(30, 21);
            this.bb_empresa.TabIndex = 37;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // TFCustoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 164);
            this.Controls.Add(this.pDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCustoProduto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes Produto";
            this.Load += new System.EventHandler(this.TFCustoProduto_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_medio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_estoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_ultimacompra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pDados;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat vl_medio;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat vl_ultimacompra;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat qtd_estoque;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault und;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Button bb_empresa;
    }
}