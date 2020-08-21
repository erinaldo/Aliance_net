namespace Empreendimento.Cadastro
{
    partial class FCadRequisitoAtividade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadRequisitoAtividade));
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bsCadRequisitos = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.ds_atividade = new Componentes.EditDefault(this.components);
            this.cd_atividade = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadRequisitos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(659, 43);
            this.barraMenu.TabIndex = 13;
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
            this.bb_inutilizar.ToolTipText = "Gravar";
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
            this.panelDados1.Controls.Add(this.panelDados2);
            this.panelDados1.Controls.Add(this.editDefault1);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(659, 202);
            this.panelDados1.TabIndex = 14;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.richTextBox1);
            this.panelDados2.Controls.Add(this.label4);
            this.panelDados2.Controls.Add(this.ds_atividade);
            this.panelDados2.Controls.Add(this.cd_atividade);
            this.panelDados2.Controls.Add(this.label3);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(0, 0);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(659, 202);
            this.panelDados2.TabIndex = 15;
            // 
            // richTextBox1
            // 
            this.richTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadRequisitos, "ds_requisito", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.richTextBox1.Location = new System.Drawing.Point(5, 57);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(642, 134);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // bsCadRequisitos
            // 
            this.bsCadRequisitos.DataSource = typeof(CamadaDados.Empreendimento.Cadastro.TList_CadRequisitos);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Requisição";
            // 
            // ds_atividade
            // 
            this.ds_atividade.BackColor = System.Drawing.SystemColors.Window;
            this.ds_atividade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_atividade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_atividade.Enabled = false;
            this.ds_atividade.Location = new System.Drawing.Point(143, 6);
            this.ds_atividade.Name = "ds_atividade";
            this.ds_atividade.NM_Alias = "";
            this.ds_atividade.NM_Campo = "";
            this.ds_atividade.NM_CampoBusca = "";
            this.ds_atividade.NM_Param = "";
            this.ds_atividade.QTD_Zero = 0;
            this.ds_atividade.Size = new System.Drawing.Size(504, 20);
            this.ds_atividade.ST_AutoInc = false;
            this.ds_atividade.ST_DisableAuto = false;
            this.ds_atividade.ST_Float = false;
            this.ds_atividade.ST_Gravar = false;
            this.ds_atividade.ST_Int = false;
            this.ds_atividade.ST_LimpaCampo = true;
            this.ds_atividade.ST_NotNull = false;
            this.ds_atividade.ST_PrimaryKey = false;
            this.ds_atividade.TabIndex = 2;
            this.ds_atividade.TextOld = null;
            // 
            // cd_atividade
            // 
            this.cd_atividade.BackColor = System.Drawing.SystemColors.Window;
            this.cd_atividade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_atividade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_atividade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadRequisitos, "id_atividade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_atividade.Enabled = false;
            this.cd_atividade.Location = new System.Drawing.Point(88, 6);
            this.cd_atividade.Name = "cd_atividade";
            this.cd_atividade.NM_Alias = "";
            this.cd_atividade.NM_Campo = "";
            this.cd_atividade.NM_CampoBusca = "";
            this.cd_atividade.NM_Param = "";
            this.cd_atividade.QTD_Zero = 0;
            this.cd_atividade.Size = new System.Drawing.Size(49, 20);
            this.cd_atividade.ST_AutoInc = false;
            this.cd_atividade.ST_DisableAuto = false;
            this.cd_atividade.ST_Float = false;
            this.cd_atividade.ST_Gravar = false;
            this.cd_atividade.ST_Int = false;
            this.cd_atividade.ST_LimpaCampo = true;
            this.cd_atividade.ST_NotNull = false;
            this.cd_atividade.ST_PrimaryKey = false;
            this.cd_atividade.TabIndex = 1;
            this.cd_atividade.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cd. Atividade";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.Location = new System.Drawing.Point(88, 6);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(49, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 1;
            this.editDefault1.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cd. Atividade";
            // 
            // FCadRequisitoAtividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 245);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCadRequisitoAtividade";
            this.Text = "FCadRequisitoAtividade";
            this.Load += new System.EventHandler(this.FCadRequisitoAtividade_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCadRequisitoAtividade_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadRequisitos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.PanelDados panelDados2;
        private Componentes.EditDefault ds_atividade;
        private Componentes.EditDefault cd_atividade;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bsCadRequisitos;
    }
}