namespace Empreendimento
{
    partial class FGerarDuplicata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FGerarDuplicata));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bsExecDespesa = new System.Windows.Forms.BindingSource(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dt_previni = new Componentes.EditData(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bsDespesa = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsExecDespesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDespesa)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(375, 43);
            this.barraMenu.TabIndex = 15;
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.cd_empresa);
            this.panelDados1.Controls.Add(this.bb_empresa);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.richTextBox1);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.editFloat1);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.dt_previni);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(375, 160);
            this.panelDados1.TabIndex = 16;
            this.panelDados1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDados1_Paint);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsExecDespesa, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(12, 22);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_DS_PDV";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(45, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // bsExecDespesa
            // 
            this.bsExecDespesa.DataSource = typeof(CamadaDados.Empreendimento.TList_ExecDespesas);
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(58, 22);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Empresa";
            // 
            // richTextBox1
            // 
            this.richTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsExecDespesa, "obs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.richTextBox1.Location = new System.Drawing.Point(7, 65);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(358, 92);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Observação";
            // 
            // editFloat1
            // 
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsExecDespesa, "vl_executado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat1.DecimalPlaces = 2;
            this.editFloat1.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat1.Location = new System.Drawing.Point(168, 22);
            this.editFloat1.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.Size = new System.Drawing.Size(124, 20);
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = false;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = false;
            this.editFloat1.ST_PrimaryKey = false;
            this.editFloat1.TabIndex = 3;
            this.editFloat1.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Valor ";
            // 
            // dt_previni
            // 
            this.dt_previni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_previni.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsExecDespesa, "Dt_execucao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_previni.Location = new System.Drawing.Point(89, 22);
            this.dt_previni.Mask = "00/00/0000";
            this.dt_previni.Name = "dt_previni";
            this.dt_previni.NM_Alias = "";
            this.dt_previni.NM_Campo = "dt_inicio";
            this.dt_previni.NM_CampoBusca = "dt_inicio";
            this.dt_previni.NM_Param = "@P_DT_INICIO";
            this.dt_previni.Operador = "";
            this.dt_previni.Size = new System.Drawing.Size(73, 20);
            this.dt_previni.ST_Gravar = true;
            this.dt_previni.ST_LimpaCampo = true;
            this.dt_previni.ST_NotNull = true;
            this.dt_previni.ST_PrimaryKey = false;
            this.dt_previni.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data";
            // 
            // bsDespesa
            // 
            this.bsDespesa.DataSource = typeof(CamadaDados.Empreendimento.TList_Despesas);
            // 
            // FGerarDuplicata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 203);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.Name = "FGerarDuplicata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Executar Despesa";
            this.Load += new System.EventHandler(this.FGerarDuplicata_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsExecDespesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDespesa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditData dt_previni;
        private Componentes.EditFloat editFloat1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bsExecDespesa;
        private System.Windows.Forms.BindingSource bsDespesa;
    }
}