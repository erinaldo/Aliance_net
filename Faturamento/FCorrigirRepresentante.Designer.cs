namespace Faturamento
{
    partial class TFCorrigirRepresentante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCorrigirRepresentante));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.pc_comrep = new Componentes.EditFloat(this.components);
            this.label38 = new System.Windows.Forms.Label();
            this.nm_representante = new Componentes.EditDefault(this.components);
            this.bb_representante = new System.Windows.Forms.Button();
            this.cd_representante = new Componentes.EditDefault(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.nm_gerente = new Componentes.EditDefault(this.components);
            this.bb_gerente = new System.Windows.Forms.Button();
            this.cd_gerente = new Componentes.EditDefault(this.components);
            this.label37 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.cd_cliforind = new Componentes.EditDefault(this.components);
            this.nm_cliforind = new Componentes.EditDefault(this.components);
            this.bb_cliforind = new System.Windows.Forms.Button();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_comrep)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(615, 43);
            this.barraMenu.TabIndex = 9;
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
            this.pDados.Controls.Add(this.nm_gerente);
            this.pDados.Controls.Add(this.bb_gerente);
            this.pDados.Controls.Add(this.cd_gerente);
            this.pDados.Controls.Add(this.label37);
            this.pDados.Controls.Add(this.label26);
            this.pDados.Controls.Add(this.cd_cliforind);
            this.pDados.Controls.Add(this.nm_cliforind);
            this.pDados.Controls.Add(this.bb_cliforind);
            this.pDados.Controls.Add(this.pc_comrep);
            this.pDados.Controls.Add(this.label38);
            this.pDados.Controls.Add(this.nm_representante);
            this.pDados.Controls.Add(this.bb_representante);
            this.pDados.Controls.Add(this.cd_representante);
            this.pDados.Controls.Add(this.label21);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(615, 129);
            this.pDados.TabIndex = 0;
            // 
            // pc_comrep
            // 
            this.pc_comrep.DecimalPlaces = 5;
            this.pc_comrep.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pc_comrep.Location = new System.Drawing.Point(523, 23);
            this.pc_comrep.Name = "pc_comrep";
            this.pc_comrep.NM_Alias = "";
            this.pc_comrep.NM_Campo = "";
            this.pc_comrep.NM_Param = "";
            this.pc_comrep.Operador = "";
            this.pc_comrep.Size = new System.Drawing.Size(84, 20);
            this.pc_comrep.ST_AutoInc = false;
            this.pc_comrep.ST_DisableAuto = false;
            this.pc_comrep.ST_Gravar = true;
            this.pc_comrep.ST_LimparCampo = true;
            this.pc_comrep.ST_NotNull = false;
            this.pc_comrep.ST_PrimaryKey = false;
            this.pc_comrep.TabIndex = 2;
            this.pc_comrep.ThousandsSeparator = true;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(520, 5);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(73, 13);
            this.label38.TabIndex = 564;
            this.label38.Text = "% Comissão";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nm_representante
            // 
            this.nm_representante.BackColor = System.Drawing.SystemColors.Window;
            this.nm_representante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_representante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_representante.Enabled = false;
            this.nm_representante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_representante.Location = new System.Drawing.Point(131, 22);
            this.nm_representante.Name = "nm_representante";
            this.nm_representante.NM_Alias = "";
            this.nm_representante.NM_Campo = "NM_Clifor";
            this.nm_representante.NM_CampoBusca = "NM_Clifor";
            this.nm_representante.NM_Param = "@P_NM_CLIFOR";
            this.nm_representante.QTD_Zero = 0;
            this.nm_representante.Size = new System.Drawing.Size(386, 20);
            this.nm_representante.ST_AutoInc = false;
            this.nm_representante.ST_DisableAuto = false;
            this.nm_representante.ST_Float = false;
            this.nm_representante.ST_Gravar = true;
            this.nm_representante.ST_Int = false;
            this.nm_representante.ST_LimpaCampo = true;
            this.nm_representante.ST_NotNull = false;
            this.nm_representante.ST_PrimaryKey = false;
            this.nm_representante.TabIndex = 563;
            this.nm_representante.TextOld = null;
            // 
            // bb_representante
            // 
            this.bb_representante.Image = ((System.Drawing.Image)(resources.GetObject("bb_representante.Image")));
            this.bb_representante.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_representante.Location = new System.Drawing.Point(100, 22);
            this.bb_representante.Name = "bb_representante";
            this.bb_representante.Size = new System.Drawing.Size(28, 19);
            this.bb_representante.TabIndex = 1;
            this.bb_representante.UseVisualStyleBackColor = true;
            this.bb_representante.Click += new System.EventHandler(this.bb_representante_Click);
            // 
            // cd_representante
            // 
            this.cd_representante.BackColor = System.Drawing.SystemColors.Window;
            this.cd_representante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_representante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_representante.Location = new System.Drawing.Point(9, 21);
            this.cd_representante.Name = "cd_representante";
            this.cd_representante.NM_Alias = "";
            this.cd_representante.NM_Campo = "cd_clifor";
            this.cd_representante.NM_CampoBusca = "cd_clifor";
            this.cd_representante.NM_Param = "@P_CD_CLIFOR";
            this.cd_representante.QTD_Zero = 0;
            this.cd_representante.Size = new System.Drawing.Size(87, 20);
            this.cd_representante.ST_AutoInc = false;
            this.cd_representante.ST_DisableAuto = false;
            this.cd_representante.ST_Float = false;
            this.cd_representante.ST_Gravar = false;
            this.cd_representante.ST_Int = false;
            this.cd_representante.ST_LimpaCampo = true;
            this.cd_representante.ST_NotNull = false;
            this.cd_representante.ST_PrimaryKey = false;
            this.cd_representante.TabIndex = 0;
            this.cd_representante.TextOld = null;
            this.cd_representante.Leave += new System.EventHandler(this.cd_representante_Leave);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(6, 5);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 13);
            this.label21.TabIndex = 562;
            this.label21.Text = "Representante";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nm_gerente
            // 
            this.nm_gerente.BackColor = System.Drawing.SystemColors.Window;
            this.nm_gerente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_gerente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_gerente.Enabled = false;
            this.nm_gerente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_gerente.Location = new System.Drawing.Point(133, 99);
            this.nm_gerente.Name = "nm_gerente";
            this.nm_gerente.NM_Alias = "";
            this.nm_gerente.NM_Campo = "NM_Clifor";
            this.nm_gerente.NM_CampoBusca = "NM_Clifor";
            this.nm_gerente.NM_Param = "@P_NM_CLIFOR";
            this.nm_gerente.QTD_Zero = 0;
            this.nm_gerente.Size = new System.Drawing.Size(474, 20);
            this.nm_gerente.ST_AutoInc = false;
            this.nm_gerente.ST_DisableAuto = false;
            this.nm_gerente.ST_Float = false;
            this.nm_gerente.ST_Gravar = true;
            this.nm_gerente.ST_Int = false;
            this.nm_gerente.ST_LimpaCampo = true;
            this.nm_gerente.ST_NotNull = false;
            this.nm_gerente.ST_PrimaryKey = false;
            this.nm_gerente.TabIndex = 573;
            this.nm_gerente.TextOld = null;
            // 
            // bb_gerente
            // 
            this.bb_gerente.Image = ((System.Drawing.Image)(resources.GetObject("bb_gerente.Image")));
            this.bb_gerente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_gerente.Location = new System.Drawing.Point(102, 99);
            this.bb_gerente.Name = "bb_gerente";
            this.bb_gerente.Size = new System.Drawing.Size(28, 19);
            this.bb_gerente.TabIndex = 6;
            this.bb_gerente.UseVisualStyleBackColor = true;
            this.bb_gerente.Click += new System.EventHandler(this.bb_gerente_Click);
            // 
            // cd_gerente
            // 
            this.cd_gerente.BackColor = System.Drawing.SystemColors.Window;
            this.cd_gerente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_gerente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_gerente.Location = new System.Drawing.Point(9, 99);
            this.cd_gerente.Name = "cd_gerente";
            this.cd_gerente.NM_Alias = "";
            this.cd_gerente.NM_Campo = "cd_clifor";
            this.cd_gerente.NM_CampoBusca = "cd_clifor";
            this.cd_gerente.NM_Param = "@P_CD_CLIFOR";
            this.cd_gerente.QTD_Zero = 0;
            this.cd_gerente.Size = new System.Drawing.Size(87, 20);
            this.cd_gerente.ST_AutoInc = false;
            this.cd_gerente.ST_DisableAuto = false;
            this.cd_gerente.ST_Float = false;
            this.cd_gerente.ST_Gravar = false;
            this.cd_gerente.ST_Int = false;
            this.cd_gerente.ST_LimpaCampo = true;
            this.cd_gerente.ST_NotNull = false;
            this.cd_gerente.ST_PrimaryKey = false;
            this.cd_gerente.TabIndex = 5;
            this.cd_gerente.TextOld = null;
            this.cd_gerente.Leave += new System.EventHandler(this.cd_gerente_Leave);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(6, 83);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(45, 13);
            this.label37.TabIndex = 572;
            this.label37.Text = "Gerente";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(6, 44);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(54, 13);
            this.label26.TabIndex = 568;
            this.label26.Text = "Indicação";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_cliforind
            // 
            this.cd_cliforind.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cliforind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_cliforind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cliforind.Location = new System.Drawing.Point(9, 60);
            this.cd_cliforind.Name = "cd_cliforind";
            this.cd_cliforind.NM_Alias = "";
            this.cd_cliforind.NM_Campo = "cd_clifor";
            this.cd_cliforind.NM_CampoBusca = "cd_clifor";
            this.cd_cliforind.NM_Param = "@P_CD_CLIFOR";
            this.cd_cliforind.QTD_Zero = 0;
            this.cd_cliforind.Size = new System.Drawing.Size(87, 20);
            this.cd_cliforind.ST_AutoInc = false;
            this.cd_cliforind.ST_DisableAuto = false;
            this.cd_cliforind.ST_Float = false;
            this.cd_cliforind.ST_Gravar = false;
            this.cd_cliforind.ST_Int = false;
            this.cd_cliforind.ST_LimpaCampo = true;
            this.cd_cliforind.ST_NotNull = false;
            this.cd_cliforind.ST_PrimaryKey = false;
            this.cd_cliforind.TabIndex = 3;
            this.cd_cliforind.TextOld = null;
            this.cd_cliforind.Leave += new System.EventHandler(this.cd_cliforind_Leave);
            // 
            // nm_cliforind
            // 
            this.nm_cliforind.BackColor = System.Drawing.SystemColors.Window;
            this.nm_cliforind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_cliforind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_cliforind.Enabled = false;
            this.nm_cliforind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_cliforind.Location = new System.Drawing.Point(131, 61);
            this.nm_cliforind.Name = "nm_cliforind";
            this.nm_cliforind.NM_Alias = "";
            this.nm_cliforind.NM_Campo = "NM_Clifor";
            this.nm_cliforind.NM_CampoBusca = "NM_Clifor";
            this.nm_cliforind.NM_Param = "@P_NM_CLIFOR";
            this.nm_cliforind.QTD_Zero = 0;
            this.nm_cliforind.Size = new System.Drawing.Size(476, 20);
            this.nm_cliforind.ST_AutoInc = false;
            this.nm_cliforind.ST_DisableAuto = false;
            this.nm_cliforind.ST_Float = false;
            this.nm_cliforind.ST_Gravar = true;
            this.nm_cliforind.ST_Int = false;
            this.nm_cliforind.ST_LimpaCampo = true;
            this.nm_cliforind.ST_NotNull = false;
            this.nm_cliforind.ST_PrimaryKey = false;
            this.nm_cliforind.TabIndex = 569;
            this.nm_cliforind.TextOld = null;
            // 
            // bb_cliforind
            // 
            this.bb_cliforind.Image = ((System.Drawing.Image)(resources.GetObject("bb_cliforind.Image")));
            this.bb_cliforind.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_cliforind.Location = new System.Drawing.Point(100, 61);
            this.bb_cliforind.Name = "bb_cliforind";
            this.bb_cliforind.Size = new System.Drawing.Size(28, 19);
            this.bb_cliforind.TabIndex = 4;
            this.bb_cliforind.UseVisualStyleBackColor = true;
            this.bb_cliforind.Click += new System.EventHandler(this.bb_cliforind_Click);
            // 
            // TFCorrigirRepresentante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 172);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCorrigirRepresentante";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corrigir Dados Representante";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCorrigirRepresentante_FormClosing);
            this.Load += new System.EventHandler(this.TFCorrigirRepresentante_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCorrigirRepresentante_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_comrep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditFloat pc_comrep;
        private System.Windows.Forms.Label label38;
        private Componentes.EditDefault nm_representante;
        private System.Windows.Forms.Button bb_representante;
        private Componentes.EditDefault cd_representante;
        private System.Windows.Forms.Label label21;
        private Componentes.EditDefault nm_gerente;
        private System.Windows.Forms.Button bb_gerente;
        private Componentes.EditDefault cd_gerente;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label26;
        private Componentes.EditDefault cd_cliforind;
        private Componentes.EditDefault nm_cliforind;
        private System.Windows.Forms.Button bb_cliforind;
    }
}