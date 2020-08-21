namespace Proc_Commoditties
{
    partial class TFBalancaProc
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
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.BB_Capturar = new System.Windows.Forms.Button();
            this.BB_Cancelar = new System.Windows.Forms.Button();
            this.tempo = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // serial
            // 
            this.serial.PortName = "COM5";
            this.serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serial_DataReceived);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 40);
            this.label1.TabIndex = 15;
            this.label1.Text = "Aguardando dados Balança";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPeso
            // 
            this.lblPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso.ForeColor = System.Drawing.Color.Red;
            this.lblPeso.Location = new System.Drawing.Point(12, 51);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(296, 23);
            this.lblPeso.TabIndex = 17;
            this.lblPeso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BB_Capturar
            // 
            this.BB_Capturar.Enabled = false;
            this.BB_Capturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Capturar.ForeColor = System.Drawing.Color.Green;
            this.BB_Capturar.Location = new System.Drawing.Point(12, 95);
            this.BB_Capturar.Name = "BB_Capturar";
            this.BB_Capturar.Size = new System.Drawing.Size(145, 33);
            this.BB_Capturar.TabIndex = 18;
            this.BB_Capturar.Text = "Capturar (F2)";
            this.BB_Capturar.UseVisualStyleBackColor = true;
            this.BB_Capturar.Click += new System.EventHandler(this.BB_Capturar_Click);
            this.BB_Capturar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BB_Capturar_KeyDown);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Red;
            this.BB_Cancelar.Location = new System.Drawing.Point(163, 95);
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(145, 33);
            this.BB_Cancelar.TabIndex = 19;
            this.BB_Cancelar.Text = "Cancelar (ESC)";
            this.BB_Cancelar.UseVisualStyleBackColor = true;
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            this.BB_Cancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BB_Cancelar_KeyDown);
            // 
            // tempo
            // 
            this.tempo.Interval = 500;
            this.tempo.Tick += new System.EventHandler(this.tempo_Tick);
            // 
            // TFBalancaProc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 140);
            this.Controls.Add(this.BB_Cancelar);
            this.Controls.Add(this.BB_Capturar);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TFBalancaProc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FBalancaProc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFBalancaProc_FormClosing);
            this.Load += new System.EventHandler(this.FBalancaProc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Button BB_Capturar;
        private System.Windows.Forms.Button BB_Cancelar;
        private System.Windows.Forms.Timer tempo;
    }
}