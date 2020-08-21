namespace Financeiro.Cadastros
{
    partial class TFVendedorGrupoProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFVendedorGrupoProd));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pVendGrupoProd = new Componentes.PanelDados(this.components);
            this.bsVendGrupoProd = new System.Windows.Forms.BindingSource(this.components);
            this.pc_comissao = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.CD_Grupo = new Componentes.EditDefault(this.components);
            this.LB_CD_Grupo = new System.Windows.Forms.Label();
            this.DS_Grupo = new Componentes.EditDefault(this.components);
            this.BB_GrupoProduto = new System.Windows.Forms.Button();
            this.barraMenu.SuspendLayout();
            this.pVendGrupoProd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsVendGrupoProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_comissao)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(641, 43);
            this.barraMenu.TabIndex = 17;
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
            // pVendGrupoProd
            // 
            this.pVendGrupoProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pVendGrupoProd.Controls.Add(this.pc_comissao);
            this.pVendGrupoProd.Controls.Add(this.label2);
            this.pVendGrupoProd.Controls.Add(this.CD_Grupo);
            this.pVendGrupoProd.Controls.Add(this.LB_CD_Grupo);
            this.pVendGrupoProd.Controls.Add(this.DS_Grupo);
            this.pVendGrupoProd.Controls.Add(this.BB_GrupoProduto);
            this.pVendGrupoProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pVendGrupoProd.Location = new System.Drawing.Point(0, 43);
            this.pVendGrupoProd.Name = "pVendGrupoProd";
            this.pVendGrupoProd.NM_ProcDeletar = "";
            this.pVendGrupoProd.NM_ProcGravar = "";
            this.pVendGrupoProd.Size = new System.Drawing.Size(641, 70);
            this.pVendGrupoProd.TabIndex = 18;
            // 
            // bsVendGrupoProd
            // 
            this.bsVendGrupoProd.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_GrupoProd);
            // 
            // pc_comissao
            // 
            this.pc_comissao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsVendGrupoProd, "Pc_Comissao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_comissao.DecimalPlaces = 2;
            this.pc_comissao.Location = new System.Drawing.Point(94, 36);
            this.pc_comissao.Name = "pc_comissao";
            this.pc_comissao.NM_Alias = "";
            this.pc_comissao.NM_Campo = "";
            this.pc_comissao.NM_Param = "";
            this.pc_comissao.Operador = "";
            this.pc_comissao.Size = new System.Drawing.Size(113, 20);
            this.pc_comissao.ST_AutoInc = false;
            this.pc_comissao.ST_DisableAuto = false;
            this.pc_comissao.ST_Gravar = false;
            this.pc_comissao.ST_LimparCampo = true;
            this.pc_comissao.ST_NotNull = false;
            this.pc_comissao.ST_PrimaryKey = false;
            this.pc_comissao.TabIndex = 73;
            this.pc_comissao.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "% Fixo Comissão";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CD_Grupo
            // 
            this.CD_Grupo.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVendGrupoProd, "Cd_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Grupo.Location = new System.Drawing.Point(94, 8);
            this.CD_Grupo.Name = "CD_Grupo";
            this.CD_Grupo.NM_Alias = "a";
            this.CD_Grupo.NM_Campo = "CD_Grupo";
            this.CD_Grupo.NM_CampoBusca = "CD_Grupo";
            this.CD_Grupo.NM_Param = "@P_CD_GRUPO";
            this.CD_Grupo.QTD_Zero = 0;
            this.CD_Grupo.Size = new System.Drawing.Size(56, 20);
            this.CD_Grupo.ST_AutoInc = false;
            this.CD_Grupo.ST_DisableAuto = false;
            this.CD_Grupo.ST_Float = false;
            this.CD_Grupo.ST_Gravar = true;
            this.CD_Grupo.ST_Int = false;
            this.CD_Grupo.ST_LimpaCampo = true;
            this.CD_Grupo.ST_NotNull = true;
            this.CD_Grupo.ST_PrimaryKey = false;
            this.CD_Grupo.TabIndex = 5;
            this.CD_Grupo.TextOld = null;
            this.CD_Grupo.Leave += new System.EventHandler(this.CD_Grupo_Leave);
            // 
            // LB_CD_Grupo
            // 
            this.LB_CD_Grupo.AutoSize = true;
            this.LB_CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Grupo.Location = new System.Drawing.Point(21, 12);
            this.LB_CD_Grupo.Name = "LB_CD_Grupo";
            this.LB_CD_Grupo.Size = new System.Drawing.Size(67, 13);
            this.LB_CD_Grupo.TabIndex = 7;
            this.LB_CD_Grupo.Text = "Grupo Prod.:";
            this.LB_CD_Grupo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DS_Grupo
            // 
            this.DS_Grupo.BackColor = System.Drawing.Color.White;
            this.DS_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVendGrupoProd, "Ds_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Grupo.Enabled = false;
            this.DS_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Grupo.Location = new System.Drawing.Point(189, 8);
            this.DS_Grupo.Name = "DS_Grupo";
            this.DS_Grupo.NM_Alias = "a";
            this.DS_Grupo.NM_Campo = "ds_grupo";
            this.DS_Grupo.NM_CampoBusca = "ds_grupo";
            this.DS_Grupo.NM_Param = "";
            this.DS_Grupo.QTD_Zero = 0;
            this.DS_Grupo.ReadOnly = true;
            this.DS_Grupo.Size = new System.Drawing.Size(439, 20);
            this.DS_Grupo.ST_AutoInc = false;
            this.DS_Grupo.ST_DisableAuto = false;
            this.DS_Grupo.ST_Float = false;
            this.DS_Grupo.ST_Gravar = false;
            this.DS_Grupo.ST_Int = false;
            this.DS_Grupo.ST_LimpaCampo = true;
            this.DS_Grupo.ST_NotNull = false;
            this.DS_Grupo.ST_PrimaryKey = false;
            this.DS_Grupo.TabIndex = 8;
            this.DS_Grupo.TextOld = null;
            // 
            // BB_GrupoProduto
            // 
            this.BB_GrupoProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_GrupoProduto.Image = ((System.Drawing.Image)(resources.GetObject("BB_GrupoProduto.Image")));
            this.BB_GrupoProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_GrupoProduto.Location = new System.Drawing.Point(154, 8);
            this.BB_GrupoProduto.Name = "BB_GrupoProduto";
            this.BB_GrupoProduto.Size = new System.Drawing.Size(30, 20);
            this.BB_GrupoProduto.TabIndex = 6;
            this.BB_GrupoProduto.UseVisualStyleBackColor = true;
            this.BB_GrupoProduto.Click += new System.EventHandler(this.BB_GrupoProduto_Click);
            // 
            // TFVendedorGrupoProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 113);
            this.Controls.Add(this.pVendGrupoProd);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFVendedorGrupoProd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupo Produto - Vendedor";
            this.Load += new System.EventHandler(this.TFVendedorGrupoProd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFVendedorGrupoProd_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pVendGrupoProd.ResumeLayout(false);
            this.pVendGrupoProd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsVendGrupoProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_comissao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pVendGrupoProd;
        private Componentes.EditDefault CD_Grupo;
        private System.Windows.Forms.Label LB_CD_Grupo;
        private Componentes.EditDefault DS_Grupo;
        public System.Windows.Forms.Button BB_GrupoProduto;
        private Componentes.EditFloat pc_comissao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bsVendGrupoProd;
    }
}