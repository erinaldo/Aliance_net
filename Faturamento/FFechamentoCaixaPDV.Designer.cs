namespace Faturamento
{
    partial class TFFechamentoCaixaPDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFFechamentoCaixaPDV));
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.cd_portador = new Componentes.EditDefault(this.components);
            this.ds_portador = new Componentes.EditDefault(this.components);
            this.bb_portador = new System.Windows.Forms.Button();
            this.vl_fechamento = new Componentes.EditFloat(this.components);
            this.vl_auditado = new Componentes.EditFloat(this.components);
            this.bsFechamento = new System.Windows.Forms.BindingSource(this.components);
            label13 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_fechamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_auditado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFechamento)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(508, 43);
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.vl_auditado);
            this.pDados.Controls.Add(this.vl_fechamento);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.cd_portador);
            this.pDados.Controls.Add(this.ds_portador);
            this.pDados.Controls.Add(label13);
            this.pDados.Controls.Add(this.bb_portador);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(508, 80);
            this.pDados.TabIndex = 11;
            // 
            // cd_portador
            // 
            this.cd_portador.BackColor = System.Drawing.Color.White;
            this.cd_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFechamento, "Cd_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_portador.Location = new System.Drawing.Point(108, 3);
            this.cd_portador.MaxLength = 4;
            this.cd_portador.Name = "cd_portador";
            this.cd_portador.NM_Alias = "";
            this.cd_portador.NM_Campo = "cd_portador";
            this.cd_portador.NM_CampoBusca = "cd_portador";
            this.cd_portador.NM_Param = "@P_CD_EMPRESA";
            this.cd_portador.QTD_Zero = 0;
            this.cd_portador.Size = new System.Drawing.Size(67, 20);
            this.cd_portador.ST_AutoInc = false;
            this.cd_portador.ST_DisableAuto = false;
            this.cd_portador.ST_Float = false;
            this.cd_portador.ST_Gravar = true;
            this.cd_portador.ST_Int = false;
            this.cd_portador.ST_LimpaCampo = true;
            this.cd_portador.ST_NotNull = true;
            this.cd_portador.ST_PrimaryKey = false;
            this.cd_portador.TabIndex = 0;
            this.cd_portador.Leave += new System.EventHandler(this.cd_portador_Leave);
            // 
            // ds_portador
            // 
            this.ds_portador.BackColor = System.Drawing.SystemColors.Window;
            this.ds_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFechamento, "Ds_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_portador.Enabled = false;
            this.ds_portador.Location = new System.Drawing.Point(210, 3);
            this.ds_portador.Name = "ds_portador";
            this.ds_portador.NM_Alias = "";
            this.ds_portador.NM_Campo = "ds_portador";
            this.ds_portador.NM_CampoBusca = "ds_portador";
            this.ds_portador.NM_Param = "@P_NM_EMPRESA";
            this.ds_portador.QTD_Zero = 0;
            this.ds_portador.Size = new System.Drawing.Size(291, 20);
            this.ds_portador.ST_AutoInc = false;
            this.ds_portador.ST_DisableAuto = false;
            this.ds_portador.ST_Float = false;
            this.ds_portador.ST_Gravar = false;
            this.ds_portador.ST_Int = false;
            this.ds_portador.ST_LimpaCampo = true;
            this.ds_portador.ST_NotNull = false;
            this.ds_portador.ST_PrimaryKey = false;
            this.ds_portador.TabIndex = 86;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label13.Location = new System.Drawing.Point(43, 6);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(59, 13);
            label13.TabIndex = 85;
            label13.Text = "Portador:";
            // 
            // bb_portador
            // 
            this.bb_portador.BackColor = System.Drawing.SystemColors.Control;
            this.bb_portador.Image = ((System.Drawing.Image)(resources.GetObject("bb_portador.Image")));
            this.bb_portador.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_portador.Location = new System.Drawing.Point(176, 3);
            this.bb_portador.Name = "bb_portador";
            this.bb_portador.Size = new System.Drawing.Size(28, 19);
            this.bb_portador.TabIndex = 1;
            this.bb_portador.UseVisualStyleBackColor = false;
            this.bb_portador.Click += new System.EventHandler(this.bb_portador_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(3, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(99, 13);
            label1.TabIndex = 87;
            label1.Text = "Vl. Fechamento:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(22, 57);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(80, 13);
            label2.TabIndex = 88;
            label2.Text = "Vl. Auditado:";
            // 
            // vl_fechamento
            // 
            this.vl_fechamento.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFechamento, "Vl_fechamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_fechamento.DecimalPlaces = 2;
            this.vl_fechamento.Location = new System.Drawing.Point(108, 29);
            this.vl_fechamento.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_fechamento.Name = "vl_fechamento";
            this.vl_fechamento.NM_Alias = "";
            this.vl_fechamento.NM_Campo = "";
            this.vl_fechamento.NM_Param = "";
            this.vl_fechamento.Operador = "";
            this.vl_fechamento.Size = new System.Drawing.Size(120, 20);
            this.vl_fechamento.ST_AutoInc = false;
            this.vl_fechamento.ST_DisableAuto = false;
            this.vl_fechamento.ST_Gravar = true;
            this.vl_fechamento.ST_LimparCampo = true;
            this.vl_fechamento.ST_NotNull = true;
            this.vl_fechamento.ST_PrimaryKey = false;
            this.vl_fechamento.TabIndex = 2;
            this.vl_fechamento.ThousandsSeparator = true;
            // 
            // vl_auditado
            // 
            this.vl_auditado.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFechamento, "Vl_auditado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_auditado.DecimalPlaces = 2;
            this.vl_auditado.Location = new System.Drawing.Point(108, 55);
            this.vl_auditado.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_auditado.Name = "vl_auditado";
            this.vl_auditado.NM_Alias = "";
            this.vl_auditado.NM_Campo = "";
            this.vl_auditado.NM_Param = "";
            this.vl_auditado.Operador = "";
            this.vl_auditado.Size = new System.Drawing.Size(120, 20);
            this.vl_auditado.ST_AutoInc = false;
            this.vl_auditado.ST_DisableAuto = false;
            this.vl_auditado.ST_Gravar = true;
            this.vl_auditado.ST_LimparCampo = true;
            this.vl_auditado.ST_NotNull = false;
            this.vl_auditado.ST_PrimaryKey = false;
            this.vl_auditado.TabIndex = 3;
            this.vl_auditado.ThousandsSeparator = true;
            // 
            // bsFechamento
            // 
            this.bsFechamento.DataSource = typeof(CamadaDados.Faturamento.PDV.TList_FechamentoCaixa);
            // 
            // TFFechamentoCaixaPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 123);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFFechamentoCaixaPDV";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fechamento Caixa PDV";
            this.Load += new System.EventHandler(this.TFFechamentoCaixaPDV_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFFechamentoCaixaPDV_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_fechamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_auditado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFechamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault cd_portador;
        private Componentes.EditDefault ds_portador;
        private System.Windows.Forms.Button bb_portador;
        private Componentes.EditFloat vl_auditado;
        private Componentes.EditFloat vl_fechamento;
        private System.Windows.Forms.BindingSource bsFechamento;
    }
}