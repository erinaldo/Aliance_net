namespace Sementes
{
    partial class TFReprovarLote
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
            System.Windows.Forms.Label label11;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFReprovarLote));
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.ds_motivorefugo = new Componentes.EditDefault(this.components);
            this.pDetalhe = new Componentes.PanelDados(this.components);
            this.sigla_unidamostra = new Componentes.EditDefault(this.components);
            this.qtd_amostra = new Componentes.EditFloat(this.components);
            this.dt_lote = new Componentes.EditData(this.components);
            this.ds_amostra = new Componentes.EditDefault(this.components);
            this.cd_amostra = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.id_lote = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.anosafra = new Componentes.EditDefault(this.components);
            this.ds_safra = new Componentes.EditDefault(this.components);
            this.bsLoteSemente = new System.Windows.Forms.BindingSource(this.components);
            label11 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pDetalhe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_amostra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoteSemente)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            label11.AccessibleDescription = null;
            label11.AccessibleName = null;
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // label8
            // 
            label8.AccessibleDescription = null;
            label8.AccessibleName = null;
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // label4
            // 
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label3
            // 
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Font = null;
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AccessibleDescription = null;
            this.BB_Gravar.AccessibleName = null;
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.BackgroundImage = null;
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AccessibleDescription = null;
            this.BB_Cancelar.AccessibleName = null;
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.BackgroundImage = null;
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.ds_motivorefugo);
            this.pDados.Controls.Add(this.pDetalhe);
            this.pDados.Font = null;
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Font = null;
            this.label6.Name = "label6";
            // 
            // ds_motivorefugo
            // 
            this.ds_motivorefugo.AccessibleDescription = null;
            this.ds_motivorefugo.AccessibleName = null;
            resources.ApplyResources(this.ds_motivorefugo, "ds_motivorefugo");
            this.ds_motivorefugo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_motivorefugo.BackgroundImage = null;
            this.ds_motivorefugo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_motivorefugo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Ds_motivorefugo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_motivorefugo.Font = null;
            this.ds_motivorefugo.Name = "ds_motivorefugo";
            this.ds_motivorefugo.NM_Alias = "";
            this.ds_motivorefugo.NM_Campo = "";
            this.ds_motivorefugo.NM_CampoBusca = "";
            this.ds_motivorefugo.NM_Param = "";
            this.ds_motivorefugo.QTD_Zero = 0;
            this.ds_motivorefugo.ST_AutoInc = false;
            this.ds_motivorefugo.ST_DisableAuto = false;
            this.ds_motivorefugo.ST_Float = false;
            this.ds_motivorefugo.ST_Gravar = true;
            this.ds_motivorefugo.ST_Int = false;
            this.ds_motivorefugo.ST_LimpaCampo = true;
            this.ds_motivorefugo.ST_NotNull = true;
            this.ds_motivorefugo.ST_PrimaryKey = false;
            // 
            // pDetalhe
            // 
            this.pDetalhe.AccessibleDescription = null;
            this.pDetalhe.AccessibleName = null;
            resources.ApplyResources(this.pDetalhe, "pDetalhe");
            this.pDetalhe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pDetalhe.BackgroundImage = null;
            this.pDetalhe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDetalhe.Controls.Add(this.sigla_unidamostra);
            this.pDetalhe.Controls.Add(this.qtd_amostra);
            this.pDetalhe.Controls.Add(label11);
            this.pDetalhe.Controls.Add(this.dt_lote);
            this.pDetalhe.Controls.Add(label8);
            this.pDetalhe.Controls.Add(this.ds_amostra);
            this.pDetalhe.Controls.Add(label4);
            this.pDetalhe.Controls.Add(this.cd_amostra);
            this.pDetalhe.Controls.Add(this.nm_empresa);
            this.pDetalhe.Controls.Add(this.cd_empresa);
            this.pDetalhe.Controls.Add(this.label2);
            this.pDetalhe.Controls.Add(this.id_lote);
            this.pDetalhe.Controls.Add(this.label1);
            this.pDetalhe.Controls.Add(this.anosafra);
            this.pDetalhe.Controls.Add(label3);
            this.pDetalhe.Controls.Add(this.ds_safra);
            this.pDetalhe.Font = null;
            this.pDetalhe.Name = "pDetalhe";
            this.pDetalhe.NM_ProcDeletar = "";
            this.pDetalhe.NM_ProcGravar = "";
            // 
            // sigla_unidamostra
            // 
            this.sigla_unidamostra.AccessibleDescription = null;
            this.sigla_unidamostra.AccessibleName = null;
            resources.ApplyResources(this.sigla_unidamostra, "sigla_unidamostra");
            this.sigla_unidamostra.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidamostra.BackgroundImage = null;
            this.sigla_unidamostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidamostra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Sigla_unidamostra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidamostra.Font = null;
            this.sigla_unidamostra.Name = "sigla_unidamostra";
            this.sigla_unidamostra.NM_Alias = "";
            this.sigla_unidamostra.NM_Campo = "sigla_unidade";
            this.sigla_unidamostra.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidamostra.NM_Param = "@P_NM_EMPRESA";
            this.sigla_unidamostra.QTD_Zero = 0;
            this.sigla_unidamostra.ST_AutoInc = false;
            this.sigla_unidamostra.ST_DisableAuto = false;
            this.sigla_unidamostra.ST_Float = false;
            this.sigla_unidamostra.ST_Gravar = false;
            this.sigla_unidamostra.ST_Int = false;
            this.sigla_unidamostra.ST_LimpaCampo = true;
            this.sigla_unidamostra.ST_NotNull = false;
            this.sigla_unidamostra.ST_PrimaryKey = false;
            // 
            // qtd_amostra
            // 
            this.qtd_amostra.AccessibleDescription = null;
            this.qtd_amostra.AccessibleName = null;
            resources.ApplyResources(this.qtd_amostra, "qtd_amostra");
            this.qtd_amostra.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsLoteSemente, "Qtd_lote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_amostra.DecimalPlaces = 3;
            this.qtd_amostra.Font = null;
            this.qtd_amostra.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_amostra.Name = "qtd_amostra";
            this.qtd_amostra.NM_Alias = "";
            this.qtd_amostra.NM_Campo = "";
            this.qtd_amostra.NM_Param = "";
            this.qtd_amostra.Operador = "";
            this.qtd_amostra.ST_AutoInc = false;
            this.qtd_amostra.ST_DisableAuto = false;
            this.qtd_amostra.ST_Gravar = true;
            this.qtd_amostra.ST_LimparCampo = true;
            this.qtd_amostra.ST_NotNull = true;
            this.qtd_amostra.ST_PrimaryKey = false;
            // 
            // dt_lote
            // 
            this.dt_lote.AccessibleDescription = null;
            this.dt_lote.AccessibleName = null;
            resources.ApplyResources(this.dt_lote, "dt_lote");
            this.dt_lote.BackgroundImage = null;
            this.dt_lote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Dt_lotestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_lote.Font = null;
            this.dt_lote.Name = "dt_lote";
            this.dt_lote.NM_Alias = "";
            this.dt_lote.NM_Campo = "";
            this.dt_lote.NM_CampoBusca = "";
            this.dt_lote.NM_Param = "";
            this.dt_lote.Operador = "";
            this.dt_lote.ST_Gravar = true;
            this.dt_lote.ST_LimpaCampo = true;
            this.dt_lote.ST_NotNull = true;
            this.dt_lote.ST_PrimaryKey = false;
            // 
            // ds_amostra
            // 
            this.ds_amostra.AccessibleDescription = null;
            this.ds_amostra.AccessibleName = null;
            resources.ApplyResources(this.ds_amostra, "ds_amostra");
            this.ds_amostra.BackColor = System.Drawing.SystemColors.Window;
            this.ds_amostra.BackgroundImage = null;
            this.ds_amostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_amostra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Ds_amostra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_amostra.Font = null;
            this.ds_amostra.Name = "ds_amostra";
            this.ds_amostra.NM_Alias = "";
            this.ds_amostra.NM_Campo = "ds_produto";
            this.ds_amostra.NM_CampoBusca = "ds_produto";
            this.ds_amostra.NM_Param = "@P_NM_EMPRESA";
            this.ds_amostra.QTD_Zero = 0;
            this.ds_amostra.ST_AutoInc = false;
            this.ds_amostra.ST_DisableAuto = false;
            this.ds_amostra.ST_Float = false;
            this.ds_amostra.ST_Gravar = false;
            this.ds_amostra.ST_Int = false;
            this.ds_amostra.ST_LimpaCampo = true;
            this.ds_amostra.ST_NotNull = false;
            this.ds_amostra.ST_PrimaryKey = false;
            // 
            // cd_amostra
            // 
            this.cd_amostra.AccessibleDescription = null;
            this.cd_amostra.AccessibleName = null;
            resources.ApplyResources(this.cd_amostra, "cd_amostra");
            this.cd_amostra.BackColor = System.Drawing.Color.White;
            this.cd_amostra.BackgroundImage = null;
            this.cd_amostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_amostra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Cd_amostra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_amostra.Font = null;
            this.cd_amostra.Name = "cd_amostra";
            this.cd_amostra.NM_Alias = "";
            this.cd_amostra.NM_Campo = "cd_produto";
            this.cd_amostra.NM_CampoBusca = "cd_produto";
            this.cd_amostra.NM_Param = "@P_CD_EMPRESA";
            this.cd_amostra.QTD_Zero = 0;
            this.cd_amostra.ST_AutoInc = false;
            this.cd_amostra.ST_DisableAuto = false;
            this.cd_amostra.ST_Float = false;
            this.cd_amostra.ST_Gravar = true;
            this.cd_amostra.ST_Int = true;
            this.cd_amostra.ST_LimpaCampo = true;
            this.cd_amostra.ST_NotNull = true;
            this.cd_amostra.ST_PrimaryKey = false;
            // 
            // nm_empresa
            // 
            this.nm_empresa.AccessibleDescription = null;
            this.nm_empresa.AccessibleName = null;
            resources.ApplyResources(this.nm_empresa, "nm_empresa");
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BackgroundImage = null;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Font = null;
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "";
            this.nm_empresa.NM_CampoBusca = "";
            this.nm_empresa.NM_Param = "";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            // 
            // cd_empresa
            // 
            this.cd_empresa.AccessibleDescription = null;
            this.cd_empresa.AccessibleName = null;
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BackgroundImage = null;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Font = null;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "";
            this.cd_empresa.NM_CampoBusca = "";
            this.cd_empresa.NM_Param = "";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // id_lote
            // 
            this.id_lote.AccessibleDescription = null;
            this.id_lote.AccessibleName = null;
            resources.ApplyResources(this.id_lote, "id_lote");
            this.id_lote.BackColor = System.Drawing.SystemColors.Window;
            this.id_lote.BackgroundImage = null;
            this.id_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_lote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Id_lote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_lote.Font = null;
            this.id_lote.Name = "id_lote";
            this.id_lote.NM_Alias = "";
            this.id_lote.NM_Campo = "";
            this.id_lote.NM_CampoBusca = "";
            this.id_lote.NM_Param = "";
            this.id_lote.QTD_Zero = 0;
            this.id_lote.ST_AutoInc = false;
            this.id_lote.ST_DisableAuto = false;
            this.id_lote.ST_Float = false;
            this.id_lote.ST_Gravar = false;
            this.id_lote.ST_Int = false;
            this.id_lote.ST_LimpaCampo = true;
            this.id_lote.ST_NotNull = false;
            this.id_lote.ST_PrimaryKey = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // anosafra
            // 
            this.anosafra.AccessibleDescription = null;
            this.anosafra.AccessibleName = null;
            resources.ApplyResources(this.anosafra, "anosafra");
            this.anosafra.BackColor = System.Drawing.Color.White;
            this.anosafra.BackgroundImage = null;
            this.anosafra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.anosafra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Anosafra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.anosafra.Font = null;
            this.anosafra.Name = "anosafra";
            this.anosafra.NM_Alias = "";
            this.anosafra.NM_Campo = "anosafra";
            this.anosafra.NM_CampoBusca = "anosafra";
            this.anosafra.NM_Param = "@P_CD_EMPRESA";
            this.anosafra.QTD_Zero = 0;
            this.anosafra.ST_AutoInc = false;
            this.anosafra.ST_DisableAuto = false;
            this.anosafra.ST_Float = false;
            this.anosafra.ST_Gravar = true;
            this.anosafra.ST_Int = true;
            this.anosafra.ST_LimpaCampo = true;
            this.anosafra.ST_NotNull = false;
            this.anosafra.ST_PrimaryKey = false;
            // 
            // ds_safra
            // 
            this.ds_safra.AccessibleDescription = null;
            this.ds_safra.AccessibleName = null;
            resources.ApplyResources(this.ds_safra, "ds_safra");
            this.ds_safra.BackColor = System.Drawing.SystemColors.Window;
            this.ds_safra.BackgroundImage = null;
            this.ds_safra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_safra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Ds_safra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_safra.Font = null;
            this.ds_safra.Name = "ds_safra";
            this.ds_safra.NM_Alias = "";
            this.ds_safra.NM_Campo = "ds_safra";
            this.ds_safra.NM_CampoBusca = "ds_safra";
            this.ds_safra.NM_Param = "@P_NM_EMPRESA";
            this.ds_safra.QTD_Zero = 0;
            this.ds_safra.ST_AutoInc = false;
            this.ds_safra.ST_DisableAuto = false;
            this.ds_safra.ST_Float = false;
            this.ds_safra.ST_Gravar = false;
            this.ds_safra.ST_Int = false;
            this.ds_safra.ST_LimpaCampo = true;
            this.ds_safra.ST_NotNull = false;
            this.ds_safra.ST_PrimaryKey = false;
            // 
            // bsLoteSemente
            // 
            this.bsLoteSemente.DataSource = typeof(CamadaDados.Sementes.TList_LoteSemente);
            // 
            // TFReprovarLote
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFReprovarLote";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFReprovarLote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFReprovarLote_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pDetalhe.ResumeLayout(false);
            this.pDetalhe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_amostra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoteSemente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.BindingSource bsLoteSemente;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault ds_motivorefugo;
        private Componentes.PanelDados pDetalhe;
        private Componentes.EditDefault sigla_unidamostra;
        private Componentes.EditFloat qtd_amostra;
        private Componentes.EditData dt_lote;
        private Componentes.EditDefault ds_amostra;
        private Componentes.EditDefault cd_amostra;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault id_lote;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault anosafra;
        private Componentes.EditDefault ds_safra;
    }
}