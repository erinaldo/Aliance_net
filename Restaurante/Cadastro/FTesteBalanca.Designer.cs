namespace Restaurante.Cadastro
{
    partial class FTesteBalanca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTesteBalanca));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Captura = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pesocapturado = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.tmpPeso = new System.Windows.Forms.Timer(this.components);
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.vl_total = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pesocapturado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_total)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Captura,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(271, 43);
            this.barraMenu.TabIndex = 13;
            // 
            // BB_Captura
            // 
            this.BB_Captura.AutoSize = false;
            this.BB_Captura.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Captura.ForeColor = System.Drawing.Color.Green;
            this.BB_Captura.Image = ((System.Drawing.Image)(resources.GetObject("BB_Captura.Image")));
            this.BB_Captura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Captura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Captura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Captura.Name = "BB_Captura";
            this.BB_Captura.Size = new System.Drawing.Size(100, 40);
            this.BB_Captura.Text = " (F4)\n Capturar";
            this.BB_Captura.ToolTipText = "Capturar Peso";
            this.BB_Captura.Click += new System.EventHandler(this.BB_Captura_Click);
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
            this.BB_Cancelar.Text = "(ESC)\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Captura Peso";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pesocapturado
            // 
            this.pesocapturado.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pesocapturado.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pesocapturado.Location = new System.Drawing.Point(15, 59);
            this.pesocapturado.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pesocapturado.Name = "pesocapturado";
            this.pesocapturado.NM_Alias = "";
            this.pesocapturado.NM_Campo = "";
            this.pesocapturado.NM_Param = "";
            this.pesocapturado.Operador = "";
            this.pesocapturado.ReadOnly = true;
            this.pesocapturado.Size = new System.Drawing.Size(198, 47);
            this.pesocapturado.ST_AutoInc = false;
            this.pesocapturado.ST_DisableAuto = false;
            this.pesocapturado.ST_Gravar = false;
            this.pesocapturado.ST_LimparCampo = true;
            this.pesocapturado.ST_NotNull = false;
            this.pesocapturado.ST_PrimaryKey = false;
            this.pesocapturado.TabIndex = 15;
            this.pesocapturado.TabStop = false;
            this.pesocapturado.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Peso Capturado:";
            // 
            // serial
            // 
            this.serial.PortName = "COM5";
            this.serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serial_DataReceived);
            // 
            // tmpPeso
            // 
            this.tmpPeso.Interval = 500;
            this.tmpPeso.Tick += new System.EventHandler(this.tmpPeso_Tick);
            // 
            // vl_unitario
            // 
            this.vl_unitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_unitario.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_unitario.Location = new System.Drawing.Point(14, 122);
            this.vl_unitario.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_unitario.Name = "vl_unitario";
            this.vl_unitario.NM_Alias = "";
            this.vl_unitario.NM_Campo = "";
            this.vl_unitario.NM_Param = "";
            this.vl_unitario.Operador = "";
            this.vl_unitario.ReadOnly = true;
            this.vl_unitario.Size = new System.Drawing.Size(198, 47);
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = false;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = false;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.TabIndex = 17;
            this.vl_unitario.TabStop = false;
            this.vl_unitario.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Valor Unitario:";
            // 
            // vl_total
            // 
            this.vl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_total.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_total.Location = new System.Drawing.Point(14, 188);
            this.vl_total.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_total.Name = "vl_total";
            this.vl_total.NM_Alias = "";
            this.vl_total.NM_Campo = "";
            this.vl_total.NM_Param = "";
            this.vl_total.Operador = "";
            this.vl_total.ReadOnly = true;
            this.vl_total.Size = new System.Drawing.Size(198, 47);
            this.vl_total.ST_AutoInc = false;
            this.vl_total.ST_DisableAuto = false;
            this.vl_total.ST_Gravar = false;
            this.vl_total.ST_LimparCampo = true;
            this.vl_total.ST_NotNull = false;
            this.vl_total.ST_PrimaryKey = false;
            this.vl_total.TabIndex = 19;
            this.vl_total.TabStop = false;
            this.vl_total.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Valor Total:";
            // 
            // FTesteBalanca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 249);
            this.Controls.Add(this.vl_total);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vl_unitario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pesocapturado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "FTesteBalanca";
            this.ShowInTaskbar = false;
            this.Text = "FTesteBalanca";
            this.Load += new System.EventHandler(this.FTesteBalanca_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FTesteBalanca_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pesocapturado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_total)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Captura;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.EditFloat pesocapturado;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.Timer tmpPeso;
        private Componentes.EditFloat vl_unitario;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat vl_total;
        private System.Windows.Forms.Label label3;
    }
}