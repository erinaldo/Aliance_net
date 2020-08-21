namespace Locacao
{
    partial class TFOutrasDesp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFOutrasDesp));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.vl_despesa = new Componentes.EditFloat(this.components);
            this.bsOutrasDesp = new System.Windows.Forms.BindingSource(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.dt_despesa = new Componentes.EditData(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.ds_despesa = new Componentes.EditDefault(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_despesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOutrasDesp)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(469, 43);
            this.barraMenu.TabIndex = 14;
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
            this.pDados.Controls.Add(this.vl_despesa);
            this.pDados.Controls.Add(this.label15);
            this.pDados.Controls.Add(this.dt_despesa);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(this.ds_despesa);
            this.pDados.Controls.Add(this.label18);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(469, 236);
            this.pDados.TabIndex = 15;
            // 
            // vl_despesa
            // 
            this.vl_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsOutrasDesp, "Vl_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_despesa.DecimalPlaces = 2;
            this.vl_despesa.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_despesa.Location = new System.Drawing.Point(269, 211);
            this.vl_despesa.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_despesa.Name = "vl_despesa";
            this.vl_despesa.NM_Alias = "";
            this.vl_despesa.NM_Campo = "Vl. Despesa";
            this.vl_despesa.NM_Param = "@P_DESPESA";
            this.vl_despesa.Operador = "";
            this.vl_despesa.Size = new System.Drawing.Size(85, 20);
            this.vl_despesa.ST_AutoInc = false;
            this.vl_despesa.ST_DisableAuto = false;
            this.vl_despesa.ST_Gravar = true;
            this.vl_despesa.ST_LimparCampo = true;
            this.vl_despesa.ST_NotNull = true;
            this.vl_despesa.ST_PrimaryKey = false;
            this.vl_despesa.TabIndex = 2;
            this.vl_despesa.ThousandsSeparator = true;
            // 
            // bsOutrasDesp
            // 
            this.bsOutrasDesp.DataSource = typeof(CamadaDados.Locacao.TList_OutrasDesp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(198, 213);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 126;
            this.label15.Text = "Vl. Despesa:";
            // 
            // dt_despesa
            // 
            this.dt_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOutrasDesp, "Dt_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_despesa.Location = new System.Drawing.Point(94, 211);
            this.dt_despesa.Mask = "00/00/0000";
            this.dt_despesa.Name = "dt_despesa";
            this.dt_despesa.NM_Alias = "";
            this.dt_despesa.NM_Campo = "Dt. Despesa";
            this.dt_despesa.NM_CampoBusca = "dt_despesa";
            this.dt_despesa.NM_Param = "@P_DT_DESPESA";
            this.dt_despesa.Operador = "";
            this.dt_despesa.Size = new System.Drawing.Size(81, 20);
            this.dt_despesa.ST_Gravar = true;
            this.dt_despesa.ST_LimpaCampo = true;
            this.dt_despesa.ST_NotNull = true;
            this.dt_despesa.ST_PrimaryKey = false;
            this.dt_despesa.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 124;
            this.label11.Text = "Dt. Despesa:";
            // 
            // ds_despesa
            // 
            this.ds_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOutrasDesp, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_despesa.Location = new System.Drawing.Point(21, 25);
            this.ds_despesa.Multiline = true;
            this.ds_despesa.Name = "ds_despesa";
            this.ds_despesa.NM_Alias = "";
            this.ds_despesa.NM_Campo = "";
            this.ds_despesa.NM_CampoBusca = "";
            this.ds_despesa.NM_Param = "";
            this.ds_despesa.QTD_Zero = 0;
            this.ds_despesa.Size = new System.Drawing.Size(435, 180);
            this.ds_despesa.ST_AutoInc = false;
            this.ds_despesa.ST_DisableAuto = false;
            this.ds_despesa.ST_Float = false;
            this.ds_despesa.ST_Gravar = true;
            this.ds_despesa.ST_Int = false;
            this.ds_despesa.ST_LimpaCampo = true;
            this.ds_despesa.ST_NotNull = true;
            this.ds_despesa.ST_PrimaryKey = false;
            this.ds_despesa.TabIndex = 0;
            this.ds_despesa.TextOld = null;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 13);
            this.label18.TabIndex = 122;
            this.label18.Text = "Despesa";
            // 
            // TFOutrasDesp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 279);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFOutrasDesp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despesas";
            this.Load += new System.EventHandler(this.TFOutrasDesp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFOutrasDesp_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_despesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOutrasDesp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_despesa;
        private System.Windows.Forms.Label label18;
        private Componentes.EditData dt_despesa;
        private System.Windows.Forms.Label label11;
        private Componentes.EditFloat vl_despesa;
        private System.Windows.Forms.BindingSource bsOutrasDesp;
        private System.Windows.Forms.Label label15;
    }
}