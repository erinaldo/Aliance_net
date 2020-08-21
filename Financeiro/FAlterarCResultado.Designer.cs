namespace Financeiro
{
    partial class TFAlterarCResultado
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
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAlterarCResultado));
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label cd_grupocfLabel;
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label1;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pResultado = new Componentes.PanelDados(this.components);
            this.tp_movimento = new Componentes.EditDefault(this.components);
            this.bsCCusto = new System.Windows.Forms.BindingSource(this.components);
            this.vl_lancto = new Componentes.EditFloat(this.components);
            this.ds_grupocfEditDefault = new Componentes.EditDefault(this.components);
            this.cd_grupocfEditDefault = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_ccusto = new Componentes.EditDefault(this.components);
            this.cd_ccusto = new Componentes.EditDefault(this.components);
            this.bb_ccusto = new System.Windows.Forms.Button();
            this.dt_lancto = new Componentes.EditData(this.components);
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cd_grupocfLabel = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_lancto)).BeginInit();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // cd_grupocfLabel
            // 
            resources.ApplyResources(cd_grupocfLabel, "cd_grupocfLabel");
            cd_grupocfLabel.Name = "cd_grupocfLabel";
            // 
            // cd_empresaLabel
            // 
            resources.ApplyResources(cd_empresaLabel, "cd_empresaLabel");
            cd_empresaLabel.Name = "cd_empresaLabel";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
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
            // tlpCentral
            // 
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.Controls.Add(this.pResultado, 0, 0);
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pResultado
            // 
            resources.ApplyResources(this.pResultado, "pResultado");
            this.pResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pResultado.Controls.Add(label1);
            this.pResultado.Controls.Add(this.dt_lancto);
            this.pResultado.Controls.Add(label5);
            this.pResultado.Controls.Add(this.tp_movimento);
            this.pResultado.Controls.Add(label3);
            this.pResultado.Controls.Add(this.vl_lancto);
            this.pResultado.Controls.Add(this.ds_grupocfEditDefault);
            this.pResultado.Controls.Add(cd_grupocfLabel);
            this.pResultado.Controls.Add(this.cd_grupocfEditDefault);
            this.pResultado.Controls.Add(cd_empresaLabel);
            this.pResultado.Controls.Add(this.cd_empresa);
            this.pResultado.Name = "pResultado";
            this.pResultado.NM_ProcDeletar = "";
            this.pResultado.NM_ProcGravar = "";
            // 
            // tp_movimento
            // 
            this.tp_movimento.BackColor = System.Drawing.SystemColors.Window;
            this.tp_movimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_movimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Tipo_movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.tp_movimento, "tp_movimento");
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "";
            this.tp_movimento.NM_Campo = "";
            this.tp_movimento.NM_CampoBusca = "";
            this.tp_movimento.NM_Param = "";
            this.tp_movimento.QTD_Zero = 0;
            this.tp_movimento.ST_AutoInc = false;
            this.tp_movimento.ST_DisableAuto = false;
            this.tp_movimento.ST_Float = false;
            this.tp_movimento.ST_Gravar = false;
            this.tp_movimento.ST_Int = false;
            this.tp_movimento.ST_LimpaCampo = true;
            this.tp_movimento.ST_NotNull = false;
            this.tp_movimento.ST_PrimaryKey = false;
            this.tp_movimento.TextOld = null;
            // 
            // bsCCusto
            // 
            this.bsCCusto.DataSource = typeof(CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto);
            // 
            // vl_lancto
            // 
            this.vl_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCCusto, "Vl_lancto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_lancto.DecimalPlaces = 2;
            resources.ApplyResources(this.vl_lancto, "vl_lancto");
            this.vl_lancto.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
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
            this.vl_lancto.ST_Gravar = false;
            this.vl_lancto.ST_LimparCampo = true;
            this.vl_lancto.ST_NotNull = false;
            this.vl_lancto.ST_PrimaryKey = false;
            // 
            // ds_grupocfEditDefault
            // 
            this.ds_grupocfEditDefault.BackColor = System.Drawing.SystemColors.Window;
            this.ds_grupocfEditDefault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_grupocfEditDefault.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_grupocfEditDefault.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Ds_centroresultado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_grupocfEditDefault, "ds_grupocfEditDefault");
            this.ds_grupocfEditDefault.Name = "ds_grupocfEditDefault";
            this.ds_grupocfEditDefault.NM_Alias = "";
            this.ds_grupocfEditDefault.NM_Campo = "";
            this.ds_grupocfEditDefault.NM_CampoBusca = "";
            this.ds_grupocfEditDefault.NM_Param = "";
            this.ds_grupocfEditDefault.QTD_Zero = 0;
            this.ds_grupocfEditDefault.ST_AutoInc = false;
            this.ds_grupocfEditDefault.ST_DisableAuto = false;
            this.ds_grupocfEditDefault.ST_Float = false;
            this.ds_grupocfEditDefault.ST_Gravar = false;
            this.ds_grupocfEditDefault.ST_Int = false;
            this.ds_grupocfEditDefault.ST_LimpaCampo = true;
            this.ds_grupocfEditDefault.ST_NotNull = false;
            this.ds_grupocfEditDefault.ST_PrimaryKey = false;
            this.ds_grupocfEditDefault.TextOld = null;
            // 
            // cd_grupocfEditDefault
            // 
            this.cd_grupocfEditDefault.BackColor = System.Drawing.SystemColors.Window;
            this.cd_grupocfEditDefault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_grupocfEditDefault.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_grupocfEditDefault.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Cd_centroresult", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_grupocfEditDefault, "cd_grupocfEditDefault");
            this.cd_grupocfEditDefault.Name = "cd_grupocfEditDefault";
            this.cd_grupocfEditDefault.NM_Alias = "";
            this.cd_grupocfEditDefault.NM_Campo = "";
            this.cd_grupocfEditDefault.NM_CampoBusca = "";
            this.cd_grupocfEditDefault.NM_Param = "";
            this.cd_grupocfEditDefault.QTD_Zero = 0;
            this.cd_grupocfEditDefault.ST_AutoInc = false;
            this.cd_grupocfEditDefault.ST_DisableAuto = false;
            this.cd_grupocfEditDefault.ST_Float = false;
            this.cd_grupocfEditDefault.ST_Gravar = false;
            this.cd_grupocfEditDefault.ST_Int = false;
            this.cd_grupocfEditDefault.ST_LimpaCampo = true;
            this.cd_grupocfEditDefault.ST_NotNull = false;
            this.cd_grupocfEditDefault.ST_PrimaryKey = false;
            this.cd_grupocfEditDefault.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
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
            this.cd_empresa.TextOld = null;
            // 
            // pDados
            // 
            this.pDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.ds_ccusto);
            this.pDados.Controls.Add(this.cd_ccusto);
            this.pDados.Controls.Add(this.bb_ccusto);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // ds_ccusto
            // 
            this.ds_ccusto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_ccusto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_ccusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.ds_ccusto, "ds_ccusto");
            this.ds_ccusto.Name = "ds_ccusto";
            this.ds_ccusto.NM_Alias = "";
            this.ds_ccusto.NM_Campo = "ds_centroresultado";
            this.ds_ccusto.NM_CampoBusca = "ds_centroresultado";
            this.ds_ccusto.NM_Param = "@P_NR_DOCTO";
            this.ds_ccusto.QTD_Zero = 0;
            this.ds_ccusto.ST_AutoInc = false;
            this.ds_ccusto.ST_DisableAuto = false;
            this.ds_ccusto.ST_Float = false;
            this.ds_ccusto.ST_Gravar = false;
            this.ds_ccusto.ST_Int = false;
            this.ds_ccusto.ST_LimpaCampo = true;
            this.ds_ccusto.ST_NotNull = false;
            this.ds_ccusto.ST_PrimaryKey = false;
            this.ds_ccusto.TextOld = null;
            // 
            // cd_ccusto
            // 
            this.cd_ccusto.BackColor = System.Drawing.Color.White;
            this.cd_ccusto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_ccusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_ccusto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Cd_ccustoalt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_ccusto, "cd_ccusto");
            this.cd_ccusto.Name = "cd_ccusto";
            this.cd_ccusto.NM_Alias = "";
            this.cd_ccusto.NM_Campo = "cd_centroresult";
            this.cd_ccusto.NM_CampoBusca = "cd_centroresult";
            this.cd_ccusto.NM_Param = "@P_CD_EMPRESA";
            this.cd_ccusto.QTD_Zero = 0;
            this.cd_ccusto.ST_AutoInc = false;
            this.cd_ccusto.ST_DisableAuto = false;
            this.cd_ccusto.ST_Float = false;
            this.cd_ccusto.ST_Gravar = true;
            this.cd_ccusto.ST_Int = true;
            this.cd_ccusto.ST_LimpaCampo = true;
            this.cd_ccusto.ST_NotNull = true;
            this.cd_ccusto.ST_PrimaryKey = false;
            this.cd_ccusto.TextOld = null;
            this.cd_ccusto.Leave += new System.EventHandler(this.cd_ccusto_Leave);
            // 
            // bb_ccusto
            // 
            this.bb_ccusto.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_ccusto, "bb_ccusto");
            this.bb_ccusto.Name = "bb_ccusto";
            this.bb_ccusto.UseVisualStyleBackColor = false;
            this.bb_ccusto.Click += new System.EventHandler(this.bb_ccusto_Click);
            // 
            // dt_lancto
            // 
            this.dt_lancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Dt_lanctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.dt_lancto, "dt_lancto");
            this.dt_lancto.Name = "dt_lancto";
            this.dt_lancto.NM_Alias = "";
            this.dt_lancto.NM_Campo = "";
            this.dt_lancto.NM_CampoBusca = "";
            this.dt_lancto.NM_Param = "";
            this.dt_lancto.Operador = "";
            this.dt_lancto.ST_Gravar = false;
            this.dt_lancto.ST_LimpaCampo = true;
            this.dt_lancto.ST_NotNull = false;
            this.dt_lancto.ST_PrimaryKey = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // TFAlterarCResultado
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAlterarCResultado";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFAlterarCResultado_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAlterarCResultado_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pResultado.ResumeLayout(false);
            this.pResultado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_lancto)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pResultado;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsCCusto;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault cd_grupocfEditDefault;
        private Componentes.EditDefault ds_grupocfEditDefault;
        private Componentes.EditFloat vl_lancto;
        private Componentes.EditDefault ds_ccusto;
        private Componentes.EditDefault cd_ccusto;
        private System.Windows.Forms.Button bb_ccusto;
        private Componentes.EditDefault tp_movimento;
        public System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.EditData dt_lancto;
    }
}