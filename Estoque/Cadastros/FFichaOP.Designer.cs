namespace Estoque.Cadastros
{
    partial class TFFichaOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFFichaOP));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_item = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.quantidade = new Componentes.EditFloat(this.components);
            this.diasprevisao = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tp_item = new Componentes.ComboBoxDefault(this.components);
            this.bsFichaOP = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasprevisao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaOP)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(560, 43);
            this.barraMenu.TabIndex = 4;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.tp_item);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.diasprevisao);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.quantidade);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.ds_item);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(560, 96);
            this.panelDados1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Ficha";
            // 
            // ds_item
            // 
            this.ds_item.BackColor = System.Drawing.SystemColors.Window;
            this.ds_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_item.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_item.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaOP, "Ds_item", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_item.Location = new System.Drawing.Point(12, 23);
            this.ds_item.Name = "ds_item";
            this.ds_item.NM_Alias = "";
            this.ds_item.NM_Campo = "";
            this.ds_item.NM_CampoBusca = "";
            this.ds_item.NM_Param = "";
            this.ds_item.QTD_Zero = 0;
            this.ds_item.Size = new System.Drawing.Size(536, 20);
            this.ds_item.ST_AutoInc = false;
            this.ds_item.ST_DisableAuto = false;
            this.ds_item.ST_Float = false;
            this.ds_item.ST_Gravar = false;
            this.ds_item.ST_Int = false;
            this.ds_item.ST_LimpaCampo = true;
            this.ds_item.ST_NotNull = false;
            this.ds_item.ST_PrimaryKey = false;
            this.ds_item.TabIndex = 0;
            this.ds_item.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantidade";
            // 
            // quantidade
            // 
            this.quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaOP, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"));
            this.quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.quantidade.Location = new System.Drawing.Point(12, 62);
            this.quantidade.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.quantidade.Name = "quantidade";
            this.quantidade.NM_Alias = "";
            this.quantidade.NM_Campo = "";
            this.quantidade.NM_Param = "";
            this.quantidade.Operador = "";
            this.quantidade.Size = new System.Drawing.Size(53, 20);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = false;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = false;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 1;
            this.quantidade.ThousandsSeparator = true;
            this.quantidade.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // diasprevisao
            // 
            this.diasprevisao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaOP, "DiasPrevisao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.diasprevisao.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.diasprevisao.Location = new System.Drawing.Point(71, 62);
            this.diasprevisao.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.diasprevisao.Name = "diasprevisao";
            this.diasprevisao.NM_Alias = "";
            this.diasprevisao.NM_Campo = "";
            this.diasprevisao.NM_Param = "";
            this.diasprevisao.Operador = "";
            this.diasprevisao.Size = new System.Drawing.Size(53, 20);
            this.diasprevisao.ST_AutoInc = false;
            this.diasprevisao.ST_DisableAuto = false;
            this.diasprevisao.ST_Gravar = false;
            this.diasprevisao.ST_LimparCampo = true;
            this.diasprevisao.ST_NotNull = false;
            this.diasprevisao.ST_PrimaryKey = false;
            this.diasprevisao.TabIndex = 2;
            this.diasprevisao.ThousandsSeparator = true;
            this.diasprevisao.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Prev. Produzir";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dias";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tipo Item";
            // 
            // tp_item
            // 
            this.tp_item.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsFichaOP, "Tp_item", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_item.FormattingEnabled = true;
            this.tp_item.Location = new System.Drawing.Point(174, 62);
            this.tp_item.Name = "tp_item";
            this.tp_item.NM_Alias = "";
            this.tp_item.NM_Campo = "";
            this.tp_item.NM_Param = "";
            this.tp_item.Size = new System.Drawing.Size(160, 21);
            this.tp_item.ST_Gravar = false;
            this.tp_item.ST_LimparCampo = true;
            this.tp_item.ST_NotNull = false;
            this.tp_item.TabIndex = 3;
            // 
            // bsFichaOP
            // 
            this.bsFichaOP.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_FichaOP);
            // 
            // TFFichaOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 139);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFFichaOP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ficha ordem Produção";
            this.Load += new System.EventHandler(this.TFFichaOP_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFFichaOP_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasprevisao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaOP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.ComboBoxDefault tp_item;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat diasprevisao;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat quantidade;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_item;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsFichaOP;
    }
}