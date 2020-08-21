namespace Servicos
{
    partial class TFLan_SerialClifor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLan_SerialClifor));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pnl_Base = new Componentes.PanelDados(this.components);
            this.pnl_Observacao = new Componentes.PanelDados(this.components);
            this.Produto = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.Observacao = new Componentes.EditDefault(this.components);
            this.CLIFOR_NOVO = new Componentes.EditDefault(this.components);
            this.Observacao_Antiga = new Componentes.EditDefault(this.components);
            this.CLIFOR_ANTIGO = new Componentes.EditDefault(this.components);
            this.NR_Serial = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pnl_Base.SuspendLayout();
            this.pnl_Observacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
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
            // pnl_Base
            // 
            this.pnl_Base.AccessibleDescription = null;
            this.pnl_Base.AccessibleName = null;
            resources.ApplyResources(this.pnl_Base, "pnl_Base");
            this.pnl_Base.BackgroundImage = null;
            this.pnl_Base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Base.Controls.Add(this.pnl_Observacao);
            this.pnl_Base.Font = null;
            this.pnl_Base.Name = "pnl_Base";
            this.pnl_Base.NM_ProcDeletar = "";
            this.pnl_Base.NM_ProcGravar = "";
            // 
            // pnl_Observacao
            // 
            this.pnl_Observacao.AccessibleDescription = null;
            this.pnl_Observacao.AccessibleName = null;
            resources.ApplyResources(this.pnl_Observacao, "pnl_Observacao");
            this.pnl_Observacao.BackgroundImage = null;
            this.pnl_Observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Observacao.Controls.Add(this.Produto);
            this.pnl_Observacao.Controls.Add(this.label5);
            this.pnl_Observacao.Controls.Add(this.Observacao);
            this.pnl_Observacao.Controls.Add(this.CLIFOR_NOVO);
            this.pnl_Observacao.Controls.Add(this.Observacao_Antiga);
            this.pnl_Observacao.Controls.Add(this.CLIFOR_ANTIGO);
            this.pnl_Observacao.Controls.Add(this.NR_Serial);
            this.pnl_Observacao.Controls.Add(this.label3);
            this.pnl_Observacao.Controls.Add(this.label4);
            this.pnl_Observacao.Controls.Add(this.label2);
            this.pnl_Observacao.Controls.Add(this.label1);
            this.pnl_Observacao.Controls.Add(this.label6);
            this.pnl_Observacao.Font = null;
            this.pnl_Observacao.Name = "pnl_Observacao";
            this.pnl_Observacao.NM_ProcDeletar = "";
            this.pnl_Observacao.NM_ProcGravar = "";
            // 
            // Produto
            // 
            this.Produto.AccessibleDescription = null;
            this.Produto.AccessibleName = null;
            resources.ApplyResources(this.Produto, "Produto");
            this.Produto.BackColor = System.Drawing.SystemColors.Window;
            this.Produto.BackgroundImage = null;
            this.Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Produto.Name = "Produto";
            this.Produto.NM_Alias = "";
            this.Produto.NM_Campo = "ds_tptransp";
            this.Produto.NM_CampoBusca = "ds_tptransp";
            this.Produto.NM_Param = "@P_NM_CLIFOR";
            this.Produto.QTD_Zero = 0;
            this.Produto.ReadOnly = true;
            this.Produto.ST_AutoInc = false;
            this.Produto.ST_DisableAuto = false;
            this.Produto.ST_Float = false;
            this.Produto.ST_Gravar = false;
            this.Produto.ST_Int = false;
            this.Produto.ST_LimpaCampo = true;
            this.Produto.ST_NotNull = false;
            this.Produto.ST_PrimaryKey = false;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // Observacao
            // 
            this.Observacao.AccessibleDescription = null;
            this.Observacao.AccessibleName = null;
            resources.ApplyResources(this.Observacao, "Observacao");
            this.Observacao.BackColor = System.Drawing.SystemColors.Window;
            this.Observacao.BackgroundImage = null;
            this.Observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Observacao.Name = "Observacao";
            this.Observacao.NM_Alias = "";
            this.Observacao.NM_Campo = "ds_tptransp";
            this.Observacao.NM_CampoBusca = "ds_tptransp";
            this.Observacao.NM_Param = "@P_NM_CLIFOR";
            this.Observacao.QTD_Zero = 0;
            this.Observacao.ST_AutoInc = false;
            this.Observacao.ST_DisableAuto = false;
            this.Observacao.ST_Float = false;
            this.Observacao.ST_Gravar = false;
            this.Observacao.ST_Int = false;
            this.Observacao.ST_LimpaCampo = true;
            this.Observacao.ST_NotNull = false;
            this.Observacao.ST_PrimaryKey = false;
            // 
            // CLIFOR_NOVO
            // 
            this.CLIFOR_NOVO.AccessibleDescription = null;
            this.CLIFOR_NOVO.AccessibleName = null;
            resources.ApplyResources(this.CLIFOR_NOVO, "CLIFOR_NOVO");
            this.CLIFOR_NOVO.BackColor = System.Drawing.SystemColors.Window;
            this.CLIFOR_NOVO.BackgroundImage = null;
            this.CLIFOR_NOVO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CLIFOR_NOVO.Name = "CLIFOR_NOVO";
            this.CLIFOR_NOVO.NM_Alias = "";
            this.CLIFOR_NOVO.NM_Campo = "ds_tptransp";
            this.CLIFOR_NOVO.NM_CampoBusca = "ds_tptransp";
            this.CLIFOR_NOVO.NM_Param = "@P_NM_CLIFOR";
            this.CLIFOR_NOVO.QTD_Zero = 0;
            this.CLIFOR_NOVO.ReadOnly = true;
            this.CLIFOR_NOVO.ST_AutoInc = false;
            this.CLIFOR_NOVO.ST_DisableAuto = false;
            this.CLIFOR_NOVO.ST_Float = false;
            this.CLIFOR_NOVO.ST_Gravar = false;
            this.CLIFOR_NOVO.ST_Int = false;
            this.CLIFOR_NOVO.ST_LimpaCampo = true;
            this.CLIFOR_NOVO.ST_NotNull = false;
            this.CLIFOR_NOVO.ST_PrimaryKey = false;
            // 
            // Observacao_Antiga
            // 
            this.Observacao_Antiga.AccessibleDescription = null;
            this.Observacao_Antiga.AccessibleName = null;
            resources.ApplyResources(this.Observacao_Antiga, "Observacao_Antiga");
            this.Observacao_Antiga.BackColor = System.Drawing.SystemColors.Window;
            this.Observacao_Antiga.BackgroundImage = null;
            this.Observacao_Antiga.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Observacao_Antiga.Name = "Observacao_Antiga";
            this.Observacao_Antiga.NM_Alias = "";
            this.Observacao_Antiga.NM_Campo = "ds_tptransp";
            this.Observacao_Antiga.NM_CampoBusca = "ds_tptransp";
            this.Observacao_Antiga.NM_Param = "@P_NM_CLIFOR";
            this.Observacao_Antiga.QTD_Zero = 0;
            this.Observacao_Antiga.ReadOnly = true;
            this.Observacao_Antiga.ST_AutoInc = false;
            this.Observacao_Antiga.ST_DisableAuto = false;
            this.Observacao_Antiga.ST_Float = false;
            this.Observacao_Antiga.ST_Gravar = false;
            this.Observacao_Antiga.ST_Int = false;
            this.Observacao_Antiga.ST_LimpaCampo = true;
            this.Observacao_Antiga.ST_NotNull = false;
            this.Observacao_Antiga.ST_PrimaryKey = false;
            // 
            // CLIFOR_ANTIGO
            // 
            this.CLIFOR_ANTIGO.AccessibleDescription = null;
            this.CLIFOR_ANTIGO.AccessibleName = null;
            resources.ApplyResources(this.CLIFOR_ANTIGO, "CLIFOR_ANTIGO");
            this.CLIFOR_ANTIGO.BackColor = System.Drawing.SystemColors.Window;
            this.CLIFOR_ANTIGO.BackgroundImage = null;
            this.CLIFOR_ANTIGO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CLIFOR_ANTIGO.Name = "CLIFOR_ANTIGO";
            this.CLIFOR_ANTIGO.NM_Alias = "";
            this.CLIFOR_ANTIGO.NM_Campo = "ds_tptransp";
            this.CLIFOR_ANTIGO.NM_CampoBusca = "ds_tptransp";
            this.CLIFOR_ANTIGO.NM_Param = "@P_NM_CLIFOR";
            this.CLIFOR_ANTIGO.QTD_Zero = 0;
            this.CLIFOR_ANTIGO.ReadOnly = true;
            this.CLIFOR_ANTIGO.ST_AutoInc = false;
            this.CLIFOR_ANTIGO.ST_DisableAuto = false;
            this.CLIFOR_ANTIGO.ST_Float = false;
            this.CLIFOR_ANTIGO.ST_Gravar = false;
            this.CLIFOR_ANTIGO.ST_Int = false;
            this.CLIFOR_ANTIGO.ST_LimpaCampo = true;
            this.CLIFOR_ANTIGO.ST_NotNull = false;
            this.CLIFOR_ANTIGO.ST_PrimaryKey = false;
            // 
            // NR_Serial
            // 
            this.NR_Serial.AccessibleDescription = null;
            this.NR_Serial.AccessibleName = null;
            resources.ApplyResources(this.NR_Serial, "NR_Serial");
            this.NR_Serial.BackColor = System.Drawing.SystemColors.Window;
            this.NR_Serial.BackgroundImage = null;
            this.NR_Serial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NR_Serial.Name = "NR_Serial";
            this.NR_Serial.NM_Alias = "";
            this.NR_Serial.NM_Campo = "ds_tptransp";
            this.NR_Serial.NM_CampoBusca = "ds_tptransp";
            this.NR_Serial.NM_Param = "@P_NM_CLIFOR";
            this.NR_Serial.QTD_Zero = 0;
            this.NR_Serial.ReadOnly = true;
            this.NR_Serial.ST_AutoInc = false;
            this.NR_Serial.ST_DisableAuto = false;
            this.NR_Serial.ST_Float = false;
            this.NR_Serial.ST_Gravar = false;
            this.NR_Serial.ST_Int = false;
            this.NR_Serial.ST_LimpaCampo = true;
            this.NR_Serial.ST_NotNull = false;
            this.NR_Serial.ST_PrimaryKey = false;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // TFLan_SerialClifor
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pnl_Base);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.Icon = null;
            this.Name = "TFLan_SerialClifor";
            this.Load += new System.EventHandler(this.TFLan_SerialClifor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FLan_SerialClifor_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pnl_Base.ResumeLayout(false);
            this.pnl_Observacao.ResumeLayout(false);
            this.pnl_Observacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pnl_Base;
        private Componentes.PanelDados pnl_Observacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public Componentes.EditDefault Observacao;
        public Componentes.EditDefault CLIFOR_NOVO;
        public Componentes.EditDefault Observacao_Antiga;
        public Componentes.EditDefault CLIFOR_ANTIGO;
        public Componentes.EditDefault NR_Serial;
        public Componentes.EditDefault Produto;
        private System.Windows.Forms.Label label5;
    }
}