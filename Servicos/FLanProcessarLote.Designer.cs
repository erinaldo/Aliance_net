namespace Servicos
{
    partial class TFLanProcessarLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanProcessarLote));
            System.Windows.Forms.Label label1;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_lotebusca = new Componentes.EditDefault(this.components);
            this.id_lotebusca = new Componentes.EditDefault(this.components);
            this.pValores = new Componentes.PanelDados(this.components);
            this.st_gerarpedido = new Componentes.CheckBoxDefault(this.components);
            this.dt_processamento = new Componentes.EditData(this.components);
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pValores.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.AccessibleDescription = null;
            label6.AccessibleName = null;
            resources.ApplyResources(label6, "label6");
            label6.Font = null;
            label6.Name = "label6";
            // 
            // label1
            // 
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
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
            // tlpCentral
            // 
            this.tlpCentral.AccessibleDescription = null;
            this.tlpCentral.AccessibleName = null;
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.BackgroundImage = null;
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Controls.Add(this.pValores, 0, 1);
            this.tlpCentral.Font = null;
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pDados.BackgroundImage = null;
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.ds_lotebusca);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.id_lotebusca);
            this.pDados.Font = null;
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // ds_lotebusca
            // 
            this.ds_lotebusca.AccessibleDescription = null;
            this.ds_lotebusca.AccessibleName = null;
            resources.ApplyResources(this.ds_lotebusca, "ds_lotebusca");
            this.ds_lotebusca.BackColor = System.Drawing.SystemColors.Window;
            this.ds_lotebusca.BackgroundImage = null;
            this.ds_lotebusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_lotebusca.Font = null;
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
            // 
            // id_lotebusca
            // 
            this.id_lotebusca.AccessibleDescription = null;
            this.id_lotebusca.AccessibleName = null;
            resources.ApplyResources(this.id_lotebusca, "id_lotebusca");
            this.id_lotebusca.BackColor = System.Drawing.SystemColors.Window;
            this.id_lotebusca.BackgroundImage = null;
            this.id_lotebusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_lotebusca.Font = null;
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
            // 
            // pValores
            // 
            this.pValores.AccessibleDescription = null;
            this.pValores.AccessibleName = null;
            resources.ApplyResources(this.pValores, "pValores");
            this.pValores.BackgroundImage = null;
            this.pValores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pValores.Controls.Add(this.st_gerarpedido);
            this.pValores.Controls.Add(this.dt_processamento);
            this.pValores.Controls.Add(label1);
            this.pValores.Font = null;
            this.pValores.Name = "pValores";
            this.pValores.NM_ProcDeletar = "";
            this.pValores.NM_ProcGravar = "";
            // 
            // st_gerarpedido
            // 
            this.st_gerarpedido.AccessibleDescription = null;
            this.st_gerarpedido.AccessibleName = null;
            resources.ApplyResources(this.st_gerarpedido, "st_gerarpedido");
            this.st_gerarpedido.BackgroundImage = null;
            this.st_gerarpedido.Checked = true;
            this.st_gerarpedido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.st_gerarpedido.Name = "st_gerarpedido";
            this.st_gerarpedido.NM_Alias = "";
            this.st_gerarpedido.NM_Campo = "";
            this.st_gerarpedido.NM_Param = "";
            this.st_gerarpedido.ST_Gravar = false;
            this.st_gerarpedido.ST_LimparCampo = true;
            this.st_gerarpedido.ST_NotNull = false;
            this.st_gerarpedido.UseVisualStyleBackColor = true;
            this.st_gerarpedido.Vl_False = "";
            this.st_gerarpedido.Vl_True = "";
            // 
            // dt_processamento
            // 
            this.dt_processamento.AccessibleDescription = null;
            this.dt_processamento.AccessibleName = null;
            resources.ApplyResources(this.dt_processamento, "dt_processamento");
            this.dt_processamento.BackgroundImage = null;
            this.dt_processamento.Font = null;
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
            // TFLanProcessarLote
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanProcessarLote";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanProcessarLote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanProcessarLote_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pValores.ResumeLayout(false);
            this.pValores.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private Componentes.CheckBoxDefault st_gerarpedido;
        private Componentes.EditData dt_processamento;
        private Componentes.EditDefault ds_lotebusca;
        private Componentes.EditDefault id_lotebusca;
        private Componentes.PanelDados pValores;
    }
}