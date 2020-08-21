namespace Mudanca
{
    partial class TFCadItensResumido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadItensResumido));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.metragemcubica = new Componentes.EditFloat(this.components);
            this.ds_item = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metragemcubica)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(487, 43);
            this.barraMenu.TabIndex = 15;
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
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.metragemcubica);
            this.pDados.Controls.Add(this.ds_item);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(487, 93);
            this.pDados.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Metragem Cubica";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Descrição Item";
            // 
            // metragemcubica
            // 
            this.metragemcubica.DecimalPlaces = 3;
            this.metragemcubica.Location = new System.Drawing.Point(14, 58);
            this.metragemcubica.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.metragemcubica.Name = "metragemcubica";
            this.metragemcubica.NM_Alias = "";
            this.metragemcubica.NM_Campo = "";
            this.metragemcubica.NM_Param = "";
            this.metragemcubica.Operador = "";
            this.metragemcubica.Size = new System.Drawing.Size(104, 20);
            this.metragemcubica.ST_AutoInc = false;
            this.metragemcubica.ST_DisableAuto = false;
            this.metragemcubica.ST_Gravar = false;
            this.metragemcubica.ST_LimparCampo = true;
            this.metragemcubica.ST_NotNull = false;
            this.metragemcubica.ST_PrimaryKey = false;
            this.metragemcubica.TabIndex = 1;
            this.metragemcubica.ThousandsSeparator = true;
            // 
            // ds_item
            // 
            this.ds_item.BackColor = System.Drawing.SystemColors.Window;
            this.ds_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_item.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_item.Location = new System.Drawing.Point(14, 19);
            this.ds_item.Name = "ds_item";
            this.ds_item.NM_Alias = "";
            this.ds_item.NM_Campo = "";
            this.ds_item.NM_CampoBusca = "";
            this.ds_item.NM_Param = "";
            this.ds_item.QTD_Zero = 0;
            this.ds_item.Size = new System.Drawing.Size(460, 20);
            this.ds_item.ST_AutoInc = false;
            this.ds_item.ST_DisableAuto = false;
            this.ds_item.ST_Float = false;
            this.ds_item.ST_Gravar = false;
            this.ds_item.ST_Int = false;
            this.ds_item.ST_LimpaCampo = true;
            this.ds_item.ST_NotNull = false;
            this.ds_item.ST_PrimaryKey = false;
            this.ds_item.TabIndex = 0;
            this.ds_item.TextOld = null;
            // 
            // TFCadItensResumido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 136);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCadItensResumido";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Novo Item Mudança";
            this.Load += new System.EventHandler(this.TFCadItensResumido_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCadItensResumido_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metragemcubica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditFloat metragemcubica;
        private Componentes.EditDefault ds_item;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}