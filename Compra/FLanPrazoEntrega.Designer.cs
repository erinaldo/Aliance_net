namespace Compra
{
    partial class TFLanPrazoEntrega
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
            System.Windows.Forms.Label cd_empresaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanPrazoEntrega));
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label3;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_endtransportadora = new Componentes.EditDefault(this.components);
            this.bb_endtransportadora = new System.Windows.Forms.Button();
            this.cd_endtransportadora = new Componentes.EditDefault(this.components);
            this.tp_frete = new Componentes.RadioGroup(this.components);
            this.pFrete = new Componentes.PanelDados(this.components);
            this.rbEmitente = new Componentes.RadioButtonDefault(this.components);
            this.rbDestinatario = new Componentes.RadioButtonDefault(this.components);
            this.nm_transportadora = new Componentes.EditDefault(this.components);
            this.bb_transportadora = new System.Windows.Forms.Button();
            this.cd_transportadora = new Componentes.EditDefault(this.components);
            this.prazo_entrega = new Componentes.EditFloat(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bsPrazoEntrega = new System.Windows.Forms.BindingSource(this.components);
            cd_empresaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.tp_frete.SuspendLayout();
            this.pFrete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prazo_entrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPrazoEntrega)).BeginInit();
            this.SuspendLayout();
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AccessibleDescription = null;
            cd_empresaLabel.AccessibleName = null;
            resources.ApplyResources(cd_empresaLabel, "cd_empresaLabel");
            cd_empresaLabel.Font = null;
            cd_empresaLabel.Name = "cd_empresaLabel";
            // 
            // label1
            // 
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.Font = null;
            label1.Name = "label1";
            // 
            // label2
            // 
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.Font = null;
            label2.Name = "label2";
            // 
            // label6
            // 
            label6.AccessibleDescription = null;
            label6.AccessibleName = null;
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label3
            // 
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Font = null;
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AccessibleDescription = null;
            this.BB_Gravar.AccessibleName = null;
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.BackgroundImage = null;
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AccessibleDescription = null;
            this.BB_Cancelar.AccessibleName = null;
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.BackgroundImage = null;
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.ds_endtransportadora);
            this.pDados.Controls.Add(this.bb_endtransportadora);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.cd_endtransportadora);
            this.pDados.Controls.Add(this.tp_frete);
            this.pDados.Controls.Add(this.nm_transportadora);
            this.pDados.Controls.Add(this.bb_transportadora);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.cd_transportadora);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.prazo_entrega);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Font = null;
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // ds_endtransportadora
            // 
            this.ds_endtransportadora.AccessibleDescription = null;
            this.ds_endtransportadora.AccessibleName = null;
            resources.ApplyResources(this.ds_endtransportadora, "ds_endtransportadora");
            this.ds_endtransportadora.BackColor = System.Drawing.SystemColors.Window;
            this.ds_endtransportadora.BackgroundImage = null;
            this.ds_endtransportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_endtransportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrazoEntrega, "Ds_endtransportadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_endtransportadora.Font = null;
            this.ds_endtransportadora.Name = "ds_endtransportadora";
            this.ds_endtransportadora.NM_Alias = "";
            this.ds_endtransportadora.NM_Campo = "ds_endereco";
            this.ds_endtransportadora.NM_CampoBusca = "ds_endereco";
            this.ds_endtransportadora.NM_Param = "@P_DS_PRODUTO";
            this.ds_endtransportadora.QTD_Zero = 0;
            this.ds_endtransportadora.ST_AutoInc = false;
            this.ds_endtransportadora.ST_DisableAuto = false;
            this.ds_endtransportadora.ST_Float = false;
            this.ds_endtransportadora.ST_Gravar = false;
            this.ds_endtransportadora.ST_Int = false;
            this.ds_endtransportadora.ST_LimpaCampo = true;
            this.ds_endtransportadora.ST_NotNull = false;
            this.ds_endtransportadora.ST_PrimaryKey = false;
            // 
            // bb_endtransportadora
            // 
            this.bb_endtransportadora.AccessibleDescription = null;
            this.bb_endtransportadora.AccessibleName = null;
            resources.ApplyResources(this.bb_endtransportadora, "bb_endtransportadora");
            this.bb_endtransportadora.BackColor = System.Drawing.SystemColors.Control;
            this.bb_endtransportadora.BackgroundImage = null;
            this.bb_endtransportadora.Font = null;
            this.bb_endtransportadora.Name = "bb_endtransportadora";
            this.bb_endtransportadora.UseVisualStyleBackColor = false;
            this.bb_endtransportadora.Click += new System.EventHandler(this.bb_endtransportadora_Click);
            // 
            // cd_endtransportadora
            // 
            this.cd_endtransportadora.AccessibleDescription = null;
            this.cd_endtransportadora.AccessibleName = null;
            resources.ApplyResources(this.cd_endtransportadora, "cd_endtransportadora");
            this.cd_endtransportadora.BackColor = System.Drawing.Color.White;
            this.cd_endtransportadora.BackgroundImage = null;
            this.cd_endtransportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_endtransportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrazoEntrega, "Cd_endtransportadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_endtransportadora.Font = null;
            this.cd_endtransportadora.Name = "cd_endtransportadora";
            this.cd_endtransportadora.NM_Alias = "";
            this.cd_endtransportadora.NM_Campo = "cd_endereco";
            this.cd_endtransportadora.NM_CampoBusca = "cd_endereco";
            this.cd_endtransportadora.NM_Param = "@P_CD_EMPRESA";
            this.cd_endtransportadora.QTD_Zero = 0;
            this.cd_endtransportadora.ST_AutoInc = false;
            this.cd_endtransportadora.ST_DisableAuto = false;
            this.cd_endtransportadora.ST_Float = false;
            this.cd_endtransportadora.ST_Gravar = true;
            this.cd_endtransportadora.ST_Int = true;
            this.cd_endtransportadora.ST_LimpaCampo = true;
            this.cd_endtransportadora.ST_NotNull = false;
            this.cd_endtransportadora.ST_PrimaryKey = false;
            this.cd_endtransportadora.Leave += new System.EventHandler(this.cd_endtransportadora_Leave);
            // 
            // tp_frete
            // 
            this.tp_frete.AccessibleDescription = null;
            this.tp_frete.AccessibleName = null;
            resources.ApplyResources(this.tp_frete, "tp_frete");
            this.tp_frete.BackgroundImage = null;
            this.tp_frete.Controls.Add(this.pFrete);
            this.tp_frete.DataBindings.Add(new System.Windows.Forms.Binding("NM_Valor", this.bsPrazoEntrega, "Tp_frete", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_frete.Font = null;
            this.tp_frete.Name = "tp_frete";
            this.tp_frete.NM_Alias = "";
            this.tp_frete.NM_Campo = "";
            this.tp_frete.NM_Param = "";
            this.tp_frete.NM_Valor = "1";
            this.tp_frete.ST_Gravar = true;
            this.tp_frete.ST_NotNull = false;
            this.tp_frete.TabStop = false;
            // 
            // pFrete
            // 
            this.pFrete.AccessibleDescription = null;
            this.pFrete.AccessibleName = null;
            resources.ApplyResources(this.pFrete, "pFrete");
            this.pFrete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pFrete.BackgroundImage = null;
            this.pFrete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pFrete.Controls.Add(this.rbEmitente);
            this.pFrete.Controls.Add(this.rbDestinatario);
            this.pFrete.Font = null;
            this.pFrete.Name = "pFrete";
            this.pFrete.NM_ProcDeletar = "";
            this.pFrete.NM_ProcGravar = "";
            // 
            // rbEmitente
            // 
            this.rbEmitente.AccessibleDescription = null;
            this.rbEmitente.AccessibleName = null;
            resources.ApplyResources(this.rbEmitente, "rbEmitente");
            this.rbEmitente.BackgroundImage = null;
            this.rbEmitente.Checked = true;
            this.rbEmitente.Font = null;
            this.rbEmitente.Name = "rbEmitente";
            this.rbEmitente.TabStop = true;
            this.rbEmitente.UseVisualStyleBackColor = true;
            this.rbEmitente.Valor = "1";
            // 
            // rbDestinatario
            // 
            this.rbDestinatario.AccessibleDescription = null;
            this.rbDestinatario.AccessibleName = null;
            resources.ApplyResources(this.rbDestinatario, "rbDestinatario");
            this.rbDestinatario.BackgroundImage = null;
            this.rbDestinatario.Font = null;
            this.rbDestinatario.Name = "rbDestinatario";
            this.rbDestinatario.UseVisualStyleBackColor = true;
            this.rbDestinatario.Valor = "";
            // 
            // nm_transportadora
            // 
            this.nm_transportadora.AccessibleDescription = null;
            this.nm_transportadora.AccessibleName = null;
            resources.ApplyResources(this.nm_transportadora, "nm_transportadora");
            this.nm_transportadora.BackColor = System.Drawing.SystemColors.Window;
            this.nm_transportadora.BackgroundImage = null;
            this.nm_transportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_transportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrazoEntrega, "Nm_transportadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_transportadora.Font = null;
            this.nm_transportadora.Name = "nm_transportadora";
            this.nm_transportadora.NM_Alias = "";
            this.nm_transportadora.NM_Campo = "nm_clifor";
            this.nm_transportadora.NM_CampoBusca = "nm_clifor";
            this.nm_transportadora.NM_Param = "@P_DS_PRODUTO";
            this.nm_transportadora.QTD_Zero = 0;
            this.nm_transportadora.ST_AutoInc = false;
            this.nm_transportadora.ST_DisableAuto = false;
            this.nm_transportadora.ST_Float = false;
            this.nm_transportadora.ST_Gravar = false;
            this.nm_transportadora.ST_Int = false;
            this.nm_transportadora.ST_LimpaCampo = true;
            this.nm_transportadora.ST_NotNull = false;
            this.nm_transportadora.ST_PrimaryKey = false;
            // 
            // bb_transportadora
            // 
            this.bb_transportadora.AccessibleDescription = null;
            this.bb_transportadora.AccessibleName = null;
            resources.ApplyResources(this.bb_transportadora, "bb_transportadora");
            this.bb_transportadora.BackColor = System.Drawing.SystemColors.Control;
            this.bb_transportadora.BackgroundImage = null;
            this.bb_transportadora.Font = null;
            this.bb_transportadora.Name = "bb_transportadora";
            this.bb_transportadora.UseVisualStyleBackColor = false;
            this.bb_transportadora.Click += new System.EventHandler(this.bb_transportadora_Click);
            // 
            // cd_transportadora
            // 
            this.cd_transportadora.AccessibleDescription = null;
            this.cd_transportadora.AccessibleName = null;
            resources.ApplyResources(this.cd_transportadora, "cd_transportadora");
            this.cd_transportadora.BackColor = System.Drawing.Color.White;
            this.cd_transportadora.BackgroundImage = null;
            this.cd_transportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_transportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrazoEntrega, "Cd_transportadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_transportadora.Font = null;
            this.cd_transportadora.Name = "cd_transportadora";
            this.cd_transportadora.NM_Alias = "";
            this.cd_transportadora.NM_Campo = "cd_clifor";
            this.cd_transportadora.NM_CampoBusca = "cd_clifor";
            this.cd_transportadora.NM_Param = "@P_CD_EMPRESA";
            this.cd_transportadora.QTD_Zero = 0;
            this.cd_transportadora.ST_AutoInc = false;
            this.cd_transportadora.ST_DisableAuto = false;
            this.cd_transportadora.ST_Float = false;
            this.cd_transportadora.ST_Gravar = true;
            this.cd_transportadora.ST_Int = true;
            this.cd_transportadora.ST_LimpaCampo = true;
            this.cd_transportadora.ST_NotNull = false;
            this.cd_transportadora.ST_PrimaryKey = false;
            this.cd_transportadora.Leave += new System.EventHandler(this.cd_transportadora_Leave);
            // 
            // prazo_entrega
            // 
            this.prazo_entrega.AccessibleDescription = null;
            this.prazo_entrega.AccessibleName = null;
            resources.ApplyResources(this.prazo_entrega, "prazo_entrega");
            this.prazo_entrega.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPrazoEntrega, "Prazo_entrega", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.prazo_entrega.Font = null;
            this.prazo_entrega.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.prazo_entrega.Name = "prazo_entrega";
            this.prazo_entrega.NM_Alias = "";
            this.prazo_entrega.NM_Campo = "";
            this.prazo_entrega.NM_Param = "";
            this.prazo_entrega.Operador = "";
            this.prazo_entrega.ST_AutoInc = false;
            this.prazo_entrega.ST_DisableAuto = false;
            this.prazo_entrega.ST_Gravar = true;
            this.prazo_entrega.ST_LimparCampo = true;
            this.prazo_entrega.ST_NotNull = false;
            this.prazo_entrega.ST_PrimaryKey = false;
            // 
            // nm_empresa
            // 
            this.nm_empresa.AccessibleDescription = null;
            this.nm_empresa.AccessibleName = null;
            resources.ApplyResources(this.nm_empresa, "nm_empresa");
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BackgroundImage = null;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrazoEntrega, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Font = null;
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_DS_PRODUTO";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            // 
            // bb_empresa
            // 
            this.bb_empresa.AccessibleDescription = null;
            this.bb_empresa.AccessibleName = null;
            resources.ApplyResources(this.bb_empresa, "bb_empresa");
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.BackgroundImage = null;
            this.bb_empresa.Font = null;
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.AccessibleDescription = null;
            this.cd_empresa.AccessibleName = null;
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BackgroundImage = null;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrazoEntrega, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Font = null;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // bsPrazoEntrega
            // 
            this.bsPrazoEntrega.DataSource = typeof(CamadaDados.Compra.Lancamento.TList_PrazoEntrega);
            // 
            // TFLanPrazoEntrega
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanPrazoEntrega";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanPrazoEntrega_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanPrazoEntrega_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tp_frete.ResumeLayout(false);
            this.pFrete.ResumeLayout(false);
            this.pFrete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prazo_entrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPrazoEntrega)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditFloat prazo_entrega;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.BindingSource bsPrazoEntrega;
        private Componentes.EditDefault nm_transportadora;
        private System.Windows.Forms.Button bb_transportadora;
        private Componentes.EditDefault cd_transportadora;
        private Componentes.RadioGroup tp_frete;
        private Componentes.PanelDados pFrete;
        private Componentes.RadioButtonDefault rbEmitente;
        private Componentes.RadioButtonDefault rbDestinatario;
        private Componentes.EditDefault ds_endtransportadora;
        private System.Windows.Forms.Button bb_endtransportadora;
        private Componentes.EditDefault cd_endtransportadora;
    }
}