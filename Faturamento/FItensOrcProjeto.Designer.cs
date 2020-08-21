namespace Faturamento
{
    partial class TFItensOrcProjeto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItensOrcProjeto));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.st_servico = new Componentes.CheckBoxDefault(this.components);
            this.bsItensOrcamento = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DS_Observacao = new Componentes.EditDefault(this.components);
            this.Sub_Total = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.label55 = new System.Windows.Forms.Label();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Total)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(594, 43);
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
            this.pDados.Controls.Add(this.st_servico);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.Sub_Total);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.DS_Observacao);
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.label55);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(594, 233);
            this.pDados.TabIndex = 12;
            // 
            // st_servico
            // 
            this.st_servico.AutoSize = true;
            this.st_servico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.st_servico.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsItensOrcamento, "St_servicobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_servico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_servico.Location = new System.Drawing.Point(515, 60);
            this.st_servico.Name = "st_servico";
            this.st_servico.NM_Alias = "";
            this.st_servico.NM_Campo = "";
            this.st_servico.NM_Param = "";
            this.st_servico.Size = new System.Drawing.Size(69, 17);
            this.st_servico.ST_Gravar = false;
            this.st_servico.ST_LimparCampo = true;
            this.st_servico.ST_NotNull = false;
            this.st_servico.TabIndex = 2;
            this.st_servico.Text = "Serviço";
            this.st_servico.UseVisualStyleBackColor = true;
            this.st_servico.Vl_False = "";
            this.st_servico.Vl_True = "";
            // 
            // bsItensOrcamento
            // 
            this.bsItensOrcamento.DataSource = typeof(CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 13);
            this.label1.TabIndex = 111;
            this.label1.Text = "Localiza produto por codigo interno, codigo de barras, codigo referencia ou parte" +
                " da descrição";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(63, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "Observações";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_Observacao
            // 
            this.DS_Observacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItensOrcamento, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Observacao.Location = new System.Drawing.Point(66, 142);
            this.DS_Observacao.Multiline = true;
            this.DS_Observacao.Name = "DS_Observacao";
            this.DS_Observacao.NM_Alias = "";
            this.DS_Observacao.NM_Campo = "ds_tecnica";
            this.DS_Observacao.NM_CampoBusca = "ds_tecnica";
            this.DS_Observacao.NM_Param = "@P_CD_UNIDADE";
            this.DS_Observacao.QTD_Zero = 0;
            this.DS_Observacao.Size = new System.Drawing.Size(518, 80);
            this.DS_Observacao.ST_AutoInc = false;
            this.DS_Observacao.ST_DisableAuto = false;
            this.DS_Observacao.ST_Float = false;
            this.DS_Observacao.ST_Gravar = true;
            this.DS_Observacao.ST_Int = false;
            this.DS_Observacao.ST_LimpaCampo = true;
            this.DS_Observacao.ST_NotNull = false;
            this.DS_Observacao.ST_PrimaryKey = false;
            this.DS_Observacao.TabIndex = 4;
            this.DS_Observacao.TextOld = null;
            // 
            // Sub_Total
            // 
            this.Sub_Total.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItensOrcamento, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Sub_Total.DecimalPlaces = 2;
            this.Sub_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Sub_Total.Location = new System.Drawing.Point(66, 96);
            this.Sub_Total.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Sub_Total.Name = "Sub_Total";
            this.Sub_Total.NM_Alias = "";
            this.Sub_Total.NM_Campo = "Vl_Unitario";
            this.Sub_Total.NM_Param = "@P_VL_UNITARIO";
            this.Sub_Total.Operador = "";
            this.Sub_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Sub_Total.Size = new System.Drawing.Size(174, 27);
            this.Sub_Total.ST_AutoInc = false;
            this.Sub_Total.ST_DisableAuto = false;
            this.Sub_Total.ST_Gravar = true;
            this.Sub_Total.ST_LimparCampo = true;
            this.Sub_Total.ST_NotNull = false;
            this.Sub_Total.ST_PrimaryKey = false;
            this.Sub_Total.TabIndex = 3;
            this.Sub_Total.ThousandsSeparator = true;
            this.Sub_Total.ValueChanged += new System.EventHandler(this.Sub_Total_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(63, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 115;
            this.label7.Text = "Valor Item";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItensOrcamento, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Location = new System.Drawing.Point(66, 57);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.Size = new System.Drawing.Size(443, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 1;
            this.DS_Produto.TextOld = null;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(8, 25);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(55, 13);
            this.label55.TabIndex = 109;
            this.label55.Text = "Produto:";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItensOrcamento, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_Produto.Location = new System.Drawing.Point(66, 22);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(518, 29);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = false;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 0;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.TextChanged += new System.EventHandler(this.CD_Produto_TextChanged);
            this.CD_Produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CD_Produto_KeyDown);
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // TFItensOrcProjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 276);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItensOrcProjeto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itens Orçamento Projeto";
            this.Load += new System.EventHandler(this.TFItensOrcProjeto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensOrcProjeto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Total)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.CheckBoxDefault st_servico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault DS_Observacao;
        private Componentes.EditFloat Sub_Total;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault DS_Produto;
        private System.Windows.Forms.Label label55;
        private Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.BindingSource bsItensOrcamento;
    }
}