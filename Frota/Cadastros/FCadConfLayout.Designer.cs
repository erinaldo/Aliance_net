namespace Frota.Cadastros
{
    partial class TFCadConfLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadConfLayout));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_posicao = new Componentes.EditDefault(this.components);
            this.Coord_Sup_X = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Coord_Sup_Y = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.Coord_Inf_X = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.Coord_Inf_Y = new Componentes.EditDefault(this.components);
            this.bsConfLayout = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConfLayout)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(653, 43);
            this.barraMenu.TabIndex = 5;
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
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.Coord_Inf_Y);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.Coord_Inf_X);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.Coord_Sup_Y);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.Coord_Sup_X);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_posicao);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(653, 72);
            this.pDados.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 123;
            this.label1.Text = "Posição:";
            // 
            // ds_posicao
            // 
            this.ds_posicao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_posicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_posicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_posicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConfLayout, "DS_Posicao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_posicao.Location = new System.Drawing.Point(96, 10);
            this.ds_posicao.Name = "ds_posicao";
            this.ds_posicao.NM_Alias = "";
            this.ds_posicao.NM_Campo = "";
            this.ds_posicao.NM_CampoBusca = "";
            this.ds_posicao.NM_Param = "";
            this.ds_posicao.QTD_Zero = 0;
            this.ds_posicao.Size = new System.Drawing.Size(532, 20);
            this.ds_posicao.ST_AutoInc = false;
            this.ds_posicao.ST_DisableAuto = false;
            this.ds_posicao.ST_Float = false;
            this.ds_posicao.ST_Gravar = false;
            this.ds_posicao.ST_Int = false;
            this.ds_posicao.ST_LimpaCampo = true;
            this.ds_posicao.ST_NotNull = false;
            this.ds_posicao.ST_PrimaryKey = false;
            this.ds_posicao.TabIndex = 2;
            this.ds_posicao.TextOld = null;
            // 
            // Coord_Sup_X
            // 
            this.Coord_Sup_X.BackColor = System.Drawing.SystemColors.Window;
            this.Coord_Sup_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Coord_Sup_X.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Coord_Sup_X.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConfLayout, "Coord_X_Sup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Coord_Sup_X.Location = new System.Drawing.Point(96, 36);
            this.Coord_Sup_X.MaxLength = 4;
            this.Coord_Sup_X.Name = "Coord_Sup_X";
            this.Coord_Sup_X.NM_Alias = "";
            this.Coord_Sup_X.NM_Campo = "";
            this.Coord_Sup_X.NM_CampoBusca = "";
            this.Coord_Sup_X.NM_Param = "";
            this.Coord_Sup_X.QTD_Zero = 0;
            this.Coord_Sup_X.Size = new System.Drawing.Size(80, 20);
            this.Coord_Sup_X.ST_AutoInc = false;
            this.Coord_Sup_X.ST_DisableAuto = false;
            this.Coord_Sup_X.ST_Float = false;
            this.Coord_Sup_X.ST_Gravar = true;
            this.Coord_Sup_X.ST_Int = false;
            this.Coord_Sup_X.ST_LimpaCampo = true;
            this.Coord_Sup_X.ST_NotNull = false;
            this.Coord_Sup_X.ST_PrimaryKey = false;
            this.Coord_Sup_X.TabIndex = 3;
            this.Coord_Sup_X.TextOld = null;
            this.Coord_Sup_X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Coord_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "Superior X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "Superior Y:";
            // 
            // Coord_Sup_Y
            // 
            this.Coord_Sup_Y.BackColor = System.Drawing.SystemColors.Window;
            this.Coord_Sup_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Coord_Sup_Y.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Coord_Sup_Y.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConfLayout, "Coord_Y_Sup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Coord_Sup_Y.Location = new System.Drawing.Point(261, 36);
            this.Coord_Sup_Y.MaxLength = 4;
            this.Coord_Sup_Y.Name = "Coord_Sup_Y";
            this.Coord_Sup_Y.NM_Alias = "";
            this.Coord_Sup_Y.NM_Campo = "";
            this.Coord_Sup_Y.NM_CampoBusca = "";
            this.Coord_Sup_Y.NM_Param = "";
            this.Coord_Sup_Y.QTD_Zero = 0;
            this.Coord_Sup_Y.Size = new System.Drawing.Size(80, 20);
            this.Coord_Sup_Y.ST_AutoInc = false;
            this.Coord_Sup_Y.ST_DisableAuto = false;
            this.Coord_Sup_Y.ST_Float = false;
            this.Coord_Sup_Y.ST_Gravar = true;
            this.Coord_Sup_Y.ST_Int = false;
            this.Coord_Sup_Y.ST_LimpaCampo = true;
            this.Coord_Sup_Y.ST_NotNull = false;
            this.Coord_Sup_Y.ST_PrimaryKey = false;
            this.Coord_Sup_Y.TabIndex = 4;
            this.Coord_Sup_Y.TextOld = null;
            this.Coord_Sup_Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Coord_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 129;
            this.label7.Text = "Inf X:";
            // 
            // Coord_Inf_X
            // 
            this.Coord_Inf_X.BackColor = System.Drawing.SystemColors.Window;
            this.Coord_Inf_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Coord_Inf_X.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Coord_Inf_X.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConfLayout, "Coord_X_Inf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Coord_Inf_X.Location = new System.Drawing.Point(394, 36);
            this.Coord_Inf_X.MaxLength = 4;
            this.Coord_Inf_X.Name = "Coord_Inf_X";
            this.Coord_Inf_X.NM_Alias = "";
            this.Coord_Inf_X.NM_Campo = "";
            this.Coord_Inf_X.NM_CampoBusca = "";
            this.Coord_Inf_X.NM_Param = "";
            this.Coord_Inf_X.QTD_Zero = 0;
            this.Coord_Inf_X.Size = new System.Drawing.Size(80, 20);
            this.Coord_Inf_X.ST_AutoInc = false;
            this.Coord_Inf_X.ST_DisableAuto = false;
            this.Coord_Inf_X.ST_Float = false;
            this.Coord_Inf_X.ST_Gravar = true;
            this.Coord_Inf_X.ST_Int = false;
            this.Coord_Inf_X.ST_LimpaCampo = true;
            this.Coord_Inf_X.ST_NotNull = false;
            this.Coord_Inf_X.ST_PrimaryKey = false;
            this.Coord_Inf_X.TabIndex = 5;
            this.Coord_Inf_X.TextOld = null;
            this.Coord_Inf_X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Coord_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(510, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 131;
            this.label8.Text = "Inf Y:";
            // 
            // Coord_Inf_Y
            // 
            this.Coord_Inf_Y.BackColor = System.Drawing.SystemColors.Window;
            this.Coord_Inf_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Coord_Inf_Y.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Coord_Inf_Y.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConfLayout, "Coord_Y_Inf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Coord_Inf_Y.Location = new System.Drawing.Point(548, 36);
            this.Coord_Inf_Y.MaxLength = 4;
            this.Coord_Inf_Y.Name = "Coord_Inf_Y";
            this.Coord_Inf_Y.NM_Alias = "";
            this.Coord_Inf_Y.NM_Campo = "";
            this.Coord_Inf_Y.NM_CampoBusca = "";
            this.Coord_Inf_Y.NM_Param = "";
            this.Coord_Inf_Y.QTD_Zero = 0;
            this.Coord_Inf_Y.Size = new System.Drawing.Size(80, 20);
            this.Coord_Inf_Y.ST_AutoInc = false;
            this.Coord_Inf_Y.ST_DisableAuto = false;
            this.Coord_Inf_Y.ST_Float = false;
            this.Coord_Inf_Y.ST_Gravar = true;
            this.Coord_Inf_Y.ST_Int = false;
            this.Coord_Inf_Y.ST_LimpaCampo = true;
            this.Coord_Inf_Y.ST_NotNull = false;
            this.Coord_Inf_Y.ST_PrimaryKey = false;
            this.Coord_Inf_Y.TabIndex = 6;
            this.Coord_Inf_Y.TextOld = null;
            this.Coord_Inf_Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Coord_KeyPress);
            // 
            // bsConfLayout
            // 
            this.bsConfLayout.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_CadConf_Layout);
            // 
            // TFCadConfLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 115);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFCadConfLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração do Layout";
            this.Load += new System.EventHandler(this.TFCadConfLayout_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCadConfLayout_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConfLayout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_posicao;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault Coord_Inf_X;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault Coord_Sup_Y;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault Coord_Sup_X;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault Coord_Inf_Y;
        private System.Windows.Forms.BindingSource bsConfLayout;
    }
}