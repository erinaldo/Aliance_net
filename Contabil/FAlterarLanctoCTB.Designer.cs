namespace Contabil
{
    partial class TFAlterarLanctoCTB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAlterarLanctoCTB));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_complemento = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nr_docto = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dt_lancto = new Componentes.EditData(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.id_loteCTB = new Componentes.EditDefault(this.components);
            this.lblValor = new System.Windows.Forms.Label();
            this.valor = new Componentes.EditFloat(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(448, 43);
            this.barraMenu.TabIndex = 14;
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
            this.pDados.Controls.Add(this.valor);
            this.pDados.Controls.Add(this.lblValor);
            this.pDados.Controls.Add(this.ds_complemento);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.nr_docto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.dt_lancto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.id_loteCTB);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(448, 163);
            this.pDados.TabIndex = 0;
            // 
            // ds_complemento
            // 
            this.ds_complemento.BackColor = System.Drawing.SystemColors.Window;
            this.ds_complemento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_complemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_complemento.Location = new System.Drawing.Point(15, 59);
            this.ds_complemento.Multiline = true;
            this.ds_complemento.Name = "ds_complemento";
            this.ds_complemento.NM_Alias = "";
            this.ds_complemento.NM_Campo = "";
            this.ds_complemento.NM_CampoBusca = "";
            this.ds_complemento.NM_Param = "";
            this.ds_complemento.QTD_Zero = 0;
            this.ds_complemento.Size = new System.Drawing.Size(416, 89);
            this.ds_complemento.ST_AutoInc = false;
            this.ds_complemento.ST_DisableAuto = false;
            this.ds_complemento.ST_Float = false;
            this.ds_complemento.ST_Gravar = false;
            this.ds_complemento.ST_Int = false;
            this.ds_complemento.ST_LimpaCampo = true;
            this.ds_complemento.ST_NotNull = false;
            this.ds_complemento.ST_PrimaryKey = false;
            this.ds_complemento.TabIndex = 4;
            this.ds_complemento.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Complemento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nº Documento";
            // 
            // nr_docto
            // 
            this.nr_docto.BackColor = System.Drawing.SystemColors.Window;
            this.nr_docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_docto.Location = new System.Drawing.Point(227, 20);
            this.nr_docto.Name = "nr_docto";
            this.nr_docto.NM_Alias = "";
            this.nr_docto.NM_Campo = "";
            this.nr_docto.NM_CampoBusca = "";
            this.nr_docto.NM_Param = "";
            this.nr_docto.QTD_Zero = 0;
            this.nr_docto.Size = new System.Drawing.Size(97, 20);
            this.nr_docto.ST_AutoInc = false;
            this.nr_docto.ST_DisableAuto = false;
            this.nr_docto.ST_Float = false;
            this.nr_docto.ST_Gravar = false;
            this.nr_docto.ST_Int = false;
            this.nr_docto.ST_LimpaCampo = true;
            this.nr_docto.ST_NotNull = false;
            this.nr_docto.ST_PrimaryKey = false;
            this.nr_docto.TabIndex = 2;
            this.nr_docto.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dt. Lançamento";
            // 
            // dt_lancto
            // 
            this.dt_lancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_lancto.Location = new System.Drawing.Point(121, 20);
            this.dt_lancto.Mask = "00/00/0000";
            this.dt_lancto.Name = "dt_lancto";
            this.dt_lancto.NM_Alias = "";
            this.dt_lancto.NM_Campo = "";
            this.dt_lancto.NM_CampoBusca = "";
            this.dt_lancto.NM_Param = "";
            this.dt_lancto.Operador = "";
            this.dt_lancto.Size = new System.Drawing.Size(100, 20);
            this.dt_lancto.ST_Gravar = false;
            this.dt_lancto.ST_LimpaCampo = true;
            this.dt_lancto.ST_NotNull = false;
            this.dt_lancto.ST_PrimaryKey = false;
            this.dt_lancto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nº Lote CTB";
            // 
            // id_loteCTB
            // 
            this.id_loteCTB.BackColor = System.Drawing.SystemColors.Window;
            this.id_loteCTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_loteCTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_loteCTB.Enabled = false;
            this.id_loteCTB.Location = new System.Drawing.Point(15, 20);
            this.id_loteCTB.Name = "id_loteCTB";
            this.id_loteCTB.NM_Alias = "";
            this.id_loteCTB.NM_Campo = "";
            this.id_loteCTB.NM_CampoBusca = "";
            this.id_loteCTB.NM_Param = "";
            this.id_loteCTB.QTD_Zero = 0;
            this.id_loteCTB.Size = new System.Drawing.Size(100, 20);
            this.id_loteCTB.ST_AutoInc = false;
            this.id_loteCTB.ST_DisableAuto = false;
            this.id_loteCTB.ST_Float = false;
            this.id_loteCTB.ST_Gravar = false;
            this.id_loteCTB.ST_Int = false;
            this.id_loteCTB.ST_LimpaCampo = true;
            this.id_loteCTB.ST_NotNull = false;
            this.id_loteCTB.ST_PrimaryKey = false;
            this.id_loteCTB.TabIndex = 0;
            this.id_loteCTB.TextOld = null;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(327, 4);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 7;
            this.lblValor.Text = "Valor";
            // 
            // valor
            // 
            this.valor.DecimalPlaces = 2;
            this.valor.Location = new System.Drawing.Point(330, 20);
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
            this.valor.Size = new System.Drawing.Size(101, 20);
            this.valor.ST_AutoInc = false;
            this.valor.ST_DisableAuto = false;
            this.valor.ST_Gravar = false;
            this.valor.ST_LimparCampo = true;
            this.valor.ST_NotNull = false;
            this.valor.ST_PrimaryKey = false;
            this.valor.TabIndex = 3;
            this.valor.ThousandsSeparator = true;
            // 
            // TFAlterarLanctoCTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 206);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAlterarLanctoCTB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Lançamento Contabil";
            this.Load += new System.EventHandler(this.TFAlterarLanctoCTB_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAlterarLanctoCTB_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label2;
        private Componentes.EditData dt_lancto;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_loteCTB;
        private Componentes.EditDefault ds_complemento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nr_docto;
        private Componentes.EditFloat valor;
        private System.Windows.Forms.Label lblValor;
    }
}