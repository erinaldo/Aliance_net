namespace Proc_Commoditties
{
    partial class TFCartaCorrecaoEletronica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCartaCorrecaoEletronica));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pCorrecao = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_correcao = new Componentes.EditDefault(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pCorrecao.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(619, 43);
            this.barraMenu.TabIndex = 14;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Controls.Add(this.pCorrecao, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.95238F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.04762F));
            this.tlpCentral.Size = new System.Drawing.Size(619, 348);
            this.tlpCentral.TabIndex = 15;
            // 
            // pCorrecao
            // 
            this.pCorrecao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCorrecao.Controls.Add(this.label1);
            this.pCorrecao.Controls.Add(this.ds_correcao);
            this.pCorrecao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCorrecao.Location = new System.Drawing.Point(5, 5);
            this.pCorrecao.Name = "pCorrecao";
            this.pCorrecao.NM_ProcDeletar = "";
            this.pCorrecao.NM_ProcGravar = "";
            this.pCorrecao.Size = new System.Drawing.Size(609, 168);
            this.pCorrecao.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Correção";
            // 
            // ds_correcao
            // 
            this.ds_correcao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_correcao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_correcao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_correcao.Location = new System.Drawing.Point(6, 16);
            this.ds_correcao.MaxLength = 1000;
            this.ds_correcao.Multiline = true;
            this.ds_correcao.Name = "ds_correcao";
            this.ds_correcao.NM_Alias = "";
            this.ds_correcao.NM_Campo = "";
            this.ds_correcao.NM_CampoBusca = "";
            this.ds_correcao.NM_Param = "";
            this.ds_correcao.QTD_Zero = 0;
            this.ds_correcao.Size = new System.Drawing.Size(595, 143);
            this.ds_correcao.ST_AutoInc = false;
            this.ds_correcao.ST_DisableAuto = false;
            this.ds_correcao.ST_Float = false;
            this.ds_correcao.ST_Gravar = false;
            this.ds_correcao.ST_Int = false;
            this.ds_correcao.ST_LimpaCampo = true;
            this.ds_correcao.ST_NotNull = false;
            this.ds_correcao.ST_PrimaryKey = false;
            this.ds_correcao.TabIndex = 0;
            this.ds_correcao.TextOld = null;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.editDefault1);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 181);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(609, 162);
            this.panelDados1.TabIndex = 1;
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.Location = new System.Drawing.Point(6, 19);
            this.editDefault1.MaxLength = 1000;
            this.editDefault1.Multiline = true;
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(595, 136);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 3;
            this.editDefault1.Text = resources.GetString("editDefault1.Text");
            this.editDefault1.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Condição de uso";
            // 
            // TFCartaCorrecaoEletronica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 391);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCartaCorrecaoEletronica";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carta Correção Eletronica - CCe";
            this.Load += new System.EventHandler(this.TFCartaCorrecaoEletronica_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCartaCorrecaoEletronica_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pCorrecao.ResumeLayout(false);
            this.pCorrecao.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pCorrecao;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_correcao;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label2;
    }
}