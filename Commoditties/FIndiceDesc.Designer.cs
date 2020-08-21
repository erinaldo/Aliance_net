namespace Commoditties
{
    partial class TFIndiceDesc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFIndiceDesc));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.LB_PC_DescPagto = new System.Windows.Forms.Label();
            this.LB_PC_Resultado = new System.Windows.Forms.Label();
            this.LB_PC_DescEstoque = new System.Windows.Forms.Label();
            this.PC_Resultado = new Componentes.EditFloat(this.components);
            this.bsIndice = new System.Windows.Forms.BindingSource(this.components);
            this.PC_DescEstoque = new Componentes.EditFloat(this.components);
            this.PC_DescPagto = new Componentes.EditFloat(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PC_Resultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIndice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_DescEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_DescPagto)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(269, 43);
            this.barraMenu.TabIndex = 5;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.LB_PC_DescPagto);
            this.pDados.Controls.Add(this.LB_PC_Resultado);
            this.pDados.Controls.Add(this.LB_PC_DescEstoque);
            this.pDados.Controls.Add(this.PC_Resultado);
            this.pDados.Controls.Add(this.PC_DescEstoque);
            this.pDados.Controls.Add(this.PC_DescPagto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(269, 51);
            this.pDados.TabIndex = 6;
            // 
            // LB_PC_DescPagto
            // 
            this.LB_PC_DescPagto.AutoSize = true;
            this.LB_PC_DescPagto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_PC_DescPagto.Location = new System.Drawing.Point(91, 5);
            this.LB_PC_DescPagto.Name = "LB_PC_DescPagto";
            this.LB_PC_DescPagto.Size = new System.Drawing.Size(71, 13);
            this.LB_PC_DescPagto.TabIndex = 11;
            this.LB_PC_DescPagto.Text = "%Desc Pagto";
            // 
            // LB_PC_Resultado
            // 
            this.LB_PC_Resultado.AutoSize = true;
            this.LB_PC_Resultado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_PC_Resultado.Location = new System.Drawing.Point(5, 5);
            this.LB_PC_Resultado.Name = "LB_PC_Resultado";
            this.LB_PC_Resultado.Size = new System.Drawing.Size(66, 13);
            this.LB_PC_Resultado.TabIndex = 9;
            this.LB_PC_Resultado.Text = "% Resultado";
            // 
            // LB_PC_DescEstoque
            // 
            this.LB_PC_DescEstoque.AutoSize = true;
            this.LB_PC_DescEstoque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_PC_DescEstoque.Location = new System.Drawing.Point(178, 5);
            this.LB_PC_DescEstoque.Name = "LB_PC_DescEstoque";
            this.LB_PC_DescEstoque.Size = new System.Drawing.Size(64, 13);
            this.LB_PC_DescEstoque.TabIndex = 10;
            this.LB_PC_DescEstoque.Text = "% Desc.Est.";
            // 
            // PC_Resultado
            // 
            this.PC_Resultado.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsIndice, "Pc_resultado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PC_Resultado.DecimalPlaces = 5;
            this.PC_Resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.PC_Resultado.Location = new System.Drawing.Point(8, 21);
            this.PC_Resultado.Name = "PC_Resultado";
            this.PC_Resultado.NM_Alias = "";
            this.PC_Resultado.NM_Campo = "PC_Resultado";
            this.PC_Resultado.NM_Param = "@P_PC_RESULTADO";
            this.PC_Resultado.Operador = "";
            this.PC_Resultado.Size = new System.Drawing.Size(80, 20);
            this.PC_Resultado.ST_AutoInc = false;
            this.PC_Resultado.ST_DisableAuto = false;
            this.PC_Resultado.ST_Gravar = true;
            this.PC_Resultado.ST_LimparCampo = true;
            this.PC_Resultado.ST_NotNull = true;
            this.PC_Resultado.ST_PrimaryKey = false;
            this.PC_Resultado.TabIndex = 0;
            this.PC_Resultado.ThousandsSeparator = true;
            // 
            // bsIndice
            // 
            this.bsIndice.DataSource = typeof(CamadaDados.Graos.TList_PercDesconto);
            // 
            // PC_DescEstoque
            // 
            this.PC_DescEstoque.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsIndice, "Pc_descestoque", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PC_DescEstoque.DecimalPlaces = 5;
            this.PC_DescEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.PC_DescEstoque.Location = new System.Drawing.Point(181, 21);
            this.PC_DescEstoque.Name = "PC_DescEstoque";
            this.PC_DescEstoque.NM_Alias = "";
            this.PC_DescEstoque.NM_Campo = "PC_DescEstoque";
            this.PC_DescEstoque.NM_Param = "@P_PC_DESCESTOQUE";
            this.PC_DescEstoque.Operador = "";
            this.PC_DescEstoque.Size = new System.Drawing.Size(80, 20);
            this.PC_DescEstoque.ST_AutoInc = false;
            this.PC_DescEstoque.ST_DisableAuto = false;
            this.PC_DescEstoque.ST_Gravar = true;
            this.PC_DescEstoque.ST_LimparCampo = true;
            this.PC_DescEstoque.ST_NotNull = false;
            this.PC_DescEstoque.ST_PrimaryKey = false;
            this.PC_DescEstoque.TabIndex = 2;
            this.PC_DescEstoque.ThousandsSeparator = true;
            // 
            // PC_DescPagto
            // 
            this.PC_DescPagto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsIndice, "Pc_descpagto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PC_DescPagto.DecimalPlaces = 5;
            this.PC_DescPagto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.PC_DescPagto.Location = new System.Drawing.Point(94, 21);
            this.PC_DescPagto.Name = "PC_DescPagto";
            this.PC_DescPagto.NM_Alias = "";
            this.PC_DescPagto.NM_Campo = "PC_DescPagto";
            this.PC_DescPagto.NM_Param = "@P_PC_DESCPAGTO";
            this.PC_DescPagto.Operador = "";
            this.PC_DescPagto.Size = new System.Drawing.Size(81, 20);
            this.PC_DescPagto.ST_AutoInc = false;
            this.PC_DescPagto.ST_DisableAuto = false;
            this.PC_DescPagto.ST_Gravar = true;
            this.PC_DescPagto.ST_LimparCampo = true;
            this.PC_DescPagto.ST_NotNull = false;
            this.PC_DescPagto.ST_PrimaryKey = false;
            this.PC_DescPagto.TabIndex = 1;
            this.PC_DescPagto.ThousandsSeparator = true;
            // 
            // TFIndiceDesc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 94);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFIndiceDesc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indice Desconto";
            this.Load += new System.EventHandler(this.TFIndiceDesc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFIndiceDesc_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PC_Resultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIndice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_DescEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_DescPagto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label LB_PC_DescPagto;
        private System.Windows.Forms.Label LB_PC_Resultado;
        private System.Windows.Forms.Label LB_PC_DescEstoque;
        private Componentes.EditFloat PC_Resultado;
        private System.Windows.Forms.BindingSource bsIndice;
        private Componentes.EditFloat PC_DescEstoque;
        private Componentes.EditFloat PC_DescPagto;
    }
}