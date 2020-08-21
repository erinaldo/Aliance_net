namespace Faturamento
{
    partial class TFRecalcCoo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRecalcCoo));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_equipamento = new System.Windows.Forms.Button();
            this.dt_ini = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.id_equipamento = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.dt_fin = new Componentes.EditData(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.ds_equipamento = new Componentes.EditDefault(this.components);
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
            this.barraMenu.Size = new System.Drawing.Size(503, 43);
            this.barraMenu.TabIndex = 11;
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
            this.pDados.Controls.Add(this.ds_equipamento);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.bb_equipamento);
            this.pDados.Controls.Add(this.dt_ini);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.id_equipamento);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.dt_fin);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(503, 82);
            this.pDados.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Dt. Fin:";
            // 
            // bb_equipamento
            // 
            this.bb_equipamento.Image = ((System.Drawing.Image)(resources.GetObject("bb_equipamento.Image")));
            this.bb_equipamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_equipamento.Location = new System.Drawing.Point(167, 55);
            this.bb_equipamento.Name = "bb_equipamento";
            this.bb_equipamento.Size = new System.Drawing.Size(28, 20);
            this.bb_equipamento.TabIndex = 5;
            this.bb_equipamento.UseVisualStyleBackColor = true;
            this.bb_equipamento.Click += new System.EventHandler(this.bb_equipamento_Click);
            // 
            // dt_ini
            // 
            this.dt_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini.Location = new System.Drawing.Point(90, 3);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Operador = "";
            this.dt_ini.Size = new System.Drawing.Size(66, 20);
            this.dt_ini.ST_Gravar = true;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = true;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Dt. Ini:";
            // 
            // id_equipamento
            // 
            this.id_equipamento.BackColor = System.Drawing.SystemColors.Window;
            this.id_equipamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_equipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_equipamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_equipamento.Location = new System.Drawing.Point(90, 55);
            this.id_equipamento.Name = "id_equipamento";
            this.id_equipamento.NM_Alias = "";
            this.id_equipamento.NM_Campo = "id_equipamento";
            this.id_equipamento.NM_CampoBusca = "id_equipamento";
            this.id_equipamento.NM_Param = "@P_CD_EMPRESA";
            this.id_equipamento.QTD_Zero = 0;
            this.id_equipamento.Size = new System.Drawing.Size(75, 20);
            this.id_equipamento.ST_AutoInc = false;
            this.id_equipamento.ST_DisableAuto = false;
            this.id_equipamento.ST_Float = false;
            this.id_equipamento.ST_Gravar = true;
            this.id_equipamento.ST_Int = true;
            this.id_equipamento.ST_LimpaCampo = true;
            this.id_equipamento.ST_NotNull = true;
            this.id_equipamento.ST_PrimaryKey = false;
            this.id_equipamento.TabIndex = 4;
            this.id_equipamento.TextOld = null;
            this.id_equipamento.Leave += new System.EventHandler(this.id_equipamento_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Equipamento:";
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(167, 29);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 3;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // dt_fin
            // 
            this.dt_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin.Location = new System.Drawing.Point(213, 3);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Operador = "";
            this.dt_fin.Size = new System.Drawing.Size(66, 20);
            this.dt_fin.ST_Gravar = true;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = true;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 1;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(90, 29);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(75, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 2;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "Empresa:";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(201, 29);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(297, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 69;
            this.nm_empresa.TextOld = null;
            // 
            // ds_equipamento
            // 
            this.ds_equipamento.BackColor = System.Drawing.SystemColors.Window;
            this.ds_equipamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_equipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_equipamento.Enabled = false;
            this.ds_equipamento.Location = new System.Drawing.Point(201, 55);
            this.ds_equipamento.Name = "ds_equipamento";
            this.ds_equipamento.NM_Alias = "";
            this.ds_equipamento.NM_Campo = "ds_equipamento";
            this.ds_equipamento.NM_CampoBusca = "ds_equipamento";
            this.ds_equipamento.NM_Param = "@P_DS_EQUIPAMENTO";
            this.ds_equipamento.QTD_Zero = 0;
            this.ds_equipamento.Size = new System.Drawing.Size(297, 20);
            this.ds_equipamento.ST_AutoInc = false;
            this.ds_equipamento.ST_DisableAuto = false;
            this.ds_equipamento.ST_Float = false;
            this.ds_equipamento.ST_Gravar = false;
            this.ds_equipamento.ST_Int = false;
            this.ds_equipamento.ST_LimpaCampo = true;
            this.ds_equipamento.ST_NotNull = false;
            this.ds_equipamento.ST_PrimaryKey = false;
            this.ds_equipamento.TabIndex = 70;
            this.ds_equipamento.TextOld = null;
            // 
            // TFRecalcCoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 125);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFRecalcCoo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recalcular COO Inicial/Final";
            this.Load += new System.EventHandler(this.TFRecalcCoo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRecalcCoo_KeyDown);
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
        private Componentes.EditDefault ds_equipamento;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_equipamento;
        private Componentes.EditData dt_ini;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault id_equipamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditData dt_fin;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label11;
    }
}