namespace Contabil
{
    partial class TFLanctoAvulso
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
            System.Windows.Forms.Label label10;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanctoAvulso));
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.deb_cred = new Componentes.ComboBoxDefault(this.components);
            this.bsLanctoAvulso = new System.Windows.Forms.BindingSource(this.components);
            this.classificacao = new Componentes.EditDefault(this.components);
            this.vl_lancto = new Componentes.EditFloat(this.components);
            this.ds_conta_ctb = new Componentes.EditDefault(this.components);
            this.bb_conta_ctb = new System.Windows.Forms.Button();
            this.cd_conta_ctb = new Componentes.EditDefault(this.components);
            label10 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLanctoAvulso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_lancto)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.deb_cred);
            this.pDados.Controls.Add(this.classificacao);
            this.pDados.Controls.Add(this.vl_lancto);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.ds_conta_ctb);
            this.pDados.Controls.Add(this.bb_conta_ctb);
            this.pDados.Controls.Add(label10);
            this.pDados.Controls.Add(this.cd_conta_ctb);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // deb_cred
            // 
            this.deb_cred.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsLanctoAvulso, "D_C", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.deb_cred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deb_cred.FormattingEnabled = true;
            resources.ApplyResources(this.deb_cred, "deb_cred");
            this.deb_cred.Name = "deb_cred";
            this.deb_cred.NM_Alias = "";
            this.deb_cred.NM_Campo = "";
            this.deb_cred.NM_Param = "";
            this.deb_cred.ST_Gravar = false;
            this.deb_cred.ST_LimparCampo = true;
            this.deb_cred.ST_NotNull = false;
            // 
            // bsLanctoAvulso
            // 
            this.bsLanctoAvulso.DataSource = typeof(CamadaDados.Contabil.TList_LanctoAvulso);
            // 
            // classificacao
            // 
            this.classificacao.BackColor = System.Drawing.Color.White;
            this.classificacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLanctoAvulso, "Cd_classificacao_ctb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.classificacao, "classificacao");
            this.classificacao.Name = "classificacao";
            this.classificacao.NM_Alias = "";
            this.classificacao.NM_Campo = "CD_Classificacao";
            this.classificacao.NM_CampoBusca = "CD_Classificacao";
            this.classificacao.NM_Param = "@P_CD_EMPRESA";
            this.classificacao.QTD_Zero = 0;
            this.classificacao.ST_AutoInc = false;
            this.classificacao.ST_DisableAuto = false;
            this.classificacao.ST_Float = false;
            this.classificacao.ST_Gravar = false;
            this.classificacao.ST_Int = true;
            this.classificacao.ST_LimpaCampo = true;
            this.classificacao.ST_NotNull = false;
            this.classificacao.ST_PrimaryKey = false;
            this.classificacao.TextOld = null;
            // 
            // vl_lancto
            // 
            this.vl_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsLanctoAvulso, "Vl_lancto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_lancto.DecimalPlaces = 2;
            resources.ApplyResources(this.vl_lancto, "vl_lancto");
            this.vl_lancto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_lancto.Name = "vl_lancto";
            this.vl_lancto.NM_Alias = "";
            this.vl_lancto.NM_Campo = "";
            this.vl_lancto.NM_Param = "";
            this.vl_lancto.Operador = "";
            this.vl_lancto.ST_AutoInc = false;
            this.vl_lancto.ST_DisableAuto = false;
            this.vl_lancto.ST_Gravar = true;
            this.vl_lancto.ST_LimparCampo = true;
            this.vl_lancto.ST_NotNull = true;
            this.vl_lancto.ST_PrimaryKey = false;
            // 
            // ds_conta_ctb
            // 
            this.ds_conta_ctb.BackColor = System.Drawing.Color.White;
            this.ds_conta_ctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_conta_ctb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_conta_ctb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLanctoAvulso, "Ds_conta_ctb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_conta_ctb, "ds_conta_ctb");
            this.ds_conta_ctb.Name = "ds_conta_ctb";
            this.ds_conta_ctb.NM_Alias = "";
            this.ds_conta_ctb.NM_Campo = "DS_ContaCTB";
            this.ds_conta_ctb.NM_CampoBusca = "DS_ContaCTB";
            this.ds_conta_ctb.NM_Param = "@P_CD_EMPRESA";
            this.ds_conta_ctb.QTD_Zero = 0;
            this.ds_conta_ctb.ST_AutoInc = false;
            this.ds_conta_ctb.ST_DisableAuto = false;
            this.ds_conta_ctb.ST_Float = false;
            this.ds_conta_ctb.ST_Gravar = false;
            this.ds_conta_ctb.ST_Int = true;
            this.ds_conta_ctb.ST_LimpaCampo = true;
            this.ds_conta_ctb.ST_NotNull = false;
            this.ds_conta_ctb.ST_PrimaryKey = false;
            this.ds_conta_ctb.TextOld = null;
            // 
            // bb_conta_ctb
            // 
            this.bb_conta_ctb.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_conta_ctb, "bb_conta_ctb");
            this.bb_conta_ctb.Name = "bb_conta_ctb";
            this.bb_conta_ctb.UseVisualStyleBackColor = false;
            this.bb_conta_ctb.Click += new System.EventHandler(this.bb_conta_ctb_Click);
            // 
            // cd_conta_ctb
            // 
            this.cd_conta_ctb.BackColor = System.Drawing.Color.White;
            this.cd_conta_ctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_conta_ctb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_conta_ctb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLanctoAvulso, "Cd_conta_ctbstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_conta_ctb, "cd_conta_ctb");
            this.cd_conta_ctb.Name = "cd_conta_ctb";
            this.cd_conta_ctb.NM_Alias = "";
            this.cd_conta_ctb.NM_Campo = "CD_Conta_CTB";
            this.cd_conta_ctb.NM_CampoBusca = "CD_Conta_CTB";
            this.cd_conta_ctb.NM_Param = "@P_CD_EMPRESA";
            this.cd_conta_ctb.QTD_Zero = 0;
            this.cd_conta_ctb.ST_AutoInc = false;
            this.cd_conta_ctb.ST_DisableAuto = false;
            this.cd_conta_ctb.ST_Float = false;
            this.cd_conta_ctb.ST_Gravar = true;
            this.cd_conta_ctb.ST_Int = true;
            this.cd_conta_ctb.ST_LimpaCampo = true;
            this.cd_conta_ctb.ST_NotNull = true;
            this.cd_conta_ctb.ST_PrimaryKey = false;
            this.cd_conta_ctb.TextOld = null;
            this.cd_conta_ctb.Leave += new System.EventHandler(this.cd_conta_ctb_Leave);
            // 
            // TFLanctoAvulso
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanctoAvulso";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanctoAvulso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanctoAvulso_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLanctoAvulso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_lancto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsLanctoAvulso;
        private Componentes.EditFloat vl_lancto;
        private Componentes.EditDefault ds_conta_ctb;
        private System.Windows.Forms.Button bb_conta_ctb;
        private Componentes.EditDefault cd_conta_ctb;
        private Componentes.EditDefault classificacao;
        private Componentes.ComboBoxDefault deb_cred;
    }
}