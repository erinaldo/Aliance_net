namespace Financeiro
{
    partial class TFData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFData));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.data = new Componentes.EditData(this.components);
            this.ds_tpdata = new Componentes.EditDefault(this.components);
            this.bb_tpdata = new System.Windows.Forms.Button();
            this.id_tpdata = new Componentes.EditDefault(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(548, 43);
            this.barraMenu.TabIndex = 10;
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
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.data);
            this.pDados.Controls.Add(this.ds_tpdata);
            this.pDados.Controls.Add(this.bb_tpdata);
            this.pDados.Controls.Add(this.id_tpdata);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(548, 74);
            this.pDados.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Data:";
            // 
            // data
            // 
            this.data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.data.Location = new System.Drawing.Point(71, 39);
            this.data.Mask = "00/00/0000";
            this.data.Name = "data";
            this.data.NM_Alias = "";
            this.data.NM_Campo = "";
            this.data.NM_CampoBusca = "";
            this.data.NM_Param = "";
            this.data.Operador = "";
            this.data.Size = new System.Drawing.Size(100, 20);
            this.data.ST_Gravar = false;
            this.data.ST_LimpaCampo = true;
            this.data.ST_NotNull = false;
            this.data.ST_PrimaryKey = false;
            this.data.TabIndex = 63;
            // 
            // ds_tpdata
            // 
            this.ds_tpdata.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpdata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpdata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpdata.Enabled = false;
            this.ds_tpdata.Location = new System.Drawing.Point(169, 14);
            this.ds_tpdata.Name = "ds_tpdata";
            this.ds_tpdata.NM_Alias = "";
            this.ds_tpdata.NM_Campo = "ds_tpdata";
            this.ds_tpdata.NM_CampoBusca = "ds_tpdata";
            this.ds_tpdata.NM_Param = "";
            this.ds_tpdata.QTD_Zero = 0;
            this.ds_tpdata.Size = new System.Drawing.Size(360, 20);
            this.ds_tpdata.ST_AutoInc = false;
            this.ds_tpdata.ST_DisableAuto = false;
            this.ds_tpdata.ST_Float = false;
            this.ds_tpdata.ST_Gravar = false;
            this.ds_tpdata.ST_Int = false;
            this.ds_tpdata.ST_LimpaCampo = true;
            this.ds_tpdata.ST_NotNull = false;
            this.ds_tpdata.ST_PrimaryKey = false;
            this.ds_tpdata.TabIndex = 62;
            this.ds_tpdata.TextOld = null;
            // 
            // bb_tpdata
            // 
            this.bb_tpdata.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpdata.Image")));
            this.bb_tpdata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpdata.Location = new System.Drawing.Point(135, 14);
            this.bb_tpdata.Name = "bb_tpdata";
            this.bb_tpdata.Size = new System.Drawing.Size(28, 19);
            this.bb_tpdata.TabIndex = 60;
            this.bb_tpdata.UseVisualStyleBackColor = true;
            this.bb_tpdata.Click += new System.EventHandler(this.bb_tpdata_Click);
            // 
            // id_tpdata
            // 
            this.id_tpdata.BackColor = System.Drawing.SystemColors.Window;
            this.id_tpdata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_tpdata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tpdata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_tpdata.Location = new System.Drawing.Point(71, 14);
            this.id_tpdata.Name = "id_tpdata";
            this.id_tpdata.NM_Alias = "";
            this.id_tpdata.NM_Campo = "id_tpdata";
            this.id_tpdata.NM_CampoBusca = "id_tpdata";
            this.id_tpdata.NM_Param = "";
            this.id_tpdata.QTD_Zero = 0;
            this.id_tpdata.Size = new System.Drawing.Size(62, 20);
            this.id_tpdata.ST_AutoInc = false;
            this.id_tpdata.ST_DisableAuto = false;
            this.id_tpdata.ST_Float = false;
            this.id_tpdata.ST_Gravar = true;
            this.id_tpdata.ST_Int = true;
            this.id_tpdata.ST_LimpaCampo = true;
            this.id_tpdata.ST_NotNull = true;
            this.id_tpdata.ST_PrimaryKey = false;
            this.id_tpdata.TabIndex = 59;
            this.id_tpdata.TextOld = null;
            this.id_tpdata.Leave += new System.EventHandler(this.id_tpdata_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "Tipo Data:";
            // 
            // TFData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 117);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data";
            this.Load += new System.EventHandler(this.TFData_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFData_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_tpdata;
        private System.Windows.Forms.Button bb_tpdata;
        private Componentes.EditDefault id_tpdata;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private Componentes.EditData data;
    }
}