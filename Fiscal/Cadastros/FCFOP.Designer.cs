namespace Fiscal.Cadastros
{
    partial class FCFOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCFOP));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.BS_CFOP = new System.Windows.Forms.BindingSource(this.components);
            this.st_combustivel = new Componentes.CheckBoxDefault(this.components);
            this.st_remessa = new Componentes.CheckBoxDefault(this.components);
            this.st_retorno = new Componentes.CheckBoxDefault(this.components);
            this.st_devolucao = new Componentes.CheckBoxDefault(this.components);
            this.cbUsoConsumo = new Componentes.CheckBoxDefault(this.components);
            this.st_bonificacao = new Componentes.CheckBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ds_aplicacao = new Componentes.EditDefault(this.components);
            this.ds_cfop = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_cfop = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CFOP)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(659, 43);
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.st_combustivel);
            this.panelDados1.Controls.Add(this.st_remessa);
            this.panelDados1.Controls.Add(this.st_retorno);
            this.panelDados1.Controls.Add(this.st_devolucao);
            this.panelDados1.Controls.Add(this.cbUsoConsumo);
            this.panelDados1.Controls.Add(this.st_bonificacao);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.ds_aplicacao);
            this.panelDados1.Controls.Add(this.ds_cfop);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.cd_cfop);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(659, 139);
            this.panelDados1.TabIndex = 12;
            // 
            // BS_CFOP
            // 
            this.BS_CFOP.DataSource = typeof(CamadaDados.Fiscal.TList_CadCFOP);
            // 
            // st_combustivel
            // 
            this.st_combustivel.AutoSize = true;
            this.st_combustivel.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_combustivelbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_combustivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.st_combustivel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_combustivel.Location = new System.Drawing.Point(547, 109);
            this.st_combustivel.Name = "st_combustivel";
            this.st_combustivel.NM_Alias = "";
            this.st_combustivel.NM_Campo = "";
            this.st_combustivel.NM_Param = "";
            this.st_combustivel.Size = new System.Drawing.Size(94, 17);
            this.st_combustivel.ST_Gravar = true;
            this.st_combustivel.ST_LimparCampo = true;
            this.st_combustivel.ST_NotNull = false;
            this.st_combustivel.TabIndex = 20;
            this.st_combustivel.Text = "Combustivel";
            this.st_combustivel.UseVisualStyleBackColor = true;
            this.st_combustivel.Vl_False = "";
            this.st_combustivel.Vl_True = "";
            // 
            // st_remessa
            // 
            this.st_remessa.AutoSize = true;
            this.st_remessa.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_remessabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_remessa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.st_remessa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_remessa.Location = new System.Drawing.Point(387, 109);
            this.st_remessa.Name = "st_remessa";
            this.st_remessa.NM_Alias = "";
            this.st_remessa.NM_Campo = "";
            this.st_remessa.NM_Param = "";
            this.st_remessa.Size = new System.Drawing.Size(77, 17);
            this.st_remessa.ST_Gravar = true;
            this.st_remessa.ST_LimparCampo = true;
            this.st_remessa.ST_NotNull = false;
            this.st_remessa.TabIndex = 18;
            this.st_remessa.Text = "Remessa";
            this.st_remessa.UseVisualStyleBackColor = true;
            this.st_remessa.Vl_False = "";
            this.st_remessa.Vl_True = "";
            // 
            // st_retorno
            // 
            this.st_retorno.AutoSize = true;
            this.st_retorno.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_retornobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_retorno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.st_retorno.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_retorno.Location = new System.Drawing.Point(470, 109);
            this.st_retorno.Name = "st_retorno";
            this.st_retorno.NM_Alias = "";
            this.st_retorno.NM_Campo = "";
            this.st_retorno.NM_Param = "";
            this.st_retorno.Size = new System.Drawing.Size(71, 17);
            this.st_retorno.ST_Gravar = true;
            this.st_retorno.ST_LimparCampo = true;
            this.st_retorno.ST_NotNull = false;
            this.st_retorno.TabIndex = 19;
            this.st_retorno.Text = "Retorno";
            this.st_retorno.UseVisualStyleBackColor = true;
            this.st_retorno.Vl_False = "";
            this.st_retorno.Vl_True = "";
            // 
            // st_devolucao
            // 
            this.st_devolucao.AutoSize = true;
            this.st_devolucao.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_devolucaobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_devolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.st_devolucao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_devolucao.Location = new System.Drawing.Point(294, 109);
            this.st_devolucao.Name = "st_devolucao";
            this.st_devolucao.NM_Alias = "";
            this.st_devolucao.NM_Campo = "";
            this.st_devolucao.NM_Param = "";
            this.st_devolucao.Size = new System.Drawing.Size(87, 17);
            this.st_devolucao.ST_Gravar = true;
            this.st_devolucao.ST_LimparCampo = true;
            this.st_devolucao.ST_NotNull = false;
            this.st_devolucao.TabIndex = 17;
            this.st_devolucao.Text = "Devolução";
            this.st_devolucao.UseVisualStyleBackColor = true;
            this.st_devolucao.Vl_False = "";
            this.st_devolucao.Vl_True = "";
            // 
            // cbUsoConsumo
            // 
            this.cbUsoConsumo.AutoSize = true;
            this.cbUsoConsumo.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_usoconsumobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbUsoConsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbUsoConsumo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbUsoConsumo.Location = new System.Drawing.Point(174, 109);
            this.cbUsoConsumo.Name = "cbUsoConsumo";
            this.cbUsoConsumo.NM_Alias = "";
            this.cbUsoConsumo.NM_Campo = "";
            this.cbUsoConsumo.NM_Param = "";
            this.cbUsoConsumo.Size = new System.Drawing.Size(114, 17);
            this.cbUsoConsumo.ST_Gravar = true;
            this.cbUsoConsumo.ST_LimparCampo = true;
            this.cbUsoConsumo.ST_NotNull = false;
            this.cbUsoConsumo.TabIndex = 15;
            this.cbUsoConsumo.Text = "Uso e Consumo";
            this.cbUsoConsumo.UseVisualStyleBackColor = true;
            this.cbUsoConsumo.Vl_False = "";
            this.cbUsoConsumo.Vl_True = "";
            // 
            // st_bonificacao
            // 
            this.st_bonificacao.AutoSize = true;
            this.st_bonificacao.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_bonificacaobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_bonificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.st_bonificacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_bonificacao.Location = new System.Drawing.Point(75, 109);
            this.st_bonificacao.Name = "st_bonificacao";
            this.st_bonificacao.NM_Alias = "";
            this.st_bonificacao.NM_Campo = "";
            this.st_bonificacao.NM_Param = "";
            this.st_bonificacao.Size = new System.Drawing.Size(93, 17);
            this.st_bonificacao.ST_Gravar = true;
            this.st_bonificacao.ST_LimparCampo = true;
            this.st_bonificacao.ST_NotNull = false;
            this.st_bonificacao.TabIndex = 14;
            this.st_bonificacao.Text = "Bonificação";
            this.st_bonificacao.UseVisualStyleBackColor = true;
            this.st_bonificacao.Vl_False = "";
            this.st_bonificacao.Vl_True = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Aplicação";
            // 
            // ds_aplicacao
            // 
            this.ds_aplicacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_aplicacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_aplicacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_aplicacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CFOP, "DS_APLICACAO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_aplicacao.Location = new System.Drawing.Point(75, 58);
            this.ds_aplicacao.MaxLength = 2048;
            this.ds_aplicacao.Multiline = true;
            this.ds_aplicacao.Name = "ds_aplicacao";
            this.ds_aplicacao.NM_Alias = "";
            this.ds_aplicacao.NM_Campo = "";
            this.ds_aplicacao.NM_CampoBusca = "";
            this.ds_aplicacao.NM_Param = "";
            this.ds_aplicacao.QTD_Zero = 0;
            this.ds_aplicacao.Size = new System.Drawing.Size(554, 45);
            this.ds_aplicacao.ST_AutoInc = false;
            this.ds_aplicacao.ST_DisableAuto = false;
            this.ds_aplicacao.ST_Float = false;
            this.ds_aplicacao.ST_Gravar = true;
            this.ds_aplicacao.ST_Int = false;
            this.ds_aplicacao.ST_LimpaCampo = true;
            this.ds_aplicacao.ST_NotNull = false;
            this.ds_aplicacao.ST_PrimaryKey = false;
            this.ds_aplicacao.TabIndex = 12;
            this.ds_aplicacao.TextOld = null;
            // 
            // ds_cfop
            // 
            this.ds_cfop.BackColor = System.Drawing.SystemColors.Window;
            this.ds_cfop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_cfop.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_cfop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CFOP, "DS_CFOP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_cfop.Location = new System.Drawing.Point(75, 32);
            this.ds_cfop.Name = "ds_cfop";
            this.ds_cfop.NM_Alias = "";
            this.ds_cfop.NM_Campo = "ds_cfop";
            this.ds_cfop.NM_CampoBusca = "ds_cfop";
            this.ds_cfop.NM_Param = "@P_DS_CFOP";
            this.ds_cfop.QTD_Zero = 0;
            this.ds_cfop.Size = new System.Drawing.Size(554, 20);
            this.ds_cfop.ST_AutoInc = false;
            this.ds_cfop.ST_DisableAuto = false;
            this.ds_cfop.ST_Float = false;
            this.ds_cfop.ST_Gravar = true;
            this.ds_cfop.ST_Int = false;
            this.ds_cfop.ST_LimpaCampo = true;
            this.ds_cfop.ST_NotNull = true;
            this.ds_cfop.ST_PrimaryKey = false;
            this.ds_cfop.TabIndex = 10;
            this.ds_cfop.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(26, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "CFOP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Código:";
            // 
            // cd_cfop
            // 
            this.cd_cfop.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cfop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_cfop.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cfop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CFOP, "CD_CFOP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_cfop.Location = new System.Drawing.Point(75, 6);
            this.cd_cfop.MaxLength = 4;
            this.cd_cfop.Name = "cd_cfop";
            this.cd_cfop.NM_Alias = "";
            this.cd_cfop.NM_Campo = "cd_cfop";
            this.cd_cfop.NM_CampoBusca = "cd_cfop";
            this.cd_cfop.NM_Param = "@P_CD_CFOP";
            this.cd_cfop.QTD_Zero = 0;
            this.cd_cfop.Size = new System.Drawing.Size(66, 20);
            this.cd_cfop.ST_AutoInc = false;
            this.cd_cfop.ST_DisableAuto = true;
            this.cd_cfop.ST_Float = false;
            this.cd_cfop.ST_Gravar = true;
            this.cd_cfop.ST_Int = false;
            this.cd_cfop.ST_LimpaCampo = true;
            this.cd_cfop.ST_NotNull = true;
            this.cd_cfop.ST_PrimaryKey = true;
            this.cd_cfop.TabIndex = 9;
            this.cd_cfop.TextOld = null;
            // 
            // FCFOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 182);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "FCFOP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCFOP";
            this.Load += new System.EventHandler(this.FCFOP_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCFOP_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CFOP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingSource BS_CFOP;
        private Componentes.CheckBoxDefault st_combustivel;
        private Componentes.CheckBoxDefault st_remessa;
        private Componentes.CheckBoxDefault st_retorno;
        private Componentes.CheckBoxDefault st_devolucao;
        private Componentes.CheckBoxDefault cbUsoConsumo;
        private Componentes.CheckBoxDefault st_bonificacao;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault ds_aplicacao;
        private Componentes.EditDefault ds_cfop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_cfop;
    }
}