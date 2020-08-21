namespace Financeiro
{
    partial class TFAtualizaSeqRemessa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAtualizaSeqRemessa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.id_config = new Componentes.EditDefault(this.components);
            this.nr_seqremessa = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nr_seqatual = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cfgboleto = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(480, 43);
            this.barraMenu.TabIndex = 11;
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
            this.pDados.Controls.Add(this.id_config);
            this.pDados.Controls.Add(this.nr_seqremessa);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.nr_seqatual);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cfgboleto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(480, 96);
            this.pDados.TabIndex = 12;
            // 
            // id_config
            // 
            this.id_config.BackColor = System.Drawing.SystemColors.Window;
            this.id_config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_config.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_config.Enabled = false;
            this.id_config.Location = new System.Drawing.Point(15, 22);
            this.id_config.Name = "id_config";
            this.id_config.NM_Alias = "";
            this.id_config.NM_Campo = "";
            this.id_config.NM_CampoBusca = "";
            this.id_config.NM_Param = "";
            this.id_config.QTD_Zero = 0;
            this.id_config.Size = new System.Drawing.Size(56, 20);
            this.id_config.ST_AutoInc = false;
            this.id_config.ST_DisableAuto = false;
            this.id_config.ST_Float = false;
            this.id_config.ST_Gravar = false;
            this.id_config.ST_Int = false;
            this.id_config.ST_LimpaCampo = true;
            this.id_config.ST_NotNull = false;
            this.id_config.ST_PrimaryKey = false;
            this.id_config.TabIndex = 7;
            this.id_config.TextOld = null;
            // 
            // nr_seqremessa
            // 
            this.nr_seqremessa.BackColor = System.Drawing.SystemColors.Window;
            this.nr_seqremessa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_seqremessa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_seqremessa.Location = new System.Drawing.Point(121, 61);
            this.nr_seqremessa.Name = "nr_seqremessa";
            this.nr_seqremessa.NM_Alias = "";
            this.nr_seqremessa.NM_Campo = "";
            this.nr_seqremessa.NM_CampoBusca = "";
            this.nr_seqremessa.NM_Param = "";
            this.nr_seqremessa.QTD_Zero = 0;
            this.nr_seqremessa.Size = new System.Drawing.Size(100, 20);
            this.nr_seqremessa.ST_AutoInc = false;
            this.nr_seqremessa.ST_DisableAuto = false;
            this.nr_seqremessa.ST_Float = false;
            this.nr_seqremessa.ST_Gravar = false;
            this.nr_seqremessa.ST_Int = true;
            this.nr_seqremessa.ST_LimpaCampo = true;
            this.nr_seqremessa.ST_NotNull = false;
            this.nr_seqremessa.ST_PrimaryKey = false;
            this.nr_seqremessa.TabIndex = 6;
            this.nr_seqremessa.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nº Seq. Remessa";
            // 
            // nr_seqatual
            // 
            this.nr_seqatual.BackColor = System.Drawing.SystemColors.Window;
            this.nr_seqatual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_seqatual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_seqatual.Enabled = false;
            this.nr_seqatual.Location = new System.Drawing.Point(15, 61);
            this.nr_seqatual.Name = "nr_seqatual";
            this.nr_seqatual.NM_Alias = "";
            this.nr_seqatual.NM_Campo = "";
            this.nr_seqatual.NM_CampoBusca = "";
            this.nr_seqatual.NM_Param = "";
            this.nr_seqatual.QTD_Zero = 0;
            this.nr_seqatual.Size = new System.Drawing.Size(100, 20);
            this.nr_seqatual.ST_AutoInc = false;
            this.nr_seqatual.ST_DisableAuto = false;
            this.nr_seqatual.ST_Float = false;
            this.nr_seqatual.ST_Gravar = false;
            this.nr_seqatual.ST_Int = false;
            this.nr_seqatual.ST_LimpaCampo = true;
            this.nr_seqatual.ST_NotNull = false;
            this.nr_seqatual.ST_PrimaryKey = false;
            this.nr_seqatual.TabIndex = 4;
            this.nr_seqatual.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nº Seq. Atual";
            // 
            // cfgboleto
            // 
            this.cfgboleto.BackColor = System.Drawing.SystemColors.Window;
            this.cfgboleto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cfgboleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cfgboleto.Enabled = false;
            this.cfgboleto.Location = new System.Drawing.Point(77, 22);
            this.cfgboleto.Name = "cfgboleto";
            this.cfgboleto.NM_Alias = "";
            this.cfgboleto.NM_Campo = "";
            this.cfgboleto.NM_CampoBusca = "";
            this.cfgboleto.NM_Param = "";
            this.cfgboleto.QTD_Zero = 0;
            this.cfgboleto.Size = new System.Drawing.Size(391, 20);
            this.cfgboleto.ST_AutoInc = false;
            this.cfgboleto.ST_DisableAuto = false;
            this.cfgboleto.ST_Float = false;
            this.cfgboleto.ST_Gravar = false;
            this.cfgboleto.ST_Int = false;
            this.cfgboleto.ST_LimpaCampo = true;
            this.cfgboleto.ST_NotNull = false;
            this.cfgboleto.ST_PrimaryKey = false;
            this.cfgboleto.TabIndex = 2;
            this.cfgboleto.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cfg. Boleto";
            // 
            // TFAtualizaSeqRemessa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 139);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAtualizaSeqRemessa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizar Sequencial Remessa";
            this.Load += new System.EventHandler(this.TFAtualizaSeqRemessa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAtualizaSeqRemessa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault nr_seqremessa;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nr_seqatual;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cfgboleto;
        private Componentes.EditDefault id_config;
    }
}