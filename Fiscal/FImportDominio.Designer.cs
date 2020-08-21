namespace Fiscal
{
    partial class TFImportDominio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFImportDominio));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.rgFiltros = new Componentes.RadioGroup(this.components);
            this.cbCliente = new Componentes.CheckBoxDefault(this.components);
            this.cbFornecedor = new Componentes.CheckBoxDefault(this.components);
            this.cbRemetDest = new Componentes.CheckBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.rgFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(269, 43);
            this.barraMenu.TabIndex = 18;
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
            this.BB_Gravar.ToolTipText = "Confirmar";
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
            // rgFiltros
            // 
            this.rgFiltros.Controls.Add(this.cbRemetDest);
            this.rgFiltros.Controls.Add(this.cbFornecedor);
            this.rgFiltros.Controls.Add(this.cbCliente);
            this.rgFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgFiltros.Location = new System.Drawing.Point(0, 43);
            this.rgFiltros.Name = "rgFiltros";
            this.rgFiltros.NM_Alias = "";
            this.rgFiltros.NM_Campo = "";
            this.rgFiltros.NM_Param = "";
            this.rgFiltros.NM_Valor = "";
            this.rgFiltros.Size = new System.Drawing.Size(269, 87);
            this.rgFiltros.ST_Gravar = false;
            this.rgFiltros.ST_NotNull = false;
            this.rgFiltros.TabIndex = 0;
            this.rgFiltros.TabStop = false;
            this.rgFiltros.Text = "Opções de Filtros";
            // 
            // cbCliente
            // 
            this.cbCliente.AutoSize = true;
            this.cbCliente.Location = new System.Drawing.Point(12, 19);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.NM_Alias = "";
            this.cbCliente.NM_Campo = "";
            this.cbCliente.NM_Param = "";
            this.cbCliente.Size = new System.Drawing.Size(63, 17);
            this.cbCliente.ST_Gravar = false;
            this.cbCliente.ST_LimparCampo = true;
            this.cbCliente.ST_NotNull = false;
            this.cbCliente.TabIndex = 0;
            this.cbCliente.Text = "Clientes";
            this.cbCliente.UseVisualStyleBackColor = true;
            this.cbCliente.Vl_False = "";
            this.cbCliente.Vl_True = "";
            // 
            // cbFornecedor
            // 
            this.cbFornecedor.AutoSize = true;
            this.cbFornecedor.Location = new System.Drawing.Point(12, 42);
            this.cbFornecedor.Name = "cbFornecedor";
            this.cbFornecedor.NM_Alias = "";
            this.cbFornecedor.NM_Campo = "";
            this.cbFornecedor.NM_Param = "";
            this.cbFornecedor.Size = new System.Drawing.Size(91, 17);
            this.cbFornecedor.ST_Gravar = false;
            this.cbFornecedor.ST_LimparCampo = true;
            this.cbFornecedor.ST_NotNull = false;
            this.cbFornecedor.TabIndex = 1;
            this.cbFornecedor.Text = "Fornecedores";
            this.cbFornecedor.UseVisualStyleBackColor = true;
            this.cbFornecedor.Vl_False = "";
            this.cbFornecedor.Vl_True = "";
            // 
            // cbRemetDest
            // 
            this.cbRemetDest.AutoSize = true;
            this.cbRemetDest.Location = new System.Drawing.Point(12, 65);
            this.cbRemetDest.Name = "cbRemetDest";
            this.cbRemetDest.NM_Alias = "";
            this.cbRemetDest.NM_Campo = "";
            this.cbRemetDest.NM_Param = "";
            this.cbRemetDest.Size = new System.Drawing.Size(149, 17);
            this.cbRemetDest.ST_Gravar = false;
            this.cbRemetDest.ST_LimparCampo = true;
            this.cbRemetDest.ST_NotNull = false;
            this.cbRemetDest.TabIndex = 2;
            this.cbRemetDest.Text = "Remetentes/Destinatarios";
            this.cbRemetDest.UseVisualStyleBackColor = true;
            this.cbRemetDest.Vl_False = "";
            this.cbRemetDest.Vl_True = "";
            // 
            // TFImportDominio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 130);
            this.Controls.Add(this.rgFiltros);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFImportDominio";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Dominio";
            this.Load += new System.EventHandler(this.TFImportDominio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFImportDominio_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.rgFiltros.ResumeLayout(false);
            this.rgFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.RadioGroup rgFiltros;
        private Componentes.CheckBoxDefault cbRemetDest;
        private Componentes.CheckBoxDefault cbFornecedor;
        private Componentes.CheckBoxDefault cbCliente;
    }
}