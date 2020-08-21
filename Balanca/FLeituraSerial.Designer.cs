namespace Balanca
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bb_capturar = new System.Windows.Forms.Button();
            this.bb_cancelar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPorta = new System.Windows.Forms.Label();
            this.lblProtocolo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblValor = new System.Windows.Forms.Label();
            this.valor = new Componentes.EditFloat(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.lblAmostra = new System.Windows.Forms.Label();
            this.tmCaptura = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AccessibleDescription = null;
            this.tableLayoutPanel1.AccessibleName = null;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackgroundImage = null;
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel1.Font = null;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AccessibleDescription = null;
            this.tableLayoutPanel2.AccessibleName = null;
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.BackgroundImage = null;
            this.tableLayoutPanel2.Controls.Add(this.bb_capturar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.bb_cancelar, 1, 0);
            this.tableLayoutPanel2.Font = null;
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // bb_capturar
            // 
            this.bb_capturar.AccessibleDescription = null;
            this.bb_capturar.AccessibleName = null;
            resources.ApplyResources(this.bb_capturar, "bb_capturar");
            this.bb_capturar.BackgroundImage = null;
            this.bb_capturar.Font = null;
            this.bb_capturar.Name = "bb_capturar";
            this.bb_capturar.UseVisualStyleBackColor = true;
            this.bb_capturar.Click += new System.EventHandler(this.bb_capturar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AccessibleDescription = null;
            this.bb_cancelar.AccessibleName = null;
            resources.ApplyResources(this.bb_cancelar, "bb_cancelar");
            this.bb_cancelar.BackgroundImage = null;
            this.bb_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bb_cancelar.Font = null;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.UseVisualStyleBackColor = true;
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // panel2
            // 
            this.panel2.AccessibleDescription = null;
            this.panel2.AccessibleName = null;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackgroundImage = null;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblPorta);
            this.panel2.Controls.Add(this.lblProtocolo);
            this.panel2.Font = null;
            this.panel2.Name = "panel2";
            // 
            // lblPorta
            // 
            this.lblPorta.AccessibleDescription = null;
            this.lblPorta.AccessibleName = null;
            resources.ApplyResources(this.lblPorta, "lblPorta");
            this.lblPorta.Name = "lblPorta";
            // 
            // lblProtocolo
            // 
            this.lblProtocolo.AccessibleDescription = null;
            this.lblProtocolo.AccessibleName = null;
            resources.ApplyResources(this.lblProtocolo, "lblProtocolo");
            this.lblProtocolo.Name = "lblProtocolo";
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblValor);
            this.panel1.Controls.Add(this.valor);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // lblValor
            // 
            this.lblValor.AccessibleDescription = null;
            this.lblValor.AccessibleName = null;
            resources.ApplyResources(this.lblValor, "lblValor");
            this.lblValor.Name = "lblValor";
            // 
            // valor
            // 
            this.valor.AccessibleDescription = null;
            this.valor.AccessibleName = null;
            resources.ApplyResources(this.valor, "valor");
            this.valor.BackColor = System.Drawing.Color.White;
            this.valor.DecimalPlaces = 3;
            this.valor.ForeColor = System.Drawing.Color.Red;
            this.valor.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.valor.Name = "valor";
            this.valor.NM_Alias = "";
            this.valor.NM_Campo = "";
            this.valor.NM_Param = "";
            this.valor.Operador = "";
            this.valor.ReadOnly = true;
            this.valor.ST_AutoInc = false;
            this.valor.ST_DisableAuto = false;
            this.valor.ST_Gravar = false;
            this.valor.ST_LimparCampo = true;
            this.valor.ST_NotNull = false;
            this.valor.ST_PrimaryKey = false;
            // 
            // panelDados1
            // 
            this.panelDados1.AccessibleDescription = null;
            this.panelDados1.AccessibleName = null;
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.BackgroundImage = null;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.lblAmostra);
            this.panelDados1.Font = null;
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // lblAmostra
            // 
            this.lblAmostra.AccessibleDescription = null;
            this.lblAmostra.AccessibleName = null;
            resources.ApplyResources(this.lblAmostra, "lblAmostra");
            this.lblAmostra.Name = "lblAmostra";
            // 
            // TFLeituraSerial
            // 
            this.AcceptButton = this.bb_capturar;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.bb_cancelar;
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = null;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLeituraSerial";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLeituraSerial_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLeituraSerial_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.valor)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Componentes.EditFloat valor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bb_capturar;
        private System.Windows.Forms.Button bb_cancelar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblProtocolo;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Timer tmCaptura;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label lblAmostra;
        private System.Windows.Forms.Label lblPorta;

    }
}