namespace Faturamento.Cadastros
{
    partial class FEtapa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEtapa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.cbFechamentio = new Componentes.CheckBoxDefault(this.components);
            this.dS_Etapa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bsEtapa = new System.Windows.Forms.BindingSource(this.components);
            this.cbLiberarExped = new Componentes.CheckBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEtapa)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(494, 43);
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.cbLiberarExped);
            this.panelDados1.Controls.Add(this.cbFechamentio);
            this.panelDados1.Controls.Add(this.dS_Etapa);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(494, 56);
            this.panelDados1.TabIndex = 12;
            // 
            // cbFechamentio
            // 
            this.cbFechamentio.AutoSize = true;
            this.cbFechamentio.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsEtapa, "ST_FecharPedBool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbFechamentio.Location = new System.Drawing.Point(12, 30);
            this.cbFechamentio.Name = "cbFechamentio";
            this.cbFechamentio.NM_Alias = "";
            this.cbFechamentio.NM_Campo = "";
            this.cbFechamentio.NM_Param = "";
            this.cbFechamentio.Size = new System.Drawing.Size(85, 17);
            this.cbFechamentio.ST_Gravar = false;
            this.cbFechamentio.ST_LimparCampo = true;
            this.cbFechamentio.ST_NotNull = false;
            this.cbFechamentio.TabIndex = 3;
            this.cbFechamentio.Text = "Fechamento";
            this.cbFechamentio.UseVisualStyleBackColor = true;
            this.cbFechamentio.Vl_False = "";
            this.cbFechamentio.Vl_True = "";
            // 
            // dS_Etapa
            // 
            this.dS_Etapa.BackColor = System.Drawing.SystemColors.Window;
            this.dS_Etapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dS_Etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dS_Etapa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEtapa, "DS_Etapa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dS_Etapa.Location = new System.Drawing.Point(56, 4);
            this.dS_Etapa.Name = "dS_Etapa";
            this.dS_Etapa.NM_Alias = "";
            this.dS_Etapa.NM_Campo = "";
            this.dS_Etapa.NM_CampoBusca = "";
            this.dS_Etapa.NM_Param = "";
            this.dS_Etapa.QTD_Zero = 0;
            this.dS_Etapa.Size = new System.Drawing.Size(426, 20);
            this.dS_Etapa.ST_AutoInc = false;
            this.dS_Etapa.ST_DisableAuto = false;
            this.dS_Etapa.ST_Float = false;
            this.dS_Etapa.ST_Gravar = false;
            this.dS_Etapa.ST_Int = false;
            this.dS_Etapa.ST_LimpaCampo = true;
            this.dS_Etapa.ST_NotNull = false;
            this.dS_Etapa.ST_PrimaryKey = false;
            this.dS_Etapa.TabIndex = 1;
            this.dS_Etapa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Etapa:";
            // 
            // bsEtapa
            // 
            this.bsEtapa.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CadEtapa);
            // 
            // cbLiberarExped
            // 
            this.cbLiberarExped.AutoSize = true;
            this.cbLiberarExped.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsEtapa, "ST_LiberarExpedBool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbLiberarExped.Location = new System.Drawing.Point(119, 30);
            this.cbLiberarExped.Name = "cbLiberarExped";
            this.cbLiberarExped.NM_Alias = "";
            this.cbLiberarExped.NM_Campo = "";
            this.cbLiberarExped.NM_Param = "";
            this.cbLiberarExped.Size = new System.Drawing.Size(111, 17);
            this.cbLiberarExped.ST_Gravar = false;
            this.cbLiberarExped.ST_LimparCampo = true;
            this.cbLiberarExped.ST_NotNull = false;
            this.cbLiberarExped.TabIndex = 4;
            this.cbLiberarExped.Text = "Liberar Expedição";
            this.cbLiberarExped.UseVisualStyleBackColor = true;
            this.cbLiberarExped.Vl_False = "";
            this.cbLiberarExped.Vl_True = "";
            // 
            // FEtapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 99);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.Name = "FEtapa";
            this.Text = "FEtapa";
            this.Load += new System.EventHandler(this.FEtapa_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEtapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault dS_Etapa;
        private System.Windows.Forms.Label label1;
        private Componentes.CheckBoxDefault cbFechamentio;
        private System.Windows.Forms.BindingSource bsEtapa;
        private Componentes.CheckBoxDefault cbLiberarExped;
    }
}