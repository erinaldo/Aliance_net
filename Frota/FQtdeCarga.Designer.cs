namespace Frota
{
    partial class TFQtdeCarga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFQtdeCarga));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.qtd_carga = new Componentes.EditFloat(this.components);
            this.bsQtdeCarga = new System.Windows.Forms.BindingSource(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.editDefault4 = new Componentes.EditDefault(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tp_unidade = new Componentes.ComboBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_carga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQtdeCarga)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(559, 43);
            this.barraMenu.TabIndex = 22;
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
            this.pDados.Controls.Add(this.qtd_carga);
            this.pDados.Controls.Add(this.label23);
            this.pDados.Controls.Add(this.editDefault4);
            this.pDados.Controls.Add(this.label22);
            this.pDados.Controls.Add(this.label21);
            this.pDados.Controls.Add(this.tp_unidade);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(559, 55);
            this.pDados.TabIndex = 0;
            // 
            // qtd_carga
            // 
            this.qtd_carga.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsQtdeCarga, "Qt_carga", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_carga.DecimalPlaces = 4;
            this.qtd_carga.Location = new System.Drawing.Point(395, 22);
            this.qtd_carga.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_carga.Name = "qtd_carga";
            this.qtd_carga.NM_Alias = "";
            this.qtd_carga.NM_Campo = "";
            this.qtd_carga.NM_Param = "";
            this.qtd_carga.Operador = "";
            this.qtd_carga.Size = new System.Drawing.Size(153, 20);
            this.qtd_carga.ST_AutoInc = false;
            this.qtd_carga.ST_DisableAuto = false;
            this.qtd_carga.ST_Gravar = true;
            this.qtd_carga.ST_LimparCampo = true;
            this.qtd_carga.ST_NotNull = true;
            this.qtd_carga.ST_PrimaryKey = false;
            this.qtd_carga.TabIndex = 2;
            this.qtd_carga.ThousandsSeparator = true;
            // 
            // bsQtdeCarga
            // 
            this.bsQtdeCarga.DataSource = typeof(CamadaDados.Faturamento.CTRC.TList_CTRQtdeCarga);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(392, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(109, 13);
            this.label23.TabIndex = 118;
            this.label23.Text = "Quantidade Carga";
            // 
            // editDefault4
            // 
            this.editDefault4.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsQtdeCarga, "Tp_medida", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault4.Location = new System.Drawing.Point(168, 22);
            this.editDefault4.Name = "editDefault4";
            this.editDefault4.NM_Alias = "";
            this.editDefault4.NM_Campo = "";
            this.editDefault4.NM_CampoBusca = "";
            this.editDefault4.NM_Param = "";
            this.editDefault4.QTD_Zero = 0;
            this.editDefault4.Size = new System.Drawing.Size(221, 20);
            this.editDefault4.ST_AutoInc = false;
            this.editDefault4.ST_DisableAuto = false;
            this.editDefault4.ST_Float = false;
            this.editDefault4.ST_Gravar = true;
            this.editDefault4.ST_Int = false;
            this.editDefault4.ST_LimpaCampo = true;
            this.editDefault4.ST_NotNull = true;
            this.editDefault4.ST_PrimaryKey = false;
            this.editDefault4.TabIndex = 1;
            this.editDefault4.TextOld = null;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(165, 6);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 13);
            this.label22.TabIndex = 117;
            this.label22.Text = "Tipo Medida";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 5);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 13);
            this.label21.TabIndex = 116;
            this.label21.Text = "Unidade Medida";
            // 
            // tp_unidade
            // 
            this.tp_unidade.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsQtdeCarga, "cUnid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_unidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_unidade.FormattingEnabled = true;
            this.tp_unidade.Location = new System.Drawing.Point(11, 21);
            this.tp_unidade.Name = "tp_unidade";
            this.tp_unidade.NM_Alias = "";
            this.tp_unidade.NM_Campo = "";
            this.tp_unidade.NM_Param = "";
            this.tp_unidade.Size = new System.Drawing.Size(151, 21);
            this.tp_unidade.ST_Gravar = true;
            this.tp_unidade.ST_LimparCampo = true;
            this.tp_unidade.ST_NotNull = true;
            this.tp_unidade.TabIndex = 0;
            // 
            // TFQtdeCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 98);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFQtdeCarga";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informações da Carga";
            this.Load += new System.EventHandler(this.TFQtdeCarga_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFQtdeCarga_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_carga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQtdeCarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsQtdeCarga;
        private Componentes.EditFloat qtd_carga;
        private System.Windows.Forms.Label label23;
        private Componentes.EditDefault editDefault4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private Componentes.ComboBoxDefault tp_unidade;
    }
}