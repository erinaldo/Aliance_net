namespace PostoCombustivel
{
    partial class TFPlacaConvenio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFPlacaConvenio));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.bsPlacaConvenio = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.st_diasuteis = new Componentes.CheckBoxDefault(this.components);
            this.st_km = new Componentes.CheckBoxDefault(this.components);
            this.ds_veiculo = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.placa = new Componentes.EditMask(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlacaConvenio)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(475, 43);
            this.barraMenu.TabIndex = 13;
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.st_diasuteis);
            this.pDados.Controls.Add(this.st_km);
            this.pDados.Controls.Add(this.ds_veiculo);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.placa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(475, 151);
            this.pDados.TabIndex = 14;
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlacaConvenio, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(77, 81);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(391, 61);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 4;
            this.ds_observacao.TextOld = null;
            // 
            // bsPlacaConvenio
            // 
            this.bsPlacaConvenio.DataSource = typeof(CamadaDados.PostoCombustivel.TList_Convenio_Placa);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 425;
            this.label3.Text = "Observação:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // st_diasuteis
            // 
            this.st_diasuteis.AutoSize = true;
            this.st_diasuteis.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPlacaConvenio, "St_diasuteisbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_diasuteis.Location = new System.Drawing.Point(170, 58);
            this.st_diasuteis.Name = "st_diasuteis";
            this.st_diasuteis.NM_Alias = "";
            this.st_diasuteis.NM_Campo = "";
            this.st_diasuteis.NM_Param = "";
            this.st_diasuteis.Size = new System.Drawing.Size(156, 17);
            this.st_diasuteis.ST_Gravar = true;
            this.st_diasuteis.ST_LimparCampo = true;
            this.st_diasuteis.ST_NotNull = false;
            this.st_diasuteis.TabIndex = 3;
            this.st_diasuteis.Text = "Abastecer Somente Dia Util";
            this.st_diasuteis.UseVisualStyleBackColor = true;
            this.st_diasuteis.Vl_False = "";
            this.st_diasuteis.Vl_True = "";
            // 
            // st_km
            // 
            this.st_km.AutoSize = true;
            this.st_km.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPlacaConvenio, "St_kmbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_km.Location = new System.Drawing.Point(77, 58);
            this.st_km.Name = "st_km";
            this.st_km.NM_Alias = "";
            this.st_km.NM_Campo = "";
            this.st_km.NM_Param = "";
            this.st_km.Size = new System.Drawing.Size(87, 17);
            this.st_km.ST_Gravar = true;
            this.st_km.ST_LimparCampo = true;
            this.st_km.ST_NotNull = false;
            this.st_km.TabIndex = 2;
            this.st_km.Text = "Controlar KM";
            this.st_km.UseVisualStyleBackColor = true;
            this.st_km.Vl_False = "";
            this.st_km.Vl_True = "";
            // 
            // ds_veiculo
            // 
            this.ds_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlacaConvenio, "Ds_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_veiculo.Location = new System.Drawing.Point(77, 32);
            this.ds_veiculo.Name = "ds_veiculo";
            this.ds_veiculo.NM_Alias = "";
            this.ds_veiculo.NM_Campo = "";
            this.ds_veiculo.NM_CampoBusca = "";
            this.ds_veiculo.NM_Param = "";
            this.ds_veiculo.QTD_Zero = 0;
            this.ds_veiculo.Size = new System.Drawing.Size(391, 20);
            this.ds_veiculo.ST_AutoInc = false;
            this.ds_veiculo.ST_DisableAuto = false;
            this.ds_veiculo.ST_Float = false;
            this.ds_veiculo.ST_Gravar = true;
            this.ds_veiculo.ST_Int = false;
            this.ds_veiculo.ST_LimpaCampo = true;
            this.ds_veiculo.ST_NotNull = false;
            this.ds_veiculo.ST_PrimaryKey = false;
            this.ds_veiculo.TabIndex = 1;
            this.ds_veiculo.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(26, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 421;
            this.label2.Text = "Veiculo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 420;
            this.label1.Text = "Placa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // placa
            // 
            this.placa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlacaConvenio, "Placa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.placa.Location = new System.Drawing.Point(77, 6);
            this.placa.Mask = "AAA-AAAA";
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "";
            this.placa.NM_CampoBusca = "";
            this.placa.NM_Param = "";
            this.placa.Size = new System.Drawing.Size(60, 20);
            this.placa.ST_Gravar = true;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = true;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 0;
            this.placa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.placa_KeyPress);
            // 
            // TFPlacaConvenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 194);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFPlacaConvenio";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Placa Convenio";
            this.Load += new System.EventHandler(this.TFPlacaConvenio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFPlacaConvenio_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlacaConvenio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditMask placa;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label3;
        private Componentes.CheckBoxDefault st_diasuteis;
        private Componentes.CheckBoxDefault st_km;
        private Componentes.EditDefault ds_veiculo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsPlacaConvenio;
    }
}