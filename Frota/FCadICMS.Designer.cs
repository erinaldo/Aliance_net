namespace Frota
{
    partial class TFCadICMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadICMS));
            this.LB_PC_Aliquota_ICMS = new System.Windows.Forms.Label();
            this.PC_Aliquota_ICMS = new Componentes.EditFloat(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pc_aliquotadest = new Componentes.EditFloat(this.components);
            this.cbSt = new Componentes.ComboBoxDefault(this.components);
            this.LB_CD_ST = new System.Windows.Forms.Label();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.PC_Aliquota_ICMS)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_aliquotadest)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_PC_Aliquota_ICMS
            // 
            this.LB_PC_Aliquota_ICMS.AutoSize = true;
            this.LB_PC_Aliquota_ICMS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_PC_Aliquota_ICMS.Location = new System.Drawing.Point(18, 45);
            this.LB_PC_Aliquota_ICMS.Name = "LB_PC_Aliquota_ICMS";
            this.LB_PC_Aliquota_ICMS.Size = new System.Drawing.Size(61, 13);
            this.LB_PC_Aliquota_ICMS.TabIndex = 101;
            this.LB_PC_Aliquota_ICMS.Text = "% Alíquota:";
            // 
            // PC_Aliquota_ICMS
            // 
            this.PC_Aliquota_ICMS.DecimalPlaces = 2;
            this.PC_Aliquota_ICMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.PC_Aliquota_ICMS.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PC_Aliquota_ICMS.Location = new System.Drawing.Point(85, 43);
            this.PC_Aliquota_ICMS.Name = "PC_Aliquota_ICMS";
            this.PC_Aliquota_ICMS.NM_Alias = "a";
            this.PC_Aliquota_ICMS.NM_Campo = "PC_Aliquota_ICMS";
            this.PC_Aliquota_ICMS.NM_Param = "@P_PC_ALIQUOTA_ICMS";
            this.PC_Aliquota_ICMS.Operador = "";
            this.PC_Aliquota_ICMS.Size = new System.Drawing.Size(104, 20);
            this.PC_Aliquota_ICMS.ST_AutoInc = false;
            this.PC_Aliquota_ICMS.ST_DisableAuto = false;
            this.PC_Aliquota_ICMS.ST_Gravar = true;
            this.PC_Aliquota_ICMS.ST_LimparCampo = true;
            this.PC_Aliquota_ICMS.ST_NotNull = false;
            this.PC_Aliquota_ICMS.ST_PrimaryKey = false;
            this.PC_Aliquota_ICMS.TabIndex = 1;
            this.PC_Aliquota_ICMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PC_Aliquota_ICMS.ThousandsSeparator = true;
            this.PC_Aliquota_ICMS.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.pc_aliquotadest);
            this.panelDados1.Controls.Add(this.cbSt);
            this.panelDados1.Controls.Add(this.LB_CD_ST);
            this.panelDados1.Controls.Add(this.LB_PC_Aliquota_ICMS);
            this.panelDados1.Controls.Add(this.PC_Aliquota_ICMS);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(634, 70);
            this.panelDados1.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(195, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "% Alíquota Dest.:";
            // 
            // pc_aliquotadest
            // 
            this.pc_aliquotadest.DecimalPlaces = 2;
            this.pc_aliquotadest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pc_aliquotadest.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pc_aliquotadest.Location = new System.Drawing.Point(290, 43);
            this.pc_aliquotadest.Name = "pc_aliquotadest";
            this.pc_aliquotadest.NM_Alias = "a";
            this.pc_aliquotadest.NM_Campo = "PC_Aliquota_ICMS";
            this.pc_aliquotadest.NM_Param = "@P_PC_ALIQUOTA_ICMS";
            this.pc_aliquotadest.Operador = "";
            this.pc_aliquotadest.Size = new System.Drawing.Size(104, 20);
            this.pc_aliquotadest.ST_AutoInc = false;
            this.pc_aliquotadest.ST_DisableAuto = false;
            this.pc_aliquotadest.ST_Gravar = true;
            this.pc_aliquotadest.ST_LimparCampo = true;
            this.pc_aliquotadest.ST_NotNull = false;
            this.pc_aliquotadest.ST_PrimaryKey = false;
            this.pc_aliquotadest.TabIndex = 2;
            this.pc_aliquotadest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pc_aliquotadest.ThousandsSeparator = true;
            this.pc_aliquotadest.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // cbSt
            // 
            this.cbSt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSt.FormattingEnabled = true;
            this.cbSt.Location = new System.Drawing.Point(85, 17);
            this.cbSt.Name = "cbSt";
            this.cbSt.NM_Alias = "";
            this.cbSt.NM_Campo = "";
            this.cbSt.NM_Param = "";
            this.cbSt.Size = new System.Drawing.Size(536, 21);
            this.cbSt.ST_Gravar = false;
            this.cbSt.ST_LimparCampo = true;
            this.cbSt.ST_NotNull = false;
            this.cbSt.TabIndex = 0;
            // 
            // LB_CD_ST
            // 
            this.LB_CD_ST.AutoSize = true;
            this.LB_CD_ST.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_ST.Location = new System.Drawing.Point(7, 20);
            this.LB_CD_ST.Name = "LB_CD_ST";
            this.LB_CD_ST.Size = new System.Drawing.Size(72, 13);
            this.LB_CD_ST.TabIndex = 98;
            this.LB_CD_ST.Text = "Sit. Tributária:";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(634, 43);
            this.barraMenu.TabIndex = 104;
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
            // TFCadICMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 113);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCadICMS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ICMS";
            this.Load += new System.EventHandler(this.TFCadICMS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCadICMS_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PC_Aliquota_ICMS)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_aliquotadest)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_PC_Aliquota_ICMS;
        private Componentes.EditFloat PC_Aliquota_ICMS;
        private Componentes.PanelDados panelDados1;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.Label LB_CD_ST;
        private Componentes.ComboBoxDefault cbSt;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat pc_aliquotadest;
    }
}