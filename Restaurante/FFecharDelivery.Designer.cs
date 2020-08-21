namespace Restaurante
{
    partial class TFFecharDelivery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFFecharDelivery));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.checkBoxDefault2 = new Componentes.CheckBoxDefault(this.components);
            this.bsPreVenda = new System.Windows.Forms.BindingSource(this.components);
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.tot = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.editData1 = new Componentes.EditData(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.a_pagar = new Componentes.EditFloat(this.components);
            this.checkBoxDefault1 = new Componentes.CheckBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPreVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_pagar)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar,
            this.toolStripSeparator1,
            this.toolStripButton3});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(491, 43);
            this.barraMenu.TabIndex = 13;
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
            this.bb_inutilizar.ToolTipText = "Gravar";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.toolStripButton3.ForeColor = System.Drawing.Color.Green;
            this.toolStripButton3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(80, 40);
            this.toolStripButton3.Text = "(F8)\r\nMapa";
            this.toolStripButton3.ToolTipText = "Concluir o orcamento";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.checkBoxDefault2);
            this.panelDados1.Controls.Add(this.editDefault1);
            this.panelDados1.Controls.Add(this.tot);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.editData1);
            this.panelDados1.Controls.Add(this.richTextBox1);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.a_pagar);
            this.panelDados1.Controls.Add(this.checkBoxDefault1);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(491, 213);
            this.panelDados1.TabIndex = 14;
            // 
            // checkBoxDefault2
            // 
            this.checkBoxDefault2.AutoSize = true;
            this.checkBoxDefault2.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPreVenda, "bool_clientetira", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxDefault2.Location = new System.Drawing.Point(242, 25);
            this.checkBoxDefault2.Name = "checkBoxDefault2";
            this.checkBoxDefault2.NM_Alias = "";
            this.checkBoxDefault2.NM_Campo = "";
            this.checkBoxDefault2.NM_Param = "";
            this.checkBoxDefault2.Size = new System.Drawing.Size(116, 17);
            this.checkBoxDefault2.ST_Gravar = false;
            this.checkBoxDefault2.ST_LimparCampo = true;
            this.checkBoxDefault2.ST_NotNull = false;
            this.checkBoxDefault2.TabIndex = 70;
            this.checkBoxDefault2.Text = "Cliente vem buscar";
            this.checkBoxDefault2.UseVisualStyleBackColor = true;
            this.checkBoxDefault2.Vl_False = "";
            this.checkBoxDefault2.Vl_True = "";
            // 
            // bsPreVenda
            // 
            this.bsPreVenda.DataSource = typeof(CamadaDados.Restaurante.TList_PreVenda);
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(219, 65);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(96, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 69;
            this.editDefault1.TextOld = null;
            // 
            // tot
            // 
            this.tot.BackColor = System.Drawing.SystemColors.Window;
            this.tot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tot.Enabled = false;
            this.tot.Location = new System.Drawing.Point(15, 66);
            this.tot.Name = "tot";
            this.tot.NM_Alias = "";
            this.tot.NM_Campo = "";
            this.tot.NM_CampoBusca = "";
            this.tot.NM_Param = "";
            this.tot.QTD_Zero = 0;
            this.tot.Size = new System.Drawing.Size(96, 20);
            this.tot.ST_AutoInc = false;
            this.tot.ST_DisableAuto = false;
            this.tot.ST_Float = false;
            this.tot.ST_Gravar = false;
            this.tot.ST_Int = false;
            this.tot.ST_LimpaCampo = true;
            this.tot.ST_NotNull = false;
            this.tot.ST_PrimaryKey = false;
            this.tot.TabIndex = 68;
            this.tot.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Total Pedido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "Levar";
            // 
            // editData1
            // 
            this.editData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editData1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "Dt_dataentrega", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editData1.Location = new System.Drawing.Point(15, 25);
            this.editData1.Mask = "00/00/0000 90:00";
            this.editData1.Name = "editData1";
            this.editData1.NM_Alias = "";
            this.editData1.NM_Campo = "Data e hora";
            this.editData1.NM_CampoBusca = "Data e hora";
            this.editData1.NM_Param = "@P_DATA E HORA";
            this.editData1.Operador = "";
            this.editData1.Size = new System.Drawing.Size(100, 20);
            this.editData1.ST_Gravar = true;
            this.editData1.ST_LimpaCampo = true;
            this.editData1.ST_NotNull = true;
            this.editData1.ST_PrimaryKey = false;
            this.editData1.TabIndex = 63;
            this.editData1.ValidatingType = typeof(System.DateTime);
            // 
            // richTextBox1
            // 
            this.richTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "ObsFecharDelivery", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.richTextBox1.Location = new System.Drawing.Point(7, 105);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(472, 100);
            this.richTextBox1.TabIndex = 62;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Observação";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Troco para";
            // 
            // a_pagar
            // 
            this.a_pagar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPreVenda, "Vl_TrocoPara", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.a_pagar.DecimalPlaces = 2;
            this.a_pagar.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.a_pagar.Location = new System.Drawing.Point(117, 66);
            this.a_pagar.Maximum = new decimal(new int[] {
            -1693413832,
            2069,
            0,
            0});
            this.a_pagar.Name = "a_pagar";
            this.a_pagar.NM_Alias = "";
            this.a_pagar.NM_Campo = "";
            this.a_pagar.NM_Param = "";
            this.a_pagar.Operador = "";
            this.a_pagar.Size = new System.Drawing.Size(96, 20);
            this.a_pagar.ST_AutoInc = false;
            this.a_pagar.ST_DisableAuto = false;
            this.a_pagar.ST_Gravar = false;
            this.a_pagar.ST_LimparCampo = true;
            this.a_pagar.ST_NotNull = false;
            this.a_pagar.ST_PrimaryKey = false;
            this.a_pagar.TabIndex = 59;
            this.a_pagar.ThousandsSeparator = true;
            this.a_pagar.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.a_pagar.Leave += new System.EventHandler(this.editFloat1_Leave);
            // 
            // checkBoxDefault1
            // 
            this.checkBoxDefault1.AutoSize = true;
            this.checkBoxDefault1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPreVenda, "St_levarcartaobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxDefault1.Location = new System.Drawing.Point(121, 25);
            this.checkBoxDefault1.Name = "checkBoxDefault1";
            this.checkBoxDefault1.NM_Alias = "";
            this.checkBoxDefault1.NM_Campo = "";
            this.checkBoxDefault1.NM_Param = "";
            this.checkBoxDefault1.Size = new System.Drawing.Size(115, 17);
            this.checkBoxDefault1.ST_Gravar = false;
            this.checkBoxDefault1.ST_LimparCampo = true;
            this.checkBoxDefault1.ST_NotNull = false;
            this.checkBoxDefault1.TabIndex = 58;
            this.checkBoxDefault1.Text = "Maquina de cartão";
            this.checkBoxDefault1.UseVisualStyleBackColor = true;
            this.checkBoxDefault1.Vl_False = "";
            this.checkBoxDefault1.Vl_True = "";
            this.checkBoxDefault1.CheckedChanged += new System.EventHandler(this.checkBoxDefault1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Data e Hora prevista para entrega";
            // 
            // TFFecharDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 256);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFFecharDelivery";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fechar pedido delivery";
            this.Load += new System.EventHandler(this.FApontarDelivery_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FApontarDelivery_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPreVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_pagar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingSource bsPreVenda;
        private System.Windows.Forms.Label label2;
        private Componentes.CheckBoxDefault checkBoxDefault1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat a_pagar;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private Componentes.EditData editData1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault tot;
        private Componentes.EditDefault editDefault1;
        private Componentes.CheckBoxDefault checkBoxDefault2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}