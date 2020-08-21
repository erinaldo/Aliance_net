namespace Frota
{
    partial class TFCadPremioSeguro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadPremioSeguro));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_premio = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.vl_seguro = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bsPremioSeguro = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_seguro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPremioSeguro)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(412, 43);
            this.barraMenu.TabIndex = 6;
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.vl_seguro);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_premio);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(412, 87);
            this.pDados.TabIndex = 7;
            // 
            // ds_premio
            // 
            this.ds_premio.BackColor = System.Drawing.SystemColors.Window;
            this.ds_premio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_premio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_premio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPremioSeguro, "Ds_premio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_premio.Location = new System.Drawing.Point(7, 21);
            this.ds_premio.Name = "ds_premio";
            this.ds_premio.NM_Alias = "";
            this.ds_premio.NM_Campo = "";
            this.ds_premio.NM_CampoBusca = "";
            this.ds_premio.NM_Param = "";
            this.ds_premio.QTD_Zero = 0;
            this.ds_premio.Size = new System.Drawing.Size(392, 20);
            this.ds_premio.ST_AutoInc = false;
            this.ds_premio.ST_DisableAuto = false;
            this.ds_premio.ST_Float = false;
            this.ds_premio.ST_Gravar = true;
            this.ds_premio.ST_Int = false;
            this.ds_premio.ST_LimpaCampo = true;
            this.ds_premio.ST_NotNull = true;
            this.ds_premio.ST_PrimaryKey = false;
            this.ds_premio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descrição";
            // 
            // vl_seguro
            // 
            this.vl_seguro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPremioSeguro, "Vl_premio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_seguro.DecimalPlaces = 2;
            this.vl_seguro.Location = new System.Drawing.Point(7, 60);
            this.vl_seguro.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_seguro.Name = "vl_seguro";
            this.vl_seguro.NM_Alias = "";
            this.vl_seguro.NM_Campo = "";
            this.vl_seguro.NM_Param = "";
            this.vl_seguro.Operador = "";
            this.vl_seguro.Size = new System.Drawing.Size(120, 20);
            this.vl_seguro.ST_AutoInc = false;
            this.vl_seguro.ST_DisableAuto = false;
            this.vl_seguro.ST_Gravar = true;
            this.vl_seguro.ST_LimparCampo = true;
            this.vl_seguro.ST_NotNull = true;
            this.vl_seguro.ST_PrimaryKey = false;
            this.vl_seguro.TabIndex = 1;
            this.vl_seguro.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor do Premio";
            // 
            // bsPremioSeguro
            // 
            this.bsPremioSeguro.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_CadSeguroPremios);
            // 
            // TFCadPremioSeguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 130);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCadPremioSeguro";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Premio Seguro";
            this.Load += new System.EventHandler(this.TFCadPremioSeguro_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCadPremioSeguro_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_seguro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPremioSeguro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_premio;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat vl_seguro;
        private System.Windows.Forms.BindingSource bsPremioSeguro;
    }
}