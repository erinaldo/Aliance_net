namespace Financeiro.Cadastros
{
    partial class TFCopiarConfigVend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCopiarConfigVend));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pCopiarVend = new Componentes.PanelDados(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.cbCfgGrupoProdVend = new Componentes.CheckBoxDefault(this.components);
            this.cbCfgEmpresaVend = new Componentes.CheckBoxDefault(this.components);
            this.cbCfgCarteiraVend = new Componentes.CheckBoxDefault(this.components);
            this.cbCfgCondPagtoVend = new Componentes.CheckBoxDefault(this.components);
            this.cbCfgTabPrecoVend = new Componentes.CheckBoxDefault(this.components);
            this.NM_CompVend = new Componentes.EditDefault(this.components);
            this.BB_CompVend = new System.Windows.Forms.Button();
            this.CD_CompVend = new Componentes.EditDefault(this.components);
            this.lblAgente = new System.Windows.Forms.Label();
            this.cbCfgDescontoVend = new Componentes.CheckBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pCopiarVend.SuspendLayout();
            this.radioGroup1.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(457, 43);
            this.barraMenu.TabIndex = 18;
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
            // pCopiarVend
            // 
            this.pCopiarVend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCopiarVend.Controls.Add(this.radioGroup1);
            this.pCopiarVend.Controls.Add(this.NM_CompVend);
            this.pCopiarVend.Controls.Add(this.BB_CompVend);
            this.pCopiarVend.Controls.Add(this.CD_CompVend);
            this.pCopiarVend.Controls.Add(this.lblAgente);
            this.pCopiarVend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCopiarVend.Location = new System.Drawing.Point(0, 43);
            this.pCopiarVend.Name = "pCopiarVend";
            this.pCopiarVend.NM_ProcDeletar = "";
            this.pCopiarVend.NM_ProcGravar = "";
            this.pCopiarVend.Size = new System.Drawing.Size(457, 234);
            this.pCopiarVend.TabIndex = 19;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.cbCfgDescontoVend);
            this.radioGroup1.Controls.Add(this.cbTodos);
            this.radioGroup1.Controls.Add(this.cbCfgGrupoProdVend);
            this.radioGroup1.Controls.Add(this.cbCfgEmpresaVend);
            this.radioGroup1.Controls.Add(this.cbCfgCarteiraVend);
            this.radioGroup1.Controls.Add(this.cbCfgCondPagtoVend);
            this.radioGroup1.Controls.Add(this.cbCfgTabPrecoVend);
            this.radioGroup1.Location = new System.Drawing.Point(14, 40);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(430, 180);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 403;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Configurações Vendedor";
            // 
            // cbTodos
            // 
            this.cbTodos.AutoSize = true;
            this.cbTodos.Enabled = false;
            this.cbTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTodos.Location = new System.Drawing.Point(24, 19);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.NM_Alias = "";
            this.cbTodos.NM_Campo = "";
            this.cbTodos.NM_Param = "";
            this.cbTodos.Size = new System.Drawing.Size(170, 17);
            this.cbTodos.ST_Gravar = false;
            this.cbTodos.ST_LimparCampo = true;
            this.cbTodos.ST_NotNull = false;
            this.cbTodos.TabIndex = 397;
            this.cbTodos.Text = "Marcar/Desmarcar Todos";
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            this.cbTodos.CheckedChanged += new System.EventHandler(this.cbTodos_CheckedChanged);
            // 
            // cbCfgGrupoProdVend
            // 
            this.cbCfgGrupoProdVend.AutoSize = true;
            this.cbCfgGrupoProdVend.Enabled = false;
            this.cbCfgGrupoProdVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCfgGrupoProdVend.Location = new System.Drawing.Point(24, 134);
            this.cbCfgGrupoProdVend.Name = "cbCfgGrupoProdVend";
            this.cbCfgGrupoProdVend.NM_Alias = "";
            this.cbCfgGrupoProdVend.NM_Campo = "";
            this.cbCfgGrupoProdVend.NM_Param = "";
            this.cbCfgGrupoProdVend.Size = new System.Drawing.Size(140, 17);
            this.cbCfgGrupoProdVend.ST_Gravar = false;
            this.cbCfgGrupoProdVend.ST_LimparCampo = true;
            this.cbCfgGrupoProdVend.ST_NotNull = false;
            this.cbCfgGrupoProdVend.TabIndex = 402;
            this.cbCfgGrupoProdVend.Text = "CFG. Grupo Produto";
            this.cbCfgGrupoProdVend.UseVisualStyleBackColor = true;
            this.cbCfgGrupoProdVend.Vl_False = "";
            this.cbCfgGrupoProdVend.Vl_True = "";
            // 
            // cbCfgEmpresaVend
            // 
            this.cbCfgEmpresaVend.AutoSize = true;
            this.cbCfgEmpresaVend.Enabled = false;
            this.cbCfgEmpresaVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCfgEmpresaVend.Location = new System.Drawing.Point(24, 42);
            this.cbCfgEmpresaVend.Name = "cbCfgEmpresaVend";
            this.cbCfgEmpresaVend.NM_Alias = "";
            this.cbCfgEmpresaVend.NM_Campo = "";
            this.cbCfgEmpresaVend.NM_Param = "";
            this.cbCfgEmpresaVend.Size = new System.Drawing.Size(106, 17);
            this.cbCfgEmpresaVend.ST_Gravar = false;
            this.cbCfgEmpresaVend.ST_LimparCampo = true;
            this.cbCfgEmpresaVend.ST_NotNull = false;
            this.cbCfgEmpresaVend.TabIndex = 398;
            this.cbCfgEmpresaVend.Text = "CFG. Empresa";
            this.cbCfgEmpresaVend.UseVisualStyleBackColor = true;
            this.cbCfgEmpresaVend.Vl_False = "";
            this.cbCfgEmpresaVend.Vl_True = "";
            // 
            // cbCfgCarteiraVend
            // 
            this.cbCfgCarteiraVend.AutoSize = true;
            this.cbCfgCarteiraVend.Enabled = false;
            this.cbCfgCarteiraVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCfgCarteiraVend.Location = new System.Drawing.Point(24, 111);
            this.cbCfgCarteiraVend.Name = "cbCfgCarteiraVend";
            this.cbCfgCarteiraVend.NM_Alias = "";
            this.cbCfgCarteiraVend.NM_Campo = "";
            this.cbCfgCarteiraVend.NM_Param = "";
            this.cbCfgCarteiraVend.Size = new System.Drawing.Size(169, 17);
            this.cbCfgCarteiraVend.ST_Gravar = false;
            this.cbCfgCarteiraVend.ST_LimparCampo = true;
            this.cbCfgCarteiraVend.ST_NotNull = false;
            this.cbCfgCarteiraVend.TabIndex = 401;
            this.cbCfgCarteiraVend.Text = "CFG. Carteira de Clientes";
            this.cbCfgCarteiraVend.UseVisualStyleBackColor = true;
            this.cbCfgCarteiraVend.Vl_False = "";
            this.cbCfgCarteiraVend.Vl_True = "";
            // 
            // cbCfgCondPagtoVend
            // 
            this.cbCfgCondPagtoVend.AutoSize = true;
            this.cbCfgCondPagtoVend.Enabled = false;
            this.cbCfgCondPagtoVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCfgCondPagtoVend.Location = new System.Drawing.Point(24, 65);
            this.cbCfgCondPagtoVend.Name = "cbCfgCondPagtoVend";
            this.cbCfgCondPagtoVend.NM_Alias = "";
            this.cbCfgCondPagtoVend.NM_Campo = "";
            this.cbCfgCondPagtoVend.NM_Param = "";
            this.cbCfgCondPagtoVend.Size = new System.Drawing.Size(158, 17);
            this.cbCfgCondPagtoVend.ST_Gravar = false;
            this.cbCfgCondPagtoVend.ST_LimparCampo = true;
            this.cbCfgCondPagtoVend.ST_NotNull = false;
            this.cbCfgCondPagtoVend.TabIndex = 399;
            this.cbCfgCondPagtoVend.Text = "CFG. Cond. Pagamento";
            this.cbCfgCondPagtoVend.UseVisualStyleBackColor = true;
            this.cbCfgCondPagtoVend.Vl_False = "";
            this.cbCfgCondPagtoVend.Vl_True = "";
            // 
            // cbCfgTabPrecoVend
            // 
            this.cbCfgTabPrecoVend.AutoSize = true;
            this.cbCfgTabPrecoVend.Enabled = false;
            this.cbCfgTabPrecoVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCfgTabPrecoVend.Location = new System.Drawing.Point(24, 88);
            this.cbCfgTabPrecoVend.Name = "cbCfgTabPrecoVend";
            this.cbCfgTabPrecoVend.NM_Alias = "";
            this.cbCfgTabPrecoVend.NM_Campo = "";
            this.cbCfgTabPrecoVend.NM_Param = "";
            this.cbCfgTabPrecoVend.Size = new System.Drawing.Size(134, 17);
            this.cbCfgTabPrecoVend.ST_Gravar = false;
            this.cbCfgTabPrecoVend.ST_LimparCampo = true;
            this.cbCfgTabPrecoVend.ST_NotNull = false;
            this.cbCfgTabPrecoVend.TabIndex = 400;
            this.cbCfgTabPrecoVend.Text = "CFG. Tabela Preço";
            this.cbCfgTabPrecoVend.UseVisualStyleBackColor = true;
            this.cbCfgTabPrecoVend.Vl_False = "";
            this.cbCfgTabPrecoVend.Vl_True = "";
            // 
            // NM_CompVend
            // 
            this.NM_CompVend.BackColor = System.Drawing.SystemColors.Window;
            this.NM_CompVend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_CompVend.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_CompVend.Enabled = false;
            this.NM_CompVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_CompVend.Location = new System.Drawing.Point(204, 14);
            this.NM_CompVend.Name = "NM_CompVend";
            this.NM_CompVend.NM_Alias = "";
            this.NM_CompVend.NM_Campo = "nm_clifor";
            this.NM_CompVend.NM_CampoBusca = "nm_clifor";
            this.NM_CompVend.NM_Param = "@P_NOMEVENDEDOR";
            this.NM_CompVend.QTD_Zero = 0;
            this.NM_CompVend.ReadOnly = true;
            this.NM_CompVend.Size = new System.Drawing.Size(240, 20);
            this.NM_CompVend.ST_AutoInc = false;
            this.NM_CompVend.ST_DisableAuto = false;
            this.NM_CompVend.ST_Float = false;
            this.NM_CompVend.ST_Gravar = false;
            this.NM_CompVend.ST_Int = false;
            this.NM_CompVend.ST_LimpaCampo = true;
            this.NM_CompVend.ST_NotNull = false;
            this.NM_CompVend.ST_PrimaryKey = false;
            this.NM_CompVend.TabIndex = 396;
            this.NM_CompVend.TextOld = null;
            // 
            // BB_CompVend
            // 
            this.BB_CompVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_CompVend.Image = ((System.Drawing.Image)(resources.GetObject("BB_CompVend.Image")));
            this.BB_CompVend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_CompVend.Location = new System.Drawing.Point(173, 14);
            this.BB_CompVend.Name = "BB_CompVend";
            this.BB_CompVend.Size = new System.Drawing.Size(28, 19);
            this.BB_CompVend.TabIndex = 394;
            this.BB_CompVend.UseVisualStyleBackColor = true;
            this.BB_CompVend.Click += new System.EventHandler(this.BB_CompVend_Click);
            // 
            // CD_CompVend
            // 
            this.CD_CompVend.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CompVend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CompVend.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CompVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_CompVend.Location = new System.Drawing.Point(82, 14);
            this.CD_CompVend.Name = "CD_CompVend";
            this.CD_CompVend.NM_Alias = "";
            this.CD_CompVend.NM_Campo = "cd_clifor";
            this.CD_CompVend.NM_CampoBusca = "cd_clifor";
            this.CD_CompVend.NM_Param = "@P_CD_CLIFOR";
            this.CD_CompVend.QTD_Zero = 0;
            this.CD_CompVend.Size = new System.Drawing.Size(87, 20);
            this.CD_CompVend.ST_AutoInc = false;
            this.CD_CompVend.ST_DisableAuto = false;
            this.CD_CompVend.ST_Float = false;
            this.CD_CompVend.ST_Gravar = true;
            this.CD_CompVend.ST_Int = true;
            this.CD_CompVend.ST_LimpaCampo = true;
            this.CD_CompVend.ST_NotNull = true;
            this.CD_CompVend.ST_PrimaryKey = false;
            this.CD_CompVend.TabIndex = 393;
            this.CD_CompVend.TextOld = null;
            this.CD_CompVend.Leave += new System.EventHandler(this.CD_CompVend_Leave);
            // 
            // lblAgente
            // 
            this.lblAgente.AutoSize = true;
            this.lblAgente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAgente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAgente.Location = new System.Drawing.Point(11, 18);
            this.lblAgente.Name = "lblAgente";
            this.lblAgente.Size = new System.Drawing.Size(65, 13);
            this.lblAgente.TabIndex = 395;
            this.lblAgente.Text = "Vendedor:";
            this.lblAgente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCfgDescontoVend
            // 
            this.cbCfgDescontoVend.AutoSize = true;
            this.cbCfgDescontoVend.Enabled = false;
            this.cbCfgDescontoVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCfgDescontoVend.Location = new System.Drawing.Point(24, 157);
            this.cbCfgDescontoVend.Name = "cbCfgDescontoVend";
            this.cbCfgDescontoVend.NM_Alias = "";
            this.cbCfgDescontoVend.NM_Campo = "";
            this.cbCfgDescontoVend.NM_Param = "";
            this.cbCfgDescontoVend.Size = new System.Drawing.Size(112, 17);
            this.cbCfgDescontoVend.ST_Gravar = false;
            this.cbCfgDescontoVend.ST_LimparCampo = true;
            this.cbCfgDescontoVend.ST_NotNull = false;
            this.cbCfgDescontoVend.TabIndex = 403;
            this.cbCfgDescontoVend.Text = "CFG. Desconto";
            this.cbCfgDescontoVend.UseVisualStyleBackColor = true;
            this.cbCfgDescontoVend.Vl_False = "";
            this.cbCfgDescontoVend.Vl_True = "";
            // 
            // TFCopiarConfigVend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 277);
            this.Controls.Add(this.pCopiarVend);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCopiarConfigVend";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copiar Configurações Vendedor";
            this.Load += new System.EventHandler(this.TFCopiarConfigVend_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCopiarConfigVend_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pCopiarVend.ResumeLayout(false);
            this.pCopiarVend.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pCopiarVend;
        private Componentes.EditDefault NM_CompVend;
        private System.Windows.Forms.Button BB_CompVend;
        private Componentes.EditDefault CD_CompVend;
        private System.Windows.Forms.Label lblAgente;
        private Componentes.CheckBoxDefault cbCfgCondPagtoVend;
        private Componentes.CheckBoxDefault cbCfgEmpresaVend;
        private Componentes.CheckBoxDefault cbTodos;
        private Componentes.CheckBoxDefault cbCfgCarteiraVend;
        private Componentes.CheckBoxDefault cbCfgTabPrecoVend;
        private Componentes.CheckBoxDefault cbCfgGrupoProdVend;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.CheckBoxDefault cbCfgDescontoVend;
    }
}