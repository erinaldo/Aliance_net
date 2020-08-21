namespace Faturamento.Cadastros
{
    partial class TFSerieNF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFSerieNF));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.st_gerasintegra = new Componentes.CheckBoxDefault(this.components);
            this.bsSerie = new System.Windows.Forms.BindingSource(this.components);
            this.ST_SequenciaAuto = new Componentes.CheckBoxDefault(this.components);
            this.tp_serie = new Componentes.ComboBoxDefault(this.components);
            this.ds_serienf = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nr_serie = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_modelo = new System.Windows.Forms.Button();
            this.ds_modelo = new Componentes.EditDefault(this.components);
            this.cd_modelo = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSerie)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(635, 43);
            this.barraMenu.TabIndex = 9;
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
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.st_gerasintegra);
            this.pDados.Controls.Add(this.ST_SequenciaAuto);
            this.pDados.Controls.Add(this.tp_serie);
            this.pDados.Controls.Add(this.ds_serienf);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.nr_serie);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.bb_modelo);
            this.pDados.Controls.Add(this.ds_modelo);
            this.pDados.Controls.Add(this.cd_modelo);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(635, 83);
            this.pDados.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Tipo Serie:";
            // 
            // st_gerasintegra
            // 
            this.st_gerasintegra.AutoSize = true;
            this.st_gerasintegra.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsSerie, "St_gerasintegrabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_gerasintegra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_gerasintegra.Location = new System.Drawing.Point(389, 58);
            this.st_gerasintegra.Name = "st_gerasintegra";
            this.st_gerasintegra.NM_Alias = "";
            this.st_gerasintegra.NM_Campo = "ST_SequenciaAuto";
            this.st_gerasintegra.NM_Param = "@P_ST_SEQUENCIAAUTO";
            this.st_gerasintegra.Size = new System.Drawing.Size(94, 17);
            this.st_gerasintegra.ST_Gravar = true;
            this.st_gerasintegra.ST_LimparCampo = true;
            this.st_gerasintegra.ST_NotNull = false;
            this.st_gerasintegra.TabIndex = 5;
            this.st_gerasintegra.Text = "Gerar Sintegra";
            this.st_gerasintegra.UseVisualStyleBackColor = true;
            this.st_gerasintegra.Vl_False = "N";
            this.st_gerasintegra.Vl_True = "S";
            // 
            // bsSerie
            // 
            this.bsSerie.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CadSerieNF);
            // 
            // ST_SequenciaAuto
            // 
            this.ST_SequenciaAuto.AutoSize = true;
            this.ST_SequenciaAuto.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsSerie, "ST_SequenciaAutoBool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_SequenciaAuto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ST_SequenciaAuto.Location = new System.Drawing.Point(489, 58);
            this.ST_SequenciaAuto.Name = "ST_SequenciaAuto";
            this.ST_SequenciaAuto.NM_Alias = "";
            this.ST_SequenciaAuto.NM_Campo = "ST_SequenciaAuto";
            this.ST_SequenciaAuto.NM_Param = "@P_ST_SEQUENCIAAUTO";
            this.ST_SequenciaAuto.Size = new System.Drawing.Size(133, 17);
            this.ST_SequenciaAuto.ST_Gravar = true;
            this.ST_SequenciaAuto.ST_LimparCampo = true;
            this.ST_SequenciaAuto.ST_NotNull = false;
            this.ST_SequenciaAuto.TabIndex = 6;
            this.ST_SequenciaAuto.Text = "Sequência Automática";
            this.ST_SequenciaAuto.UseVisualStyleBackColor = true;
            this.ST_SequenciaAuto.Vl_False = "N";
            this.ST_SequenciaAuto.Vl_True = "S";
            // 
            // tp_serie
            // 
            this.tp_serie.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsSerie, "Tp_serie", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_serie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_serie.FormattingEnabled = true;
            this.tp_serie.Location = new System.Drawing.Point(67, 56);
            this.tp_serie.Name = "tp_serie";
            this.tp_serie.NM_Alias = "";
            this.tp_serie.NM_Campo = "TP_Serie";
            this.tp_serie.NM_Param = "@P_ST_GERASINTEGRA";
            this.tp_serie.Size = new System.Drawing.Size(316, 21);
            this.tp_serie.ST_Gravar = true;
            this.tp_serie.ST_LimparCampo = true;
            this.tp_serie.ST_NotNull = true;
            this.tp_serie.TabIndex = 4;
            // 
            // ds_serienf
            // 
            this.ds_serienf.BackColor = System.Drawing.SystemColors.Window;
            this.ds_serienf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_serienf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_serienf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSerie, "DS_SerieNf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_serienf.Location = new System.Drawing.Point(196, 30);
            this.ds_serienf.Name = "ds_serienf";
            this.ds_serienf.NM_Alias = "";
            this.ds_serienf.NM_Campo = "ds_serienf";
            this.ds_serienf.NM_CampoBusca = "ds_serienf";
            this.ds_serienf.NM_Param = "@P_DS_SERIENF";
            this.ds_serienf.QTD_Zero = 0;
            this.ds_serienf.Size = new System.Drawing.Size(434, 20);
            this.ds_serienf.ST_AutoInc = false;
            this.ds_serienf.ST_DisableAuto = false;
            this.ds_serienf.ST_Float = false;
            this.ds_serienf.ST_Gravar = true;
            this.ds_serienf.ST_Int = false;
            this.ds_serienf.ST_LimpaCampo = true;
            this.ds_serienf.ST_NotNull = true;
            this.ds_serienf.ST_PrimaryKey = false;
            this.ds_serienf.TabIndex = 3;
            this.ds_serienf.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 93;
            this.label3.Text = "Serie:";
            // 
            // nr_serie
            // 
            this.nr_serie.BackColor = System.Drawing.SystemColors.Window;
            this.nr_serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_serie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSerie, "Nr_Serie", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_serie.Location = new System.Drawing.Point(67, 30);
            this.nr_serie.Name = "nr_serie";
            this.nr_serie.NM_Alias = "";
            this.nr_serie.NM_Campo = "nr_serie";
            this.nr_serie.NM_CampoBusca = "nr_serie";
            this.nr_serie.NM_Param = "@P_NR_SERIE";
            this.nr_serie.QTD_Zero = 0;
            this.nr_serie.Size = new System.Drawing.Size(83, 20);
            this.nr_serie.ST_AutoInc = false;
            this.nr_serie.ST_DisableAuto = false;
            this.nr_serie.ST_Float = false;
            this.nr_serie.ST_Gravar = true;
            this.nr_serie.ST_Int = false;
            this.nr_serie.ST_LimpaCampo = true;
            this.nr_serie.ST_NotNull = true;
            this.nr_serie.ST_PrimaryKey = false;
            this.nr_serie.TabIndex = 2;
            this.nr_serie.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Nº Serie:";
            // 
            // bb_modelo
            // 
            this.bb_modelo.Image = ((System.Drawing.Image)(resources.GetObject("bb_modelo.Image")));
            this.bb_modelo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_modelo.Location = new System.Drawing.Point(122, 4);
            this.bb_modelo.Name = "bb_modelo";
            this.bb_modelo.Size = new System.Drawing.Size(28, 20);
            this.bb_modelo.TabIndex = 1;
            this.bb_modelo.UseVisualStyleBackColor = true;
            this.bb_modelo.Click += new System.EventHandler(this.bb_modelo_Click);
            // 
            // ds_modelo
            // 
            this.ds_modelo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_modelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_modelo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSerie, "DS_Modelo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_modelo.Enabled = false;
            this.ds_modelo.Location = new System.Drawing.Point(156, 4);
            this.ds_modelo.Name = "ds_modelo";
            this.ds_modelo.NM_Alias = "";
            this.ds_modelo.NM_Campo = "ds_modelo";
            this.ds_modelo.NM_CampoBusca = "ds_modelo";
            this.ds_modelo.NM_Param = "@P_DS_PDV";
            this.ds_modelo.QTD_Zero = 0;
            this.ds_modelo.Size = new System.Drawing.Size(474, 20);
            this.ds_modelo.ST_AutoInc = false;
            this.ds_modelo.ST_DisableAuto = false;
            this.ds_modelo.ST_Float = false;
            this.ds_modelo.ST_Gravar = false;
            this.ds_modelo.ST_Int = false;
            this.ds_modelo.ST_LimpaCampo = true;
            this.ds_modelo.ST_NotNull = false;
            this.ds_modelo.ST_PrimaryKey = false;
            this.ds_modelo.TabIndex = 90;
            this.ds_modelo.TextOld = null;
            // 
            // cd_modelo
            // 
            this.cd_modelo.BackColor = System.Drawing.SystemColors.Window;
            this.cd_modelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_modelo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSerie, "CD_Modelo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_modelo.Location = new System.Drawing.Point(67, 4);
            this.cd_modelo.Name = "cd_modelo";
            this.cd_modelo.NM_Alias = "";
            this.cd_modelo.NM_Campo = "cd_modelo";
            this.cd_modelo.NM_CampoBusca = "cd_modelo";
            this.cd_modelo.NM_Param = "@P_CD_EMPRESA";
            this.cd_modelo.QTD_Zero = 0;
            this.cd_modelo.Size = new System.Drawing.Size(53, 20);
            this.cd_modelo.ST_AutoInc = false;
            this.cd_modelo.ST_DisableAuto = false;
            this.cd_modelo.ST_Float = false;
            this.cd_modelo.ST_Gravar = true;
            this.cd_modelo.ST_Int = true;
            this.cd_modelo.ST_LimpaCampo = true;
            this.cd_modelo.ST_NotNull = true;
            this.cd_modelo.ST_PrimaryKey = false;
            this.cd_modelo.TabIndex = 0;
            this.cd_modelo.TextOld = null;
            this.cd_modelo.Leave += new System.EventHandler(this.cd_modelo_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modelo:";
            // 
            // TFSerieNF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 126);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFSerieNF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Serie NF";
            this.Load += new System.EventHandler(this.TFSerieNF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFSerieNF_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSerie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_modelo;
        private Componentes.EditDefault ds_modelo;
        private Componentes.EditDefault cd_modelo;
        private System.Windows.Forms.BindingSource bsSerie;
        private Componentes.EditDefault ds_serienf;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nr_serie;
        private System.Windows.Forms.Label label2;
        private Componentes.CheckBoxDefault ST_SequenciaAuto;
        public Componentes.ComboBoxDefault tp_serie;
        private Componentes.CheckBoxDefault st_gerasintegra;
        private System.Windows.Forms.Label label4;
    }
}