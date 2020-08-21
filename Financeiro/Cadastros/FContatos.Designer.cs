namespace Financeiro.Cadastros
{
    partial class TFContatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFContatos));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pnl_Contato = new Componentes.PanelDados(this.components);
            this.st_receberOS = new Componentes.CheckBoxDefault(this.components);
            this.bsContato = new System.Windows.Forms.BindingSource(this.components);
            this.st_receberxmlnfe = new Componentes.CheckBoxDefault(this.components);
            this.st_receberdanfe = new Componentes.CheckBoxDefault(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.tipo_contato = new Componentes.ComboBoxDefault(this.components);
            this.DS_Observacao = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.NM_Contato = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Email_Contato = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Fone = new Componentes.EditDefault(this.components);
            this.FoneMovel = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pnl_Contato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsContato)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(728, 43);
            this.barraMenu.TabIndex = 537;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
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
            // pnl_Contato
            // 
            this.pnl_Contato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Contato.Controls.Add(this.FoneMovel);
            this.pnl_Contato.Controls.Add(this.Fone);
            this.pnl_Contato.Controls.Add(this.st_receberOS);
            this.pnl_Contato.Controls.Add(this.st_receberxmlnfe);
            this.pnl_Contato.Controls.Add(this.st_receberdanfe);
            this.pnl_Contato.Controls.Add(this.label13);
            this.pnl_Contato.Controls.Add(this.tipo_contato);
            this.pnl_Contato.Controls.Add(this.DS_Observacao);
            this.pnl_Contato.Controls.Add(this.label6);
            this.pnl_Contato.Controls.Add(this.NM_Contato);
            this.pnl_Contato.Controls.Add(this.label3);
            this.pnl_Contato.Controls.Add(this.Email_Contato);
            this.pnl_Contato.Controls.Add(this.label9);
            this.pnl_Contato.Controls.Add(this.label15);
            this.pnl_Contato.Controls.Add(this.label12);
            this.pnl_Contato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Contato.Location = new System.Drawing.Point(0, 43);
            this.pnl_Contato.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Contato.Name = "pnl_Contato";
            this.pnl_Contato.NM_ProcDeletar = "";
            this.pnl_Contato.NM_ProcGravar = "";
            this.pnl_Contato.Size = new System.Drawing.Size(728, 121);
            this.pnl_Contato.TabIndex = 538;
            // 
            // st_receberOS
            // 
            this.st_receberOS.AutoSize = true;
            this.st_receberOS.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsContato, "St_receberOSbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_receberOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_receberOS.Location = new System.Drawing.Point(358, 97);
            this.st_receberOS.Name = "st_receberOS";
            this.st_receberOS.NM_Alias = "";
            this.st_receberOS.NM_Campo = "";
            this.st_receberOS.NM_Param = "";
            this.st_receberOS.Size = new System.Drawing.Size(161, 17);
            this.st_receberOS.ST_Gravar = true;
            this.st_receberOS.ST_LimparCampo = true;
            this.st_receberOS.ST_NotNull = false;
            this.st_receberOS.TabIndex = 8;
            this.st_receberOS.Text = "Receber Ordem Serviço";
            this.st_receberOS.UseVisualStyleBackColor = true;
            this.st_receberOS.Vl_False = "";
            this.st_receberOS.Vl_True = "";
            // 
            // bsContato
            // 
            this.bsContato.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadContatoCliFor);
            // 
            // st_receberxmlnfe
            // 
            this.st_receberxmlnfe.AutoSize = true;
            this.st_receberxmlnfe.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsContato, "St_receberxmlnfebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_receberxmlnfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_receberxmlnfe.Location = new System.Drawing.Point(222, 97);
            this.st_receberxmlnfe.Name = "st_receberxmlnfe";
            this.st_receberxmlnfe.NM_Alias = "";
            this.st_receberxmlnfe.NM_Campo = "";
            this.st_receberxmlnfe.NM_Param = "";
            this.st_receberxmlnfe.Size = new System.Drawing.Size(130, 17);
            this.st_receberxmlnfe.ST_Gravar = true;
            this.st_receberxmlnfe.ST_LimparCampo = true;
            this.st_receberxmlnfe.ST_NotNull = false;
            this.st_receberxmlnfe.TabIndex = 7;
            this.st_receberxmlnfe.Text = "Receber XML NFe";
            this.st_receberxmlnfe.UseVisualStyleBackColor = true;
            this.st_receberxmlnfe.Vl_False = "";
            this.st_receberxmlnfe.Vl_True = "";
            // 
            // st_receberdanfe
            // 
            this.st_receberdanfe.AutoSize = true;
            this.st_receberdanfe.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsContato, "St_receberdanfebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_receberdanfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_receberdanfe.Location = new System.Drawing.Point(77, 97);
            this.st_receberdanfe.Name = "st_receberdanfe";
            this.st_receberdanfe.NM_Alias = "";
            this.st_receberdanfe.NM_Campo = "";
            this.st_receberdanfe.NM_Param = "";
            this.st_receberdanfe.Size = new System.Drawing.Size(139, 17);
            this.st_receberdanfe.ST_Gravar = true;
            this.st_receberdanfe.ST_LimparCampo = true;
            this.st_receberdanfe.ST_NotNull = false;
            this.st_receberdanfe.TabIndex = 6;
            this.st_receberdanfe.Text = "Receber Danfe NFe";
            this.st_receberdanfe.UseVisualStyleBackColor = true;
            this.st_receberdanfe.Vl_False = "";
            this.st_receberdanfe.Vl_True = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(451, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 547;
            this.label13.Text = "Tipo de Contato:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tipo_contato
            // 
            this.tipo_contato.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsContato, "Tp_Contato", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tipo_contato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipo_contato.FormattingEnabled = true;
            this.tipo_contato.Location = new System.Drawing.Point(543, 47);
            this.tipo_contato.Name = "tipo_contato";
            this.tipo_contato.NM_Alias = "";
            this.tipo_contato.NM_Campo = "";
            this.tipo_contato.NM_Param = "";
            this.tipo_contato.Size = new System.Drawing.Size(177, 21);
            this.tipo_contato.ST_Gravar = true;
            this.tipo_contato.ST_LimparCampo = true;
            this.tipo_contato.ST_NotNull = true;
            this.tipo_contato.TabIndex = 4;
            // 
            // DS_Observacao
            // 
            this.DS_Observacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.DS_Observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContato, "DS_Observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Observacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Observacao.Location = new System.Drawing.Point(77, 71);
            this.DS_Observacao.Name = "DS_Observacao";
            this.DS_Observacao.NM_Alias = "e";
            this.DS_Observacao.NM_Campo = "DS_Observacao";
            this.DS_Observacao.NM_CampoBusca = "DS_Observacao";
            this.DS_Observacao.NM_Param = "@P_EMAIL";
            this.DS_Observacao.QTD_Zero = 0;
            this.DS_Observacao.Size = new System.Drawing.Size(643, 20);
            this.DS_Observacao.ST_AutoInc = false;
            this.DS_Observacao.ST_DisableAuto = false;
            this.DS_Observacao.ST_Float = false;
            this.DS_Observacao.ST_Gravar = true;
            this.DS_Observacao.ST_Int = false;
            this.DS_Observacao.ST_LimpaCampo = true;
            this.DS_Observacao.ST_NotNull = false;
            this.DS_Observacao.ST_PrimaryKey = false;
            this.DS_Observacao.TabIndex = 5;
            this.DS_Observacao.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(24, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 543;
            this.label6.Text = "Contato:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NM_Contato
            // 
            this.NM_Contato.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Contato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Contato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Contato.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContato, "Nm_Contato", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Contato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Contato.Location = new System.Drawing.Point(77, 3);
            this.NM_Contato.Name = "NM_Contato";
            this.NM_Contato.NM_Alias = "e";
            this.NM_Contato.NM_Campo = "EMail";
            this.NM_Contato.NM_CampoBusca = "EMail";
            this.NM_Contato.NM_Param = "@P_EMAIL";
            this.NM_Contato.QTD_Zero = 0;
            this.NM_Contato.Size = new System.Drawing.Size(643, 20);
            this.NM_Contato.ST_AutoInc = false;
            this.NM_Contato.ST_DisableAuto = false;
            this.NM_Contato.ST_Float = false;
            this.NM_Contato.ST_Gravar = true;
            this.NM_Contato.ST_Int = false;
            this.NM_Contato.ST_LimpaCampo = true;
            this.NM_Contato.ST_NotNull = true;
            this.NM_Contato.ST_PrimaryKey = false;
            this.NM_Contato.TabIndex = 0;
            this.NM_Contato.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(32, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 541;
            this.label3.Text = "E-Mail:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Email_Contato
            // 
            this.Email_Contato.BackColor = System.Drawing.SystemColors.Window;
            this.Email_Contato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Email_Contato.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.Email_Contato.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContato, "Email", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Email_Contato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Email_Contato.Location = new System.Drawing.Point(77, 25);
            this.Email_Contato.Name = "Email_Contato";
            this.Email_Contato.NM_Alias = "e";
            this.Email_Contato.NM_Campo = "EMail";
            this.Email_Contato.NM_CampoBusca = "EMail";
            this.Email_Contato.NM_Param = "@P_EMAIL";
            this.Email_Contato.QTD_Zero = 0;
            this.Email_Contato.Size = new System.Drawing.Size(643, 20);
            this.Email_Contato.ST_AutoInc = false;
            this.Email_Contato.ST_DisableAuto = false;
            this.Email_Contato.ST_Float = false;
            this.Email_Contato.ST_Gravar = true;
            this.Email_Contato.ST_Int = false;
            this.Email_Contato.ST_LimpaCampo = true;
            this.Email_Contato.ST_NotNull = false;
            this.Email_Contato.ST_PrimaryKey = false;
            this.Email_Contato.TabIndex = 1;
            this.Email_Contato.TextOld = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(228, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 538;
            this.label9.Text = "Fone Móvel:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(37, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 535;
            this.label15.Text = "Fone:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(6, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 545;
            this.label12.Text = "Observação:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Fone
            // 
            this.Fone.BackColor = System.Drawing.SystemColors.Window;
            this.Fone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Fone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContato, "Fone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Fone.Location = new System.Drawing.Point(77, 48);
            this.Fone.Name = "Fone";
            this.Fone.NM_Alias = "";
            this.Fone.NM_Campo = "";
            this.Fone.NM_CampoBusca = "";
            this.Fone.NM_Param = "";
            this.Fone.QTD_Zero = 0;
            this.Fone.Size = new System.Drawing.Size(145, 20);
            this.Fone.ST_AutoInc = false;
            this.Fone.ST_DisableAuto = false;
            this.Fone.ST_Float = false;
            this.Fone.ST_Gravar = false;
            this.Fone.ST_Int = false;
            this.Fone.ST_LimpaCampo = true;
            this.Fone.ST_NotNull = false;
            this.Fone.ST_PrimaryKey = false;
            this.Fone.TabIndex = 2;
            this.Fone.TextOld = null;
            this.Fone.TextChanged += new System.EventHandler(this.Fone_TextChanged);
            // 
            // FoneMovel
            // 
            this.FoneMovel.BackColor = System.Drawing.SystemColors.Window;
            this.FoneMovel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FoneMovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.FoneMovel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContato, "FoneMovel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FoneMovel.Location = new System.Drawing.Point(300, 48);
            this.FoneMovel.Name = "FoneMovel";
            this.FoneMovel.NM_Alias = "";
            this.FoneMovel.NM_Campo = "";
            this.FoneMovel.NM_CampoBusca = "";
            this.FoneMovel.NM_Param = "";
            this.FoneMovel.QTD_Zero = 0;
            this.FoneMovel.Size = new System.Drawing.Size(145, 20);
            this.FoneMovel.ST_AutoInc = false;
            this.FoneMovel.ST_DisableAuto = false;
            this.FoneMovel.ST_Float = false;
            this.FoneMovel.ST_Gravar = false;
            this.FoneMovel.ST_Int = false;
            this.FoneMovel.ST_LimpaCampo = true;
            this.FoneMovel.ST_NotNull = false;
            this.FoneMovel.ST_PrimaryKey = false;
            this.FoneMovel.TabIndex = 3;
            this.FoneMovel.TextOld = null;
            this.FoneMovel.TextChanged += new System.EventHandler(this.FoneMovel_TextChanged);
            // 
            // TFContatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 164);
            this.Controls.Add(this.pnl_Contato);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFContatos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contatos";
            this.Load += new System.EventHandler(this.TFContatos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFContatos_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pnl_Contato.ResumeLayout(false);
            this.pnl_Contato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsContato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.BindingSource bsContato;
        private Componentes.PanelDados pnl_Contato;
        private System.Windows.Forms.Label label13;
        private Componentes.ComboBoxDefault tipo_contato;
        private Componentes.EditDefault DS_Observacao;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault NM_Contato;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault Email_Contato;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private Componentes.CheckBoxDefault st_receberxmlnfe;
        private Componentes.CheckBoxDefault st_receberdanfe;
        private Componentes.CheckBoxDefault st_receberOS;
        private Componentes.EditDefault FoneMovel;
        private Componentes.EditDefault Fone;
    }
}