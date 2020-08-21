namespace Financeiro
{
    partial class TFAddCResultado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAddCResultado));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ST_Sintetico = new Componentes.CheckBoxDefault(this.components);
            this.bsCentroResult = new System.Windows.Forms.BindingSource(this.components);
            this.st_deducao = new Componentes.CheckBoxDefault(this.components);
            this.tp_registro = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_centroresult_pai = new Componentes.EditDefault(this.components);
            this.bb_grupocf = new System.Windows.Forms.Button();
            this.LB_DS_GrupoCF = new System.Windows.Forms.Label();
            this.LB_CD_GrupoCF_Pai = new System.Windows.Forms.Label();
            this.ds_centroresultado = new Componentes.EditDefault(this.components);
            this.cd_centroresult_pai = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCentroResult)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(493, 43);
            this.barraMenu.TabIndex = 9;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(102, 40);
            this.BB_Gravar.Text = " (F4)\r\n Confirmar";
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
            // pDados
            // 
            this.pDados.Controls.Add(this.ST_Sintetico);
            this.pDados.Controls.Add(this.st_deducao);
            this.pDados.Controls.Add(this.tp_registro);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_centroresult_pai);
            this.pDados.Controls.Add(this.bb_grupocf);
            this.pDados.Controls.Add(this.LB_DS_GrupoCF);
            this.pDados.Controls.Add(this.LB_CD_GrupoCF_Pai);
            this.pDados.Controls.Add(this.ds_centroresultado);
            this.pDados.Controls.Add(this.cd_centroresult_pai);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(493, 118);
            this.pDados.TabIndex = 10;
            // 
            // ST_Sintetico
            // 
            this.ST_Sintetico.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCentroResult, "St_sinteticobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Sintetico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ST_Sintetico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ST_Sintetico.Location = new System.Drawing.Point(15, 88);
            this.ST_Sintetico.Name = "ST_Sintetico";
            this.ST_Sintetico.NM_Alias = "a";
            this.ST_Sintetico.NM_Campo = "ST_Sintetico";
            this.ST_Sintetico.NM_Param = "@P_ST_SINTETICO";
            this.ST_Sintetico.Size = new System.Drawing.Size(76, 16);
            this.ST_Sintetico.ST_Gravar = true;
            this.ST_Sintetico.ST_LimparCampo = true;
            this.ST_Sintetico.ST_NotNull = false;
            this.ST_Sintetico.TabIndex = 3;
            this.ST_Sintetico.Text = "Sintético";
            this.ST_Sintetico.UseVisualStyleBackColor = true;
            this.ST_Sintetico.Vl_False = "N";
            this.ST_Sintetico.Vl_True = "S";
            // 
            // bsCentroResult
            // 
            this.bsCentroResult.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CentroResultado);
            // 
            // st_deducao
            // 
            this.st_deducao.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCentroResult, "St_deducaobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_deducao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.st_deducao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_deducao.Location = new System.Drawing.Point(113, 89);
            this.st_deducao.Name = "st_deducao";
            this.st_deducao.NM_Alias = "a";
            this.st_deducao.NM_Campo = "ST_Sintetico";
            this.st_deducao.NM_Param = "@P_ST_SINTETICO";
            this.st_deducao.Size = new System.Drawing.Size(114, 17);
            this.st_deducao.ST_Gravar = true;
            this.st_deducao.ST_LimparCampo = true;
            this.st_deducao.ST_NotNull = false;
            this.st_deducao.TabIndex = 4;
            this.st_deducao.Text = "Conta Dedução";
            this.st_deducao.UseVisualStyleBackColor = true;
            this.st_deducao.Vl_False = "N";
            this.st_deducao.Vl_True = "S";
            // 
            // tp_registro
            // 
            this.tp_registro.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCentroResult, "Tp_registro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_registro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_registro.FormattingEnabled = true;
            this.tp_registro.Location = new System.Drawing.Point(301, 86);
            this.tp_registro.Name = "tp_registro";
            this.tp_registro.NM_Alias = "";
            this.tp_registro.NM_Campo = "";
            this.tp_registro.NM_Param = "";
            this.tp_registro.Size = new System.Drawing.Size(184, 21);
            this.tp_registro.ST_Gravar = true;
            this.tp_registro.ST_LimparCampo = true;
            this.tp_registro.ST_NotNull = false;
            this.tp_registro.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(233, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 235;
            this.label2.Text = "Movimento:";
            // 
            // ds_centroresult_pai
            // 
            this.ds_centroresult_pai.BackColor = System.Drawing.SystemColors.Window;
            this.ds_centroresult_pai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_centroresult_pai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_centroresult_pai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCentroResult, "Ds_centroresult_pai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_centroresult_pai.Enabled = false;
            this.ds_centroresult_pai.Location = new System.Drawing.Point(113, 60);
            this.ds_centroresult_pai.Name = "ds_centroresult_pai";
            this.ds_centroresult_pai.NM_Alias = "";
            this.ds_centroresult_pai.NM_Campo = "ds_centroresult_pai";
            this.ds_centroresult_pai.NM_CampoBusca = "ds_centroresultado";
            this.ds_centroresult_pai.NM_Param = "@P_DS_GRUPOCF_PAI";
            this.ds_centroresult_pai.QTD_Zero = 0;
            this.ds_centroresult_pai.Size = new System.Drawing.Size(372, 20);
            this.ds_centroresult_pai.ST_AutoInc = false;
            this.ds_centroresult_pai.ST_DisableAuto = false;
            this.ds_centroresult_pai.ST_Float = false;
            this.ds_centroresult_pai.ST_Gravar = false;
            this.ds_centroresult_pai.ST_Int = false;
            this.ds_centroresult_pai.ST_LimpaCampo = true;
            this.ds_centroresult_pai.ST_NotNull = false;
            this.ds_centroresult_pai.ST_PrimaryKey = false;
            this.ds_centroresult_pai.TabIndex = 234;
            this.ds_centroresult_pai.TextOld = null;
            // 
            // bb_grupocf
            // 
            this.bb_grupocf.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_grupocf.Image = ((System.Drawing.Image)(resources.GetObject("bb_grupocf.Image")));
            this.bb_grupocf.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_grupocf.Location = new System.Drawing.Point(79, 60);
            this.bb_grupocf.Name = "bb_grupocf";
            this.bb_grupocf.Size = new System.Drawing.Size(30, 20);
            this.bb_grupocf.TabIndex = 2;
            this.bb_grupocf.UseVisualStyleBackColor = true;
            this.bb_grupocf.Click += new System.EventHandler(this.bb_grupocf_Click);
            // 
            // LB_DS_GrupoCF
            // 
            this.LB_DS_GrupoCF.AutoSize = true;
            this.LB_DS_GrupoCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_DS_GrupoCF.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_GrupoCF.Location = new System.Drawing.Point(12, 5);
            this.LB_DS_GrupoCF.Name = "LB_DS_GrupoCF";
            this.LB_DS_GrupoCF.Size = new System.Drawing.Size(89, 13);
            this.LB_DS_GrupoCF.TabIndex = 232;
            this.LB_DS_GrupoCF.Text = "Centro Resultado";
            // 
            // LB_CD_GrupoCF_Pai
            // 
            this.LB_CD_GrupoCF_Pai.AutoSize = true;
            this.LB_CD_GrupoCF_Pai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_GrupoCF_Pai.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_GrupoCF_Pai.Location = new System.Drawing.Point(12, 44);
            this.LB_CD_GrupoCF_Pai.Name = "LB_CD_GrupoCF_Pai";
            this.LB_CD_GrupoCF_Pai.Size = new System.Drawing.Size(53, 13);
            this.LB_CD_GrupoCF_Pai.TabIndex = 233;
            this.LB_CD_GrupoCF_Pai.Text = "Conta Pai";
            // 
            // ds_centroresultado
            // 
            this.ds_centroresultado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_centroresultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_centroresultado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_centroresultado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCentroResult, "Ds_centroresultado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_centroresultado.Location = new System.Drawing.Point(15, 21);
            this.ds_centroresultado.Name = "ds_centroresultado";
            this.ds_centroresultado.NM_Alias = "a";
            this.ds_centroresultado.NM_Campo = "ds_centroresultado";
            this.ds_centroresultado.NM_CampoBusca = "ds_centroresultado";
            this.ds_centroresultado.NM_Param = "@P_DS_GRUPOCF";
            this.ds_centroresultado.QTD_Zero = 0;
            this.ds_centroresultado.Size = new System.Drawing.Size(470, 20);
            this.ds_centroresultado.ST_AutoInc = false;
            this.ds_centroresultado.ST_DisableAuto = false;
            this.ds_centroresultado.ST_Float = false;
            this.ds_centroresultado.ST_Gravar = true;
            this.ds_centroresultado.ST_Int = false;
            this.ds_centroresultado.ST_LimpaCampo = true;
            this.ds_centroresultado.ST_NotNull = true;
            this.ds_centroresultado.ST_PrimaryKey = false;
            this.ds_centroresultado.TabIndex = 0;
            this.ds_centroresultado.TextOld = null;
            // 
            // cd_centroresult_pai
            // 
            this.cd_centroresult_pai.BackColor = System.Drawing.SystemColors.Window;
            this.cd_centroresult_pai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_centroresult_pai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_centroresult_pai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCentroResult, "Cd_centroresult_pai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_centroresult_pai.Location = new System.Drawing.Point(15, 60);
            this.cd_centroresult_pai.Name = "cd_centroresult_pai";
            this.cd_centroresult_pai.NM_Alias = "a";
            this.cd_centroresult_pai.NM_Campo = "cd_centroresult_pai";
            this.cd_centroresult_pai.NM_CampoBusca = "cd_centroresult";
            this.cd_centroresult_pai.NM_Param = "@P_CD_GRUPOCF_PAI";
            this.cd_centroresult_pai.QTD_Zero = 0;
            this.cd_centroresult_pai.Size = new System.Drawing.Size(63, 20);
            this.cd_centroresult_pai.ST_AutoInc = false;
            this.cd_centroresult_pai.ST_DisableAuto = false;
            this.cd_centroresult_pai.ST_Float = false;
            this.cd_centroresult_pai.ST_Gravar = true;
            this.cd_centroresult_pai.ST_Int = false;
            this.cd_centroresult_pai.ST_LimpaCampo = true;
            this.cd_centroresult_pai.ST_NotNull = false;
            this.cd_centroresult_pai.ST_PrimaryKey = false;
            this.cd_centroresult_pai.TabIndex = 1;
            this.cd_centroresult_pai.TextOld = null;
            this.cd_centroresult_pai.Leave += new System.EventHandler(this.cd_centroresult_pai_Leave);
            // 
            // TFAddCResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 161);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAddCResultado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Centro Resultado";
            this.Load += new System.EventHandler(this.TFAddCResultado_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAddCResultado_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCentroResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsCentroResult;
        private Componentes.CheckBoxDefault ST_Sintetico;
        private Componentes.CheckBoxDefault st_deducao;
        private Componentes.ComboBoxDefault tp_registro;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_centroresult_pai;
        public System.Windows.Forms.Button bb_grupocf;
        private System.Windows.Forms.Label LB_DS_GrupoCF;
        private System.Windows.Forms.Label LB_CD_GrupoCF_Pai;
        private Componentes.EditDefault ds_centroresultado;
        private Componentes.EditDefault cd_centroresult_pai;
    }
}