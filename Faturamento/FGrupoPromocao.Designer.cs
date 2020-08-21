namespace Faturamento
{
    partial class TFGrupoPromocao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFGrupoPromocao));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bsGrupo = new System.Windows.Forms.BindingSource(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.qtd_minimavenda = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.vl_promocao = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tp_promocao = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_grupo = new Componentes.EditDefault(this.components);
            this.bb_grupo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_grupo = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_minimavenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_promocao)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(543, 43);
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
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.qtd_minimavenda);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.vl_promocao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.tp_promocao);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_grupo);
            this.pDados.Controls.Add(this.bb_grupo);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_grupo);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(543, 90);
            this.pDados.TabIndex = 0;
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGrupo, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_produto.Location = new System.Drawing.Point(203, 32);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_NM_EMPRESA";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.ReadOnly = true;
            this.ds_produto.Size = new System.Drawing.Size(326, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 40;
            this.ds_produto.TextOld = null;
            // 
            // bsGrupo
            // 
            this.bsGrupo.DataSource = typeof(CamadaDados.Faturamento.Promocao.TList_Promocao_X_Grupo);
            // 
            // bb_produto
            // 
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(172, 32);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 3;
            this.bb_produto.UseVisualStyleBackColor = true;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(42, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Produto:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGrupo, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(95, 32);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(75, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 2;
            this.cd_produto.TextOld = null;
            this.cd_produto.EnabledChanged += new System.EventHandler(this.cd_produto_EnabledChanged);
            this.cd_produto.TextChanged += new System.EventHandler(this.cd_produto_TextChanged);
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // qtd_minimavenda
            // 
            this.qtd_minimavenda.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsGrupo, "Qtd_minimavenda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_minimavenda.DecimalPlaces = 3;
            this.qtd_minimavenda.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qtd_minimavenda.Location = new System.Drawing.Point(452, 58);
            this.qtd_minimavenda.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_minimavenda.Name = "qtd_minimavenda";
            this.qtd_minimavenda.NM_Alias = "";
            this.qtd_minimavenda.NM_Campo = "";
            this.qtd_minimavenda.NM_Param = "";
            this.qtd_minimavenda.Operador = "";
            this.qtd_minimavenda.Size = new System.Drawing.Size(77, 20);
            this.qtd_minimavenda.ST_AutoInc = false;
            this.qtd_minimavenda.ST_DisableAuto = false;
            this.qtd_minimavenda.ST_Gravar = true;
            this.qtd_minimavenda.ST_LimparCampo = true;
            this.qtd_minimavenda.ST_NotNull = false;
            this.qtd_minimavenda.ST_PrimaryKey = false;
            this.qtd_minimavenda.TabIndex = 6;
            this.qtd_minimavenda.ThousandsSeparator = true;
            this.qtd_minimavenda.ValueOld = new decimal(new int[] {
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
            this.label4.Location = new System.Drawing.Point(346, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Qtd. Minima Venda:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vl_promocao
            // 
            this.vl_promocao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsGrupo, "Vl_promocao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_promocao.DecimalPlaces = 2;
            this.vl_promocao.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_promocao.Location = new System.Drawing.Point(246, 59);
            this.vl_promocao.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_promocao.Name = "vl_promocao";
            this.vl_promocao.NM_Alias = "";
            this.vl_promocao.NM_Campo = "";
            this.vl_promocao.NM_Param = "";
            this.vl_promocao.Operador = "";
            this.vl_promocao.Size = new System.Drawing.Size(94, 20);
            this.vl_promocao.ST_AutoInc = false;
            this.vl_promocao.ST_DisableAuto = false;
            this.vl_promocao.ST_Gravar = true;
            this.vl_promocao.ST_LimparCampo = true;
            this.vl_promocao.ST_NotNull = true;
            this.vl_promocao.ST_PrimaryKey = false;
            this.vl_promocao.TabIndex = 5;
            this.vl_promocao.ThousandsSeparator = true;
            this.vl_promocao.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(206, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Valor:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_promocao
            // 
            this.tp_promocao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsGrupo, "Tp_promocao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_promocao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_promocao.FormattingEnabled = true;
            this.tp_promocao.Location = new System.Drawing.Point(95, 58);
            this.tp_promocao.Name = "tp_promocao";
            this.tp_promocao.NM_Alias = "";
            this.tp_promocao.NM_Campo = "";
            this.tp_promocao.NM_Param = "";
            this.tp_promocao.Size = new System.Drawing.Size(105, 21);
            this.tp_promocao.ST_Gravar = true;
            this.tp_promocao.ST_LimparCampo = true;
            this.tp_promocao.ST_NotNull = true;
            this.tp_promocao.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Tipo Promoção:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_grupo
            // 
            this.ds_grupo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGrupo, "Ds_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_grupo.Enabled = false;
            this.ds_grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_grupo.Location = new System.Drawing.Point(203, 6);
            this.ds_grupo.Name = "ds_grupo";
            this.ds_grupo.NM_Alias = "";
            this.ds_grupo.NM_Campo = "ds_grupo";
            this.ds_grupo.NM_CampoBusca = "ds_grupo";
            this.ds_grupo.NM_Param = "@P_NM_EMPRESA";
            this.ds_grupo.QTD_Zero = 0;
            this.ds_grupo.ReadOnly = true;
            this.ds_grupo.Size = new System.Drawing.Size(326, 20);
            this.ds_grupo.ST_AutoInc = false;
            this.ds_grupo.ST_DisableAuto = false;
            this.ds_grupo.ST_Float = false;
            this.ds_grupo.ST_Gravar = false;
            this.ds_grupo.ST_Int = false;
            this.ds_grupo.ST_LimpaCampo = true;
            this.ds_grupo.ST_NotNull = false;
            this.ds_grupo.ST_PrimaryKey = false;
            this.ds_grupo.TabIndex = 30;
            this.ds_grupo.TextOld = null;
            // 
            // bb_grupo
            // 
            this.bb_grupo.Image = ((System.Drawing.Image)(resources.GetObject("bb_grupo.Image")));
            this.bb_grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_grupo.Location = new System.Drawing.Point(172, 6);
            this.bb_grupo.Name = "bb_grupo";
            this.bb_grupo.Size = new System.Drawing.Size(28, 19);
            this.bb_grupo.TabIndex = 1;
            this.bb_grupo.UseVisualStyleBackColor = true;
            this.bb_grupo.Click += new System.EventHandler(this.bb_grupo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Grupo Produto:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_grupo
            // 
            this.cd_grupo.BackColor = System.Drawing.SystemColors.Window;
            this.cd_grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGrupo, "Cd_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_grupo.Location = new System.Drawing.Point(95, 6);
            this.cd_grupo.Name = "cd_grupo";
            this.cd_grupo.NM_Alias = "";
            this.cd_grupo.NM_Campo = "cd_grupo";
            this.cd_grupo.NM_CampoBusca = "cd_grupo";
            this.cd_grupo.NM_Param = "@P_CD_EMPRESA";
            this.cd_grupo.QTD_Zero = 0;
            this.cd_grupo.Size = new System.Drawing.Size(75, 20);
            this.cd_grupo.ST_AutoInc = false;
            this.cd_grupo.ST_DisableAuto = false;
            this.cd_grupo.ST_Float = false;
            this.cd_grupo.ST_Gravar = true;
            this.cd_grupo.ST_Int = true;
            this.cd_grupo.ST_LimpaCampo = true;
            this.cd_grupo.ST_NotNull = false;
            this.cd_grupo.ST_PrimaryKey = false;
            this.cd_grupo.TabIndex = 0;
            this.cd_grupo.TextOld = null;
            this.cd_grupo.EnabledChanged += new System.EventHandler(this.cd_grupo_EnabledChanged);
            this.cd_grupo.TextChanged += new System.EventHandler(this.cd_grupo_TextChanged);
            this.cd_grupo.Leave += new System.EventHandler(this.cd_grupo_Leave);
            // 
            // TFGrupoPromocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 133);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFGrupoPromocao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itens Promoção";
            this.Load += new System.EventHandler(this.TFGrupoPromocao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFGrupoPromocao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_minimavenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_promocao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_grupo;
        private System.Windows.Forms.Button bb_grupo;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_grupo;
        private Componentes.EditFloat qtd_minimavenda;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat vl_promocao;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault tp_promocao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bsGrupo;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Button bb_produto;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault cd_produto;
    }
}