namespace Parametros.Diversos
{
    partial class TFSociosEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFSociosEmpresa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.st_responsavel = new Componentes.CheckBoxDefault(this.components);
            this.bsSocios = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pc_participacao = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dt_saida = new Componentes.EditData(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dt_inclusao = new Componentes.EditData(this.components);
            this.ds_funcao = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bb_clifor = new System.Windows.Forms.Button();
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.lbl = new System.Windows.Forms.Label();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSocios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_participacao)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(599, 43);
            this.barraMenu.TabIndex = 9;
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.st_responsavel);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.pc_participacao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.dt_saida);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.dt_inclusao);
            this.pDados.Controls.Add(this.ds_funcao);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.bb_clifor);
            this.pDados.Controls.Add(this.nm_clifor);
            this.pDados.Controls.Add(this.lbl);
            this.pDados.Controls.Add(this.cd_clifor);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(599, 82);
            this.pDados.TabIndex = 10;
            // 
            // st_responsavel
            // 
            this.st_responsavel.AutoSize = true;
            this.st_responsavel.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsSocios, "St_responsavelbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_responsavel.Location = new System.Drawing.Point(460, 58);
            this.st_responsavel.Name = "st_responsavel";
            this.st_responsavel.NM_Alias = "";
            this.st_responsavel.NM_Campo = "";
            this.st_responsavel.NM_Param = "";
            this.st_responsavel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.st_responsavel.Size = new System.Drawing.Size(132, 17);
            this.st_responsavel.ST_Gravar = false;
            this.st_responsavel.ST_LimparCampo = true;
            this.st_responsavel.ST_NotNull = false;
            this.st_responsavel.TabIndex = 6;
            this.st_responsavel.Text = "Responsavel Empresa";
            this.st_responsavel.UseVisualStyleBackColor = true;
            this.st_responsavel.Vl_False = "";
            this.st_responsavel.Vl_True = "";
            // 
            // bsSocios
            // 
            this.bsSocios.DataSource = typeof(CamadaDados.Diversos.TList_SociosEmpresa);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(305, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "% Participação:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pc_participacao
            // 
            this.pc_participacao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsSocios, "Pc_participacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_participacao.DecimalPlaces = 2;
            this.pc_participacao.Location = new System.Drawing.Point(391, 56);
            this.pc_participacao.Name = "pc_participacao";
            this.pc_participacao.NM_Alias = "";
            this.pc_participacao.NM_Campo = "";
            this.pc_participacao.NM_Param = "";
            this.pc_participacao.Operador = "";
            this.pc_participacao.Size = new System.Drawing.Size(64, 20);
            this.pc_participacao.ST_AutoInc = false;
            this.pc_participacao.ST_DisableAuto = false;
            this.pc_participacao.ST_Gravar = false;
            this.pc_participacao.ST_LimparCampo = true;
            this.pc_participacao.ST_NotNull = false;
            this.pc_participacao.ST_PrimaryKey = false;
            this.pc_participacao.TabIndex = 5;
            this.pc_participacao.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(164, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Dt. Saida:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_saida
            // 
            this.dt_saida.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSocios, "Dt_saidastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_saida.Location = new System.Drawing.Point(224, 55);
            this.dt_saida.Mask = "00/00/0000";
            this.dt_saida.Name = "dt_saida";
            this.dt_saida.NM_Alias = "";
            this.dt_saida.NM_Campo = "";
            this.dt_saida.NM_CampoBusca = "";
            this.dt_saida.NM_Param = "";
            this.dt_saida.Operador = "";
            this.dt_saida.Size = new System.Drawing.Size(75, 20);
            this.dt_saida.ST_Gravar = false;
            this.dt_saida.ST_LimpaCampo = true;
            this.dt_saida.ST_NotNull = false;
            this.dt_saida.ST_PrimaryKey = false;
            this.dt_saida.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Dt. Inclusão:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_inclusao
            // 
            this.dt_inclusao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSocios, "Dt_inclusaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_inclusao.Location = new System.Drawing.Point(83, 55);
            this.dt_inclusao.Mask = "00/00/0000";
            this.dt_inclusao.Name = "dt_inclusao";
            this.dt_inclusao.NM_Alias = "";
            this.dt_inclusao.NM_Campo = "";
            this.dt_inclusao.NM_CampoBusca = "";
            this.dt_inclusao.NM_Param = "";
            this.dt_inclusao.Operador = "";
            this.dt_inclusao.Size = new System.Drawing.Size(75, 20);
            this.dt_inclusao.ST_Gravar = false;
            this.dt_inclusao.ST_LimpaCampo = true;
            this.dt_inclusao.ST_NotNull = false;
            this.dt_inclusao.ST_PrimaryKey = false;
            this.dt_inclusao.TabIndex = 3;
            // 
            // ds_funcao
            // 
            this.ds_funcao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_funcao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_funcao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSocios, "Ds_funcao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_funcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_funcao.Location = new System.Drawing.Point(83, 29);
            this.ds_funcao.Name = "ds_funcao";
            this.ds_funcao.NM_Alias = "";
            this.ds_funcao.NM_Campo = "cd_empresa";
            this.ds_funcao.NM_CampoBusca = "cd_empresa";
            this.ds_funcao.NM_Param = "@P_CD_EMPRESA";
            this.ds_funcao.QTD_Zero = 0;
            this.ds_funcao.Size = new System.Drawing.Size(509, 20);
            this.ds_funcao.ST_AutoInc = false;
            this.ds_funcao.ST_DisableAuto = false;
            this.ds_funcao.ST_Float = false;
            this.ds_funcao.ST_Gravar = true;
            this.ds_funcao.ST_Int = false;
            this.ds_funcao.ST_LimpaCampo = true;
            this.ds_funcao.ST_NotNull = false;
            this.ds_funcao.ST_PrimaryKey = false;
            this.ds_funcao.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "Função:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_clifor
            // 
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(161, 3);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(28, 19);
            this.bb_clifor.TabIndex = 1;
            this.bb_clifor.UseVisualStyleBackColor = true;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSocios, "Nm_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Location = new System.Drawing.Point(195, 3);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_DS_PDV";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(397, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 90;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl.Location = new System.Drawing.Point(40, 6);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(37, 13);
            this.lbl.TabIndex = 89;
            this.lbl.Text = "Socio:";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSocios, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_clifor.Location = new System.Drawing.Point(83, 3);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_EMPRESA";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(75, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = true;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = true;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 0;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // TFSociosEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 125);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFSociosEmpresa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quadro Socios Empresa";
            this.Load += new System.EventHandler(this.TFSociosEmpresa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFSociosEmpresa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSocios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_participacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.CheckBoxDefault st_responsavel;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat pc_participacao;
        private System.Windows.Forms.Label label3;
        private Componentes.EditData dt_saida;
        private System.Windows.Forms.Label label2;
        private Componentes.EditData dt_inclusao;
        private Componentes.EditDefault ds_funcao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault nm_clifor;
        private System.Windows.Forms.Label lbl;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.BindingSource bsSocios;
    }
}