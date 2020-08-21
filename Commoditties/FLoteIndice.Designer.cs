namespace Commoditties
{
    partial class TFLoteIndice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLoteIndice));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.intervalo_desconto = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pc_desc_inicial = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.pc_desc_apartir = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.rgResultado = new Componentes.RadioGroup(this.components);
            this.intervalo_resultado = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pc_fin_resultado = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pc_ini_resultado = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalo_desconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desc_inicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desc_apartir)).BeginInit();
            this.rgResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalo_resultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_fin_resultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_ini_resultado)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(289, 43);
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
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.rgResultado);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(289, 139);
            this.pDados.TabIndex = 6;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.intervalo_desconto);
            this.radioGroup1.Controls.Add(this.label4);
            this.radioGroup1.Controls.Add(this.pc_desc_inicial);
            this.radioGroup1.Controls.Add(this.label5);
            this.radioGroup1.Controls.Add(this.pc_desc_apartir);
            this.radioGroup1.Controls.Add(this.label6);
            this.radioGroup1.Location = new System.Drawing.Point(3, 69);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(278, 60);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 1;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Dados Desconto";
            // 
            // intervalo_desconto
            // 
            this.intervalo_desconto.DecimalPlaces = 2;
            this.intervalo_desconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intervalo_desconto.Location = new System.Drawing.Point(183, 32);
            this.intervalo_desconto.Name = "intervalo_desconto";
            this.intervalo_desconto.NM_Alias = "";
            this.intervalo_desconto.NM_Campo = "GRAUDESCINI";
            this.intervalo_desconto.NM_Param = "@PGRAUDESCINI";
            this.intervalo_desconto.Operador = "";
            this.intervalo_desconto.Size = new System.Drawing.Size(80, 20);
            this.intervalo_desconto.ST_AutoInc = false;
            this.intervalo_desconto.ST_DisableAuto = false;
            this.intervalo_desconto.ST_Gravar = true;
            this.intervalo_desconto.ST_LimparCampo = true;
            this.intervalo_desconto.ST_NotNull = false;
            this.intervalo_desconto.ST_PrimaryKey = false;
            this.intervalo_desconto.TabIndex = 2;
            this.intervalo_desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.intervalo_desconto.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(180, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Intervalo";
            // 
            // pc_desc_inicial
            // 
            this.pc_desc_inicial.DecimalPlaces = 2;
            this.pc_desc_inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pc_desc_inicial.Location = new System.Drawing.Point(97, 32);
            this.pc_desc_inicial.Name = "pc_desc_inicial";
            this.pc_desc_inicial.NM_Alias = "";
            this.pc_desc_inicial.NM_Campo = "GRAUDESCINI";
            this.pc_desc_inicial.NM_Param = "@PGRAUDESCINI";
            this.pc_desc_inicial.Operador = "";
            this.pc_desc_inicial.Size = new System.Drawing.Size(80, 20);
            this.pc_desc_inicial.ST_AutoInc = false;
            this.pc_desc_inicial.ST_DisableAuto = false;
            this.pc_desc_inicial.ST_Gravar = true;
            this.pc_desc_inicial.ST_LimparCampo = true;
            this.pc_desc_inicial.ST_NotNull = false;
            this.pc_desc_inicial.ST_PrimaryKey = false;
            this.pc_desc_inicial.TabIndex = 1;
            this.pc_desc_inicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pc_desc_inicial.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(94, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "% Desc. Ini.";
            // 
            // pc_desc_apartir
            // 
            this.pc_desc_apartir.DecimalPlaces = 2;
            this.pc_desc_apartir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pc_desc_apartir.Location = new System.Drawing.Point(11, 32);
            this.pc_desc_apartir.Name = "pc_desc_apartir";
            this.pc_desc_apartir.NM_Alias = "";
            this.pc_desc_apartir.NM_Campo = "GRAUDESCINI";
            this.pc_desc_apartir.NM_Param = "@PGRAUDESCINI";
            this.pc_desc_apartir.Operador = "";
            this.pc_desc_apartir.Size = new System.Drawing.Size(80, 20);
            this.pc_desc_apartir.ST_AutoInc = false;
            this.pc_desc_apartir.ST_DisableAuto = false;
            this.pc_desc_apartir.ST_Gravar = true;
            this.pc_desc_apartir.ST_LimparCampo = true;
            this.pc_desc_apartir.ST_NotNull = false;
            this.pc_desc_apartir.ST_PrimaryKey = false;
            this.pc_desc_apartir.TabIndex = 0;
            this.pc_desc_apartir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pc_desc_apartir.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Desc. a partir";
            // 
            // rgResultado
            // 
            this.rgResultado.Controls.Add(this.intervalo_resultado);
            this.rgResultado.Controls.Add(this.label3);
            this.rgResultado.Controls.Add(this.pc_fin_resultado);
            this.rgResultado.Controls.Add(this.label2);
            this.rgResultado.Controls.Add(this.pc_ini_resultado);
            this.rgResultado.Controls.Add(this.label1);
            this.rgResultado.Location = new System.Drawing.Point(3, 3);
            this.rgResultado.Name = "rgResultado";
            this.rgResultado.NM_Alias = "";
            this.rgResultado.NM_Campo = "";
            this.rgResultado.NM_Param = "";
            this.rgResultado.NM_Valor = "";
            this.rgResultado.Size = new System.Drawing.Size(278, 60);
            this.rgResultado.ST_Gravar = false;
            this.rgResultado.ST_NotNull = false;
            this.rgResultado.TabIndex = 0;
            this.rgResultado.TabStop = false;
            this.rgResultado.Text = "Dados Resultado";
            // 
            // intervalo_resultado
            // 
            this.intervalo_resultado.DecimalPlaces = 2;
            this.intervalo_resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intervalo_resultado.Location = new System.Drawing.Point(183, 32);
            this.intervalo_resultado.Name = "intervalo_resultado";
            this.intervalo_resultado.NM_Alias = "";
            this.intervalo_resultado.NM_Campo = "GRAUDESCINI";
            this.intervalo_resultado.NM_Param = "@PGRAUDESCINI";
            this.intervalo_resultado.Operador = "";
            this.intervalo_resultado.Size = new System.Drawing.Size(80, 20);
            this.intervalo_resultado.ST_AutoInc = false;
            this.intervalo_resultado.ST_DisableAuto = false;
            this.intervalo_resultado.ST_Gravar = true;
            this.intervalo_resultado.ST_LimparCampo = true;
            this.intervalo_resultado.ST_NotNull = false;
            this.intervalo_resultado.ST_PrimaryKey = false;
            this.intervalo_resultado.TabIndex = 2;
            this.intervalo_resultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.intervalo_resultado.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(180, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Intervalo";
            // 
            // pc_fin_resultado
            // 
            this.pc_fin_resultado.DecimalPlaces = 2;
            this.pc_fin_resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pc_fin_resultado.Location = new System.Drawing.Point(97, 32);
            this.pc_fin_resultado.Name = "pc_fin_resultado";
            this.pc_fin_resultado.NM_Alias = "";
            this.pc_fin_resultado.NM_Campo = "GRAUDESCINI";
            this.pc_fin_resultado.NM_Param = "@PGRAUDESCINI";
            this.pc_fin_resultado.Operador = "";
            this.pc_fin_resultado.Size = new System.Drawing.Size(80, 20);
            this.pc_fin_resultado.ST_AutoInc = false;
            this.pc_fin_resultado.ST_DisableAuto = false;
            this.pc_fin_resultado.ST_Gravar = true;
            this.pc_fin_resultado.ST_LimparCampo = true;
            this.pc_fin_resultado.ST_NotNull = false;
            this.pc_fin_resultado.ST_PrimaryKey = false;
            this.pc_fin_resultado.TabIndex = 1;
            this.pc_fin_resultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pc_fin_resultado.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(94, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "% Final";
            // 
            // pc_ini_resultado
            // 
            this.pc_ini_resultado.DecimalPlaces = 2;
            this.pc_ini_resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pc_ini_resultado.Location = new System.Drawing.Point(11, 32);
            this.pc_ini_resultado.Name = "pc_ini_resultado";
            this.pc_ini_resultado.NM_Alias = "";
            this.pc_ini_resultado.NM_Campo = "GRAUDESCINI";
            this.pc_ini_resultado.NM_Param = "@PGRAUDESCINI";
            this.pc_ini_resultado.Operador = "";
            this.pc_ini_resultado.Size = new System.Drawing.Size(80, 20);
            this.pc_ini_resultado.ST_AutoInc = false;
            this.pc_ini_resultado.ST_DisableAuto = false;
            this.pc_ini_resultado.ST_Gravar = true;
            this.pc_ini_resultado.ST_LimparCampo = true;
            this.pc_ini_resultado.ST_NotNull = false;
            this.pc_ini_resultado.ST_PrimaryKey = false;
            this.pc_ini_resultado.TabIndex = 0;
            this.pc_ini_resultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pc_ini_resultado.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "% Inicial";
            // 
            // TFLoteIndice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 182);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLoteIndice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lote Indice Desconto";
            this.Load += new System.EventHandler(this.TFLoteIndice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLoteIndice_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalo_desconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desc_inicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desc_apartir)).EndInit();
            this.rgResultado.ResumeLayout(false);
            this.rgResultado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalo_resultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_fin_resultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_ini_resultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.RadioGroup rgResultado;
        private Componentes.EditFloat pc_fin_resultado;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat pc_ini_resultado;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat intervalo_resultado;
        private System.Windows.Forms.Label label3;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.EditFloat intervalo_desconto;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat pc_desc_inicial;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat pc_desc_apartir;
        private System.Windows.Forms.Label label6;
    }
}