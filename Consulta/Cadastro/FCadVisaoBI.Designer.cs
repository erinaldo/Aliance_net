namespace Consulta.Cadastro
{
    partial class FCadVisaoBI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadVisaoBI));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.comboclasse = new Componentes.ComboBoxDefault(this.components);
            this.bsVisaoBI = new System.Windows.Forms.BindingSource(this.components);
            this.id_visao = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsVisaoBI)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(566, 43);
            this.barraMenu.TabIndex = 12;
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
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.comboclasse);
            this.panelDados1.Controls.Add(this.id_visao);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(566, 46);
            this.panelDados1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "NM. Classe";
            // 
            // comboclasse
            // 
            this.comboclasse.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bsVisaoBI, "Tipo_classe", true));
            this.comboclasse.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsVisaoBI, "Tp_classe", true));
            this.comboclasse.FormattingEnabled = true;
            this.comboclasse.Location = new System.Drawing.Point(247, 8);
            this.comboclasse.Name = "comboclasse";
            this.comboclasse.NM_Alias = "";
            this.comboclasse.NM_Campo = "";
            this.comboclasse.NM_Param = "";
            this.comboclasse.Size = new System.Drawing.Size(287, 21);
            this.comboclasse.ST_Gravar = false;
            this.comboclasse.ST_LimparCampo = true;
            this.comboclasse.ST_NotNull = true;
            this.comboclasse.TabIndex = 4;
            // 
            // bsVisaoBI
            // 
            this.bsVisaoBI.DataSource = typeof(CamadaDados.Consulta.Cadastro.TList_VisaoBI);
            // 
            // id_visao
            // 
            this.id_visao.BackColor = System.Drawing.SystemColors.Window;
            this.id_visao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_visao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_visao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVisaoBI, "id_Visao", true));
            this.id_visao.Enabled = false;
            this.id_visao.Location = new System.Drawing.Point(66, 8);
            this.id_visao.Name = "id_visao";
            this.id_visao.NM_Alias = "";
            this.id_visao.NM_Campo = "";
            this.id_visao.NM_CampoBusca = "";
            this.id_visao.NM_Param = "";
            this.id_visao.QTD_Zero = 0;
            this.id_visao.Size = new System.Drawing.Size(100, 20);
            this.id_visao.ST_AutoInc = false;
            this.id_visao.ST_DisableAuto = false;
            this.id_visao.ST_Float = false;
            this.id_visao.ST_Gravar = false;
            this.id_visao.ST_Int = false;
            this.id_visao.ST_LimpaCampo = true;
            this.id_visao.ST_NotNull = true;
            this.id_visao.ST_PrimaryKey = false;
            this.id_visao.TabIndex = 1;
            this.id_visao.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id.Visao";
            // 
            // FCadVisaoBI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 89);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.Name = "FCadVisaoBI";
            this.Text = "FCadVisaoBI";
            this.Load += new System.EventHandler(this.FCadVisaoBI_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsVisaoBI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault comboclasse;
        private Componentes.EditDefault id_visao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsVisaoBI;
    }
}