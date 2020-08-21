namespace Financeiro
{
    partial class TFProcessarLoteBloqueto
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
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFProcessarLoteBloqueto));
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label1;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_lotebusca = new Componentes.EditDefault(this.components);
            this.id_lotebusca = new Componentes.EditDefault(this.components);
            this.pValores = new Componentes.PanelDados(this.components);
            this.dt_processamento = new Componentes.EditData(this.components);
            this.vl_liquido = new Componentes.EditFloat(this.components);
            this.vl_taxa = new Componentes.EditFloat(this.components);
            this.vl_total_titulo = new Componentes.EditFloat(this.components);
            label6 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_liquido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_taxa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_total_titulo)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // barraMenu
            // 
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
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
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Controls.Add(this.pValores, 0, 1);
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pDados
            // 
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.ds_lotebusca);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.id_lotebusca);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // ds_lotebusca
            // 
            resources.ApplyResources(this.ds_lotebusca, "ds_lotebusca");
            this.ds_lotebusca.BackColor = System.Drawing.SystemColors.Window;
            this.ds_lotebusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_lotebusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_lotebusca.Name = "ds_lotebusca";
            this.ds_lotebusca.NM_Alias = "";
            this.ds_lotebusca.NM_Campo = "";
            this.ds_lotebusca.NM_CampoBusca = "";
            this.ds_lotebusca.NM_Param = "";
            this.ds_lotebusca.QTD_Zero = 0;
            this.ds_lotebusca.ST_AutoInc = false;
            this.ds_lotebusca.ST_DisableAuto = false;
            this.ds_lotebusca.ST_Float = false;
            this.ds_lotebusca.ST_Gravar = false;
            this.ds_lotebusca.ST_Int = false;
            this.ds_lotebusca.ST_LimpaCampo = true;
            this.ds_lotebusca.ST_NotNull = true;
            this.ds_lotebusca.ST_PrimaryKey = false;
            this.ds_lotebusca.TextOld = null;
            // 
            // id_lotebusca
            // 
            resources.ApplyResources(this.id_lotebusca, "id_lotebusca");
            this.id_lotebusca.BackColor = System.Drawing.SystemColors.Window;
            this.id_lotebusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_lotebusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_lotebusca.Name = "id_lotebusca";
            this.id_lotebusca.NM_Alias = "";
            this.id_lotebusca.NM_Campo = "";
            this.id_lotebusca.NM_CampoBusca = "";
            this.id_lotebusca.NM_Param = "";
            this.id_lotebusca.QTD_Zero = 0;
            this.id_lotebusca.ST_AutoInc = false;
            this.id_lotebusca.ST_DisableAuto = false;
            this.id_lotebusca.ST_Float = false;
            this.id_lotebusca.ST_Gravar = true;
            this.id_lotebusca.ST_Int = true;
            this.id_lotebusca.ST_LimpaCampo = true;
            this.id_lotebusca.ST_NotNull = false;
            this.id_lotebusca.ST_PrimaryKey = false;
            this.id_lotebusca.TextOld = null;
            // 
            // pValores
            // 
            resources.ApplyResources(this.pValores, "pValores");
            this.pValores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pValores.Controls.Add(this.dt_processamento);
            this.pValores.Controls.Add(label1);
            this.pValores.Controls.Add(label8);
            this.pValores.Controls.Add(this.vl_liquido);
            this.pValores.Controls.Add(label3);
            this.pValores.Controls.Add(this.vl_taxa);
            this.pValores.Controls.Add(label2);
            this.pValores.Controls.Add(this.vl_total_titulo);
            this.pValores.Name = "pValores";
            this.pValores.NM_ProcDeletar = "";
            this.pValores.NM_ProcGravar = "";
            // 
            // dt_processamento
            // 
            resources.ApplyResources(this.dt_processamento, "dt_processamento");
            this.dt_processamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_processamento.Name = "dt_processamento";
            this.dt_processamento.NM_Alias = "";
            this.dt_processamento.NM_Campo = "";
            this.dt_processamento.NM_CampoBusca = "";
            this.dt_processamento.NM_Param = "";
            this.dt_processamento.Operador = "";
            this.dt_processamento.ST_Gravar = false;
            this.dt_processamento.ST_LimpaCampo = true;
            this.dt_processamento.ST_NotNull = false;
            this.dt_processamento.ST_PrimaryKey = false;
            // 
            // vl_liquido
            // 
            resources.ApplyResources(this.vl_liquido, "vl_liquido");
            this.vl_liquido.DecimalPlaces = 2;
            this.vl_liquido.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_liquido.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_liquido.Name = "vl_liquido";
            this.vl_liquido.NM_Alias = "";
            this.vl_liquido.NM_Campo = "";
            this.vl_liquido.NM_Param = "";
            this.vl_liquido.Operador = "";
            this.vl_liquido.ST_AutoInc = false;
            this.vl_liquido.ST_DisableAuto = false;
            this.vl_liquido.ST_Gravar = false;
            this.vl_liquido.ST_LimparCampo = true;
            this.vl_liquido.ST_NotNull = false;
            this.vl_liquido.ST_PrimaryKey = false;
            this.vl_liquido.ValueChanged += new System.EventHandler(this.vl_liquido_ValueChanged);
            // 
            // vl_taxa
            // 
            resources.ApplyResources(this.vl_taxa, "vl_taxa");
            this.vl_taxa.DecimalPlaces = 2;
            this.vl_taxa.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_taxa.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_taxa.Name = "vl_taxa";
            this.vl_taxa.NM_Alias = "";
            this.vl_taxa.NM_Campo = "";
            this.vl_taxa.NM_Param = "";
            this.vl_taxa.Operador = "";
            this.vl_taxa.ST_AutoInc = false;
            this.vl_taxa.ST_DisableAuto = false;
            this.vl_taxa.ST_Gravar = false;
            this.vl_taxa.ST_LimparCampo = true;
            this.vl_taxa.ST_NotNull = false;
            this.vl_taxa.ST_PrimaryKey = false;
            this.vl_taxa.ValueChanged += new System.EventHandler(this.vl_taxa_ValueChanged);
            // 
            // vl_total_titulo
            // 
            resources.ApplyResources(this.vl_total_titulo, "vl_total_titulo");
            this.vl_total_titulo.DecimalPlaces = 2;
            this.vl_total_titulo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_total_titulo.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_total_titulo.Name = "vl_total_titulo";
            this.vl_total_titulo.NM_Alias = "";
            this.vl_total_titulo.NM_Campo = "";
            this.vl_total_titulo.NM_Param = "";
            this.vl_total_titulo.Operador = "";
            this.vl_total_titulo.ReadOnly = true;
            this.vl_total_titulo.ST_AutoInc = false;
            this.vl_total_titulo.ST_DisableAuto = false;
            this.vl_total_titulo.ST_Gravar = false;
            this.vl_total_titulo.ST_LimparCampo = true;
            this.vl_total_titulo.ST_NotNull = false;
            this.vl_total_titulo.ST_PrimaryKey = false;
            this.vl_total_titulo.TabStop = false;
            // 
            // TFProcessarLoteBloqueto
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFProcessarLoteBloqueto";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFProcessarLoteBloqueto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFProcessarLoteBloqueto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pValores.ResumeLayout(false);
            this.pValores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_liquido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_taxa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_total_titulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_lotebusca;
        private Componentes.EditDefault id_lotebusca;
        private Componentes.PanelDados pValores;
        private Componentes.EditFloat vl_total_titulo;
        private Componentes.EditFloat vl_taxa;
        private Componentes.EditFloat vl_liquido;
        private Componentes.EditData dt_processamento;
    }
}