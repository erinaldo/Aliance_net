namespace LeituraSerial
{
    partial class TFLeituraSerial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLeituraSerial));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Captura = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.st_detalhes = new Componentes.CheckBoxDefault(this.components);
            this.pesocapturado = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pDetalhes = new Componentes.PanelDados(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tamanhoString = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vl_capturado = new Componentes.EditDefault(this.components);
            this.strCompleta = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.tmpPeso = new System.Windows.Forms.Timer(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pesocapturado)).BeginInit();
            this.pDetalhes.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Captura,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(334, 43);
            this.barraMenu.TabIndex = 12;
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
            this.BB_Cancelar.Text = "(F6)\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Captura Peso";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Controls.Add(this.pDetalhes, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(334, 87);
            this.tlpCentral.TabIndex = 13;
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.st_detalhes);
            this.pDados.Controls.Add(this.pesocapturado);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Location = new System.Drawing.Point(5, 5);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(324, 76);
            this.pDados.TabIndex = 0;
            // 
            // st_detalhes
            // 
            this.st_detalhes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_detalhes.Location = new System.Drawing.Point(5, 21);
            this.st_detalhes.Name = "st_detalhes";
            this.st_detalhes.NM_Alias = "";
            this.st_detalhes.NM_Campo = "";
            this.st_detalhes.NM_Param = "";
            this.st_detalhes.Size = new System.Drawing.Size(104, 47);
            this.st_detalhes.ST_Gravar = false;
            this.st_detalhes.ST_LimparCampo = true;
            this.st_detalhes.ST_NotNull = false;
            this.st_detalhes.TabIndex = 2;
            this.st_detalhes.Text = "Visualizar Detalhes?";
            this.st_detalhes.UseVisualStyleBackColor = true;
            this.st_detalhes.Vl_False = "";
            this.st_detalhes.Vl_True = "";
            this.st_detalhes.CheckedChanged += new System.EventHandler(this.st_detalhes_CheckedChanged);
            // 
            // pesocapturado
            // 
            this.pesocapturado.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pesocapturado.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pesocapturado.Location = new System.Drawing.Point(119, 21);
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
            this.pesocapturado.TabIndex = 1;
            this.pesocapturado.TabStop = false;
            this.pesocapturado.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Peso Capturado:";
            // 
            // pDetalhes
            // 
            this.pDetalhes.Controls.Add(this.label4);
            this.pDetalhes.Controls.Add(this.tamanhoString);
            this.pDetalhes.Controls.Add(this.label3);
            this.pDetalhes.Controls.Add(this.vl_capturado);
            this.pDetalhes.Controls.Add(this.strCompleta);
            this.pDetalhes.Controls.Add(this.label2);
            this.pDetalhes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDetalhes.Location = new System.Drawing.Point(5, 89);
            this.pDetalhes.Name = "pDetalhes";
            this.pDetalhes.NM_ProcDeletar = "";
            this.pDetalhes.NM_ProcGravar = "";
            this.pDetalhes.Size = new System.Drawing.Size(324, 1);
            this.pDetalhes.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tamanho String Completa";
            // 
            // tamanhoString
            // 
            this.tamanhoString.BackColor = System.Drawing.SystemColors.Window;
            this.tamanhoString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tamanhoString.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tamanhoString.Location = new System.Drawing.Point(7, 99);
            this.tamanhoString.Name = "tamanhoString";
            this.tamanhoString.NM_Alias = "";
            this.tamanhoString.NM_Campo = "";
            this.tamanhoString.NM_CampoBusca = "";
            this.tamanhoString.NM_Param = "";
            this.tamanhoString.QTD_Zero = 0;
            this.tamanhoString.ReadOnly = true;
            this.tamanhoString.Size = new System.Drawing.Size(310, 20);
            this.tamanhoString.ST_AutoInc = false;
            this.tamanhoString.ST_DisableAuto = false;
            this.tamanhoString.ST_Float = false;
            this.tamanhoString.ST_Gravar = false;
            this.tamanhoString.ST_Int = false;
            this.tamanhoString.ST_LimpaCampo = true;
            this.tamanhoString.ST_NotNull = false;
            this.tamanhoString.ST_PrimaryKey = false;
            this.tamanhoString.TabIndex = 6;
            this.tamanhoString.TabStop = false;
            this.tamanhoString.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "String Peso";
            // 
            // vl_capturado
            // 
            this.vl_capturado.BackColor = System.Drawing.SystemColors.Window;
            this.vl_capturado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vl_capturado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.vl_capturado.Location = new System.Drawing.Point(7, 60);
            this.vl_capturado.Name = "vl_capturado";
            this.vl_capturado.NM_Alias = "";
            this.vl_capturado.NM_Campo = "";
            this.vl_capturado.NM_CampoBusca = "";
            this.vl_capturado.NM_Param = "";
            this.vl_capturado.QTD_Zero = 0;
            this.vl_capturado.ReadOnly = true;
            this.vl_capturado.Size = new System.Drawing.Size(310, 20);
            this.vl_capturado.ST_AutoInc = false;
            this.vl_capturado.ST_DisableAuto = false;
            this.vl_capturado.ST_Float = false;
            this.vl_capturado.ST_Gravar = false;
            this.vl_capturado.ST_Int = false;
            this.vl_capturado.ST_LimpaCampo = true;
            this.vl_capturado.ST_NotNull = false;
            this.vl_capturado.ST_PrimaryKey = false;
            this.vl_capturado.TabIndex = 4;
            this.vl_capturado.TabStop = false;
            this.vl_capturado.TextOld = null;
            // 
            // strCompleta
            // 
            this.strCompleta.BackColor = System.Drawing.SystemColors.Window;
            this.strCompleta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.strCompleta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.strCompleta.Location = new System.Drawing.Point(7, 21);
            this.strCompleta.Name = "strCompleta";
            this.strCompleta.NM_Alias = "";
            this.strCompleta.NM_Campo = "";
            this.strCompleta.NM_CampoBusca = "";
            this.strCompleta.NM_Param = "";
            this.strCompleta.QTD_Zero = 0;
            this.strCompleta.ReadOnly = true;
            this.strCompleta.Size = new System.Drawing.Size(310, 20);
            this.strCompleta.ST_AutoInc = false;
            this.strCompleta.ST_DisableAuto = false;
            this.strCompleta.ST_Float = false;
            this.strCompleta.ST_Gravar = false;
            this.strCompleta.ST_Int = false;
            this.strCompleta.ST_LimpaCampo = true;
            this.strCompleta.ST_NotNull = false;
            this.strCompleta.ST_PrimaryKey = false;
            this.strCompleta.TabIndex = 3;
            this.strCompleta.TabStop = false;
            this.strCompleta.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "String Completa";
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
            // TFLeituraSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 130);
            this.ControlBox = false;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLeituraSerial";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captura Peso Balança";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLeituraSerial_FormClosing);
            this.Load += new System.EventHandler(this.TFLeituraSerial_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLeituraSerial_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pesocapturado)).EndInit();
            this.pDetalhes.ResumeLayout(false);
            this.pDetalhes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Captura;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault strCompleta;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat pesocapturado;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serial;
        private Componentes.EditDefault vl_capturado;
        private Componentes.PanelDados pDetalhes;
        private System.Windows.Forms.Label label3;
        private Componentes.CheckBoxDefault st_detalhes;
        private Componentes.EditDefault tamanhoString;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer tmpPeso;
    }
}