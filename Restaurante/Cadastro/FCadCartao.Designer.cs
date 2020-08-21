namespace Restaurante.Cadastro
{
    partial class FCadCartao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadCartao));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.checkBoxDefault1 = new Componentes.CheckBoxDefault(this.components);
            this.bsCartao = new System.Windows.Forms.BindingSource(this.components);
            this.nr_cartao = new Componentes.EditFloat(this.components);
            this.cartaorot = new Componentes.PanelDados(this.components);
            this.fim = new Componentes.EditFloat(this.components);
            this.ini = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_cartao)).BeginInit();
            this.cartaorot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(598, 43);
            this.barraMenu.TabIndex = 12;
            this.barraMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.barraMenu_ItemClicked);
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
            this.panelDados1.Controls.Add(this.checkBoxDefault1);
            this.panelDados1.Controls.Add(this.nr_cartao);
            this.panelDados1.Controls.Add(this.cartaorot);
            this.panelDados1.Controls.Add(this.editFloat1);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.button1);
            this.panelDados1.Controls.Add(this.cd_clifor);
            this.panelDados1.Controls.Add(this.nm_clifor);
            this.panelDados1.Controls.Add(this.bb_clifor);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(598, 60);
            this.panelDados1.TabIndex = 13;
            // 
            // checkBoxDefault1
            // 
            this.checkBoxDefault1.AutoSize = true;
            this.checkBoxDefault1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCartao, "st_menor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxDefault1.Location = new System.Drawing.Point(10, 34);
            this.checkBoxDefault1.Name = "checkBoxDefault1";
            this.checkBoxDefault1.NM_Alias = "";
            this.checkBoxDefault1.NM_Campo = "";
            this.checkBoxDefault1.NM_Param = "";
            this.checkBoxDefault1.Size = new System.Drawing.Size(86, 17);
            this.checkBoxDefault1.ST_Gravar = false;
            this.checkBoxDefault1.ST_LimparCampo = true;
            this.checkBoxDefault1.ST_NotNull = false;
            this.checkBoxDefault1.TabIndex = 164;
            this.checkBoxDefault1.Text = "Menor Idade";
            this.checkBoxDefault1.UseVisualStyleBackColor = true;
            this.checkBoxDefault1.Vl_False = "";
            this.checkBoxDefault1.Vl_True = "";
            // 
            // bsCartao
            // 
            this.bsCartao.DataSource = typeof(CamadaDados.Restaurante.TList_Cartao);
            // 
            // nr_cartao
            // 
            this.nr_cartao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCartao, "Nr_cartao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_cartao.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nr_cartao.Location = new System.Drawing.Point(339, 32);
            this.nr_cartao.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nr_cartao.Name = "nr_cartao";
            this.nr_cartao.NM_Alias = "";
            this.nr_cartao.NM_Campo = "";
            this.nr_cartao.NM_Param = "";
            this.nr_cartao.Operador = "";
            this.nr_cartao.Size = new System.Drawing.Size(99, 20);
            this.nr_cartao.ST_AutoInc = false;
            this.nr_cartao.ST_DisableAuto = false;
            this.nr_cartao.ST_Gravar = false;
            this.nr_cartao.ST_LimparCampo = true;
            this.nr_cartao.ST_NotNull = false;
            this.nr_cartao.ST_PrimaryKey = false;
            this.nr_cartao.TabIndex = 6;
            this.nr_cartao.ThousandsSeparator = true;
            this.nr_cartao.ValueChanged += new System.EventHandler(this.nr_cartao_ValueChanged);
            // 
            // cartaorot
            // 
            this.cartaorot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cartaorot.Controls.Add(this.fim);
            this.cartaorot.Controls.Add(this.ini);
            this.cartaorot.Controls.Add(this.label8);
            this.cartaorot.Controls.Add(this.label7);
            this.cartaorot.Controls.Add(this.label6);
            this.cartaorot.Location = new System.Drawing.Point(11, 61);
            this.cartaorot.Name = "cartaorot";
            this.cartaorot.NM_ProcDeletar = "";
            this.cartaorot.NM_ProcGravar = "";
            this.cartaorot.Size = new System.Drawing.Size(262, 48);
            this.cartaorot.TabIndex = 162;
            this.cartaorot.Visible = false;
            // 
            // fim
            // 
            this.fim.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.fim.Location = new System.Drawing.Point(161, 19);
            this.fim.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.fim.Name = "fim";
            this.fim.NM_Alias = "";
            this.fim.NM_Campo = "";
            this.fim.NM_Param = "";
            this.fim.Operador = "";
            this.fim.Size = new System.Drawing.Size(76, 20);
            this.fim.ST_AutoInc = false;
            this.fim.ST_DisableAuto = false;
            this.fim.ST_Gravar = false;
            this.fim.ST_LimparCampo = true;
            this.fim.ST_NotNull = false;
            this.fim.ST_PrimaryKey = false;
            this.fim.TabIndex = 169;
            this.fim.ThousandsSeparator = true;
            // 
            // ini
            // 
            this.ini.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ini.Location = new System.Drawing.Point(39, 18);
            this.ini.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ini.Name = "ini";
            this.ini.NM_Alias = "";
            this.ini.NM_Campo = "";
            this.ini.NM_Param = "";
            this.ini.Operador = "";
            this.ini.Size = new System.Drawing.Size(76, 20);
            this.ini.ST_AutoInc = false;
            this.ini.ST_DisableAuto = false;
            this.ini.ST_Gravar = false;
            this.ini.ST_LimparCampo = true;
            this.ini.ST_NotNull = false;
            this.ini.ST_PrimaryKey = false;
            this.ini.TabIndex = 168;
            this.ini.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 167;
            this.label8.Text = "Final";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 165;
            this.label7.Text = "Inicio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 163;
            this.label6.Text = "Faixa de cartão rotativo";
            // 
            // editFloat1
            // 
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCartao, "vl_limitecartao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat1.DecimalPlaces = 2;
            this.editFloat1.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat1.Location = new System.Drawing.Point(173, 33);
            this.editFloat1.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.Size = new System.Drawing.Size(100, 20);
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = false;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = false;
            this.editFloat1.ST_PrimaryKey = false;
            this.editFloat1.TabIndex = 5;
            this.editFloat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.editFloat1.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 161;
            this.label5.Text = "Limite Cartão";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(139, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 20);
            this.button1.TabIndex = 66;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Cd_Clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor.Location = new System.Drawing.Point(52, 6);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_CLIFOR";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(56, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = true;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 2;
            this.cd_clifor.TextOld = null;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Location = new System.Drawing.Point(172, 6);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_NM_CLIFOR";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(408, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 67;
            this.nm_clifor.TextOld = null;
            // 
            // bb_clifor
            // 
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(109, 6);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(28, 20);
            this.bb_clifor.TabIndex = 3;
            this.bb_clifor.UseVisualStyleBackColor = true;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "N° Cartão";
            // 
            // FCadCartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 103);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "FCadCartao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de cartão";
            this.Load += new System.EventHandler(this.FCadCartao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCadCartao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_cartao)).EndInit();
            this.cartaorot.ResumeLayout(false);
            this.cartaorot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private Componentes.EditDefault cd_clifor;
        private Componentes.EditDefault nm_clifor;
        private System.Windows.Forms.Button bb_clifor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bsCartao;
        private Componentes.EditFloat editFloat1;
        private System.Windows.Forms.Label label5;
        private Componentes.PanelDados cartaorot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Componentes.EditFloat nr_cartao;
        private Componentes.EditFloat fim;
        private Componentes.EditFloat ini;
        private Componentes.CheckBoxDefault checkBoxDefault1;
    }
}