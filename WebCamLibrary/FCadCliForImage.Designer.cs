namespace WebCamLibrary
{
    partial class TFVisualizarCaptura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFVisualizarCaptura));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bnImagens = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bb_capturar = new System.Windows.Forms.ToolStripButton();
            this.bb_localizar = new System.Windows.Forms.ToolStripButton();
            this.pImagens = new System.Windows.Forms.PictureBox();
            this.bsClifor = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnImagens)).BeginInit();
            this.bnImagens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pImagens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClifor)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar,
            this.toolStripSeparator2});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(652, 43);
            this.barraMenu.TabIndex = 537;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bnImagens);
            this.panel1.Controls.Add(this.pImagens);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 338);
            this.panel1.TabIndex = 538;
            // 
            // bnImagens
            // 
            this.bnImagens.AddNewItem = null;
            this.bnImagens.CountItem = null;
            this.bnImagens.CountItemFormat = "de {0}";
            this.bnImagens.DeleteItem = null;
            this.bnImagens.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnImagens.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.bindingNavigatorDeleteItem,
            this.bb_capturar,
            this.bb_localizar});
            this.bnImagens.Location = new System.Drawing.Point(0, 313);
            this.bnImagens.MoveFirstItem = null;
            this.bnImagens.MoveLastItem = null;
            this.bnImagens.MoveNextItem = null;
            this.bnImagens.MovePreviousItem = null;
            this.bnImagens.Name = "bnImagens";
            this.bnImagens.PositionItem = null;
            this.bnImagens.Size = new System.Drawing.Size(652, 25);
            this.bnImagens.TabIndex = 3;
            this.bnImagens.Text = "bindingNavigator2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(108, 22);
            this.bindingNavigatorDeleteItem.Text = "Excluir Imagem";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bb_capturar
            // 
            this.bb_capturar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_capturar.Image = ((System.Drawing.Image)(resources.GetObject("bb_capturar.Image")));
            this.bb_capturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_capturar.Name = "bb_capturar";
            this.bb_capturar.Size = new System.Drawing.Size(104, 22);
            this.bb_capturar.Text = "Capturar Imagem";
            this.bb_capturar.Click += new System.EventHandler(this.bb_capturar_Click);
            // 
            // bb_localizar
            // 
            this.bb_localizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_localizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_localizar.Image")));
            this.bb_localizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_localizar.Name = "bb_localizar";
            this.bb_localizar.Size = new System.Drawing.Size(104, 22);
            this.bb_localizar.Text = "Localizar Imagem";
            this.bb_localizar.Click += new System.EventHandler(this.bb_localizar_Click);
            // 
            // pImagens
            // 
            this.pImagens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImagens.Location = new System.Drawing.Point(0, 0);
            this.pImagens.Name = "pImagens";
            this.pImagens.Size = new System.Drawing.Size(652, 338);
            this.pImagens.TabIndex = 0;
            this.pImagens.TabStop = false;
            // 
            // bsClifor
            // 
            this.bsClifor.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadClifor);
            // 
            // TFVisualizarCaptura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 381);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barraMenu);
            this.Name = "TFVisualizarCaptura";
            this.Text = "Visualizar Captura";
            this.Load += new System.EventHandler(this.FCadCliForImage_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnImagens)).EndInit();
            this.bnImagens.ResumeLayout(false);
            this.bnImagens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pImagens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClifor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pImagens;
        private System.Windows.Forms.BindingNavigator bnImagens;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bb_capturar;
        private System.Windows.Forms.ToolStripButton bb_localizar;
        private System.Windows.Forms.BindingSource bsClifor;
    }
}