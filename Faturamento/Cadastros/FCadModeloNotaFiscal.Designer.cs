namespace Faturamento.Cadastros
{
    partial class TFCadModeloNotaFiscal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadModeloNotaFiscal));
            this.bsModeloNF = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.ds_modelo = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cd_modelo = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsModeloNF)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsModeloNF
            // 
            this.bsModeloNF.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CadModeloNF);
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(612, 43);
            this.barraMenu.TabIndex = 10;
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.ds_modelo);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.cd_modelo);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(612, 75);
            this.panelDados1.TabIndex = 11;
            // 
            // ds_modelo
            // 
            this.ds_modelo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_modelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_modelo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsModeloNF, "DS_Modelo", true));
            this.ds_modelo.Location = new System.Drawing.Point(69, 36);
            this.ds_modelo.Name = "ds_modelo";
            this.ds_modelo.NM_Alias = "";
            this.ds_modelo.NM_Campo = "";
            this.ds_modelo.NM_CampoBusca = "";
            this.ds_modelo.NM_Param = "";
            this.ds_modelo.QTD_Zero = 0;
            this.ds_modelo.Size = new System.Drawing.Size(413, 20);
            this.ds_modelo.ST_AutoInc = false;
            this.ds_modelo.ST_DisableAuto = false;
            this.ds_modelo.ST_Float = false;
            this.ds_modelo.ST_Gravar = false;
            this.ds_modelo.ST_Int = false;
            this.ds_modelo.ST_LimpaCampo = true;
            this.ds_modelo.ST_NotNull = false;
            this.ds_modelo.ST_PrimaryKey = false;
            this.ds_modelo.TabIndex = 3;
            this.ds_modelo.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Modelo:";
            // 
            // cd_modelo
            // 
            this.cd_modelo.BackColor = System.Drawing.SystemColors.Window;
            this.cd_modelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_modelo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsModeloNF, "CD_Modelo", true));
            this.cd_modelo.Location = new System.Drawing.Point(69, 7);
            this.cd_modelo.Name = "cd_modelo";
            this.cd_modelo.NM_Alias = "";
            this.cd_modelo.NM_Campo = "";
            this.cd_modelo.NM_CampoBusca = "";
            this.cd_modelo.NM_Param = "";
            this.cd_modelo.QTD_Zero = 0;
            this.cd_modelo.Size = new System.Drawing.Size(100, 20);
            this.cd_modelo.ST_AutoInc = false;
            this.cd_modelo.ST_DisableAuto = false;
            this.cd_modelo.ST_Float = false;
            this.cd_modelo.ST_Gravar = false;
            this.cd_modelo.ST_Int = false;
            this.cd_modelo.ST_LimpaCampo = true;
            this.cd_modelo.ST_NotNull = false;
            this.cd_modelo.ST_PrimaryKey = false;
            this.cd_modelo.TabIndex = 1;
            this.cd_modelo.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // TFCadModeloNotaFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 118);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.Name = "TFCadModeloNotaFiscal";
            this.Text = "Cadastro de Modelo de NotaFiscal";
            this.Load += new System.EventHandler(this.FCadModeloNotaFiscal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCadModeloNotaFiscal_KeyDown_1);
            ((System.ComponentModel.ISupportInitialize)(this.bsModeloNF)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsModeloNF;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_modelo;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_modelo;
    }
}