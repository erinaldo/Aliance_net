namespace Utils
{
    partial class TFViewImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFViewImage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bdNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.ptbImage = new System.Windows.Forms.PictureBox();
            this.lb_imagem = new System.Windows.Forms.ToolStripLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavigator)).BeginInit();
            this.bdNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bdNavigator);
            this.panel1.Controls.Add(this.ptbImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 682);
            this.panel1.TabIndex = 0;
            // 
            // bdNavigator
            // 
            this.bdNavigator.AddNewItem = null;
            this.bdNavigator.AutoSize = false;
            this.bdNavigator.BackColor = System.Drawing.Color.Gray;
            this.bdNavigator.CountItem = this.toolStripLabel2;
            this.bdNavigator.CountItemFormat = "de {0}";
            this.bdNavigator.DeleteItem = null;
            this.bdNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bdNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.toolStripTextBox2,
            this.toolStripLabel2,
            this.toolStripSeparator4,
            this.toolStripButton7,
            this.toolStripButton8,
            this.lb_imagem});
            this.bdNavigator.Location = new System.Drawing.Point(0, 645);
            this.bdNavigator.MoveFirstItem = this.toolStripButton5;
            this.bdNavigator.MoveLastItem = this.toolStripButton8;
            this.bdNavigator.MoveNextItem = this.toolStripButton7;
            this.bdNavigator.MovePreviousItem = this.toolStripButton6;
            this.bdNavigator.Name = "bdNavigator";
            this.bdNavigator.PositionItem = this.toolStripTextBox2;
            this.bdNavigator.Size = new System.Drawing.Size(1024, 37);
            this.bdNavigator.TabIndex = 30;
            this.bdNavigator.Text = "bindingNavigator2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(37, 34);
            this.toolStripLabel2.Text = "de {0}";
            this.toolStripLabel2.ToolTipText = "Total Registros";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(23, 34);
            this.toolStripButton5.Text = "Primeiro Registro";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(23, 34);
            this.toolStripButton6.Text = "Registro Anterior";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.AccessibleName = "Position";
            this.toolStripTextBox2.AutoSize = false;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox2.Text = "0";
            this.toolStripTextBox2.ToolTipText = "Registro Corrente";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.RightToLeftAutoMirrorImage = true;
            this.toolStripButton7.Size = new System.Drawing.Size(23, 34);
            this.toolStripButton7.Text = "Proximo Registro";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.RightToLeftAutoMirrorImage = true;
            this.toolStripButton8.Size = new System.Drawing.Size(23, 34);
            this.toolStripButton8.Text = "Ultimo Registro";
            // 
            // ptbImage
            // 
            this.ptbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbImage.Location = new System.Drawing.Point(0, 0);
            this.ptbImage.Name = "ptbImage";
            this.ptbImage.Size = new System.Drawing.Size(1024, 682);
            this.ptbImage.TabIndex = 0;
            this.ptbImage.TabStop = false;
            this.ptbImage.DoubleClick += new System.EventHandler(this.ptbImage_DoubleClick);
            // 
            // lb_imagem
            // 
            this.lb_imagem.ForeColor = System.Drawing.Color.Blue;
            this.lb_imagem.Name = "lb_imagem";
            this.lb_imagem.Size = new System.Drawing.Size(0, 34);
            // 
            // TFViewImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 682);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "TFViewImage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizador de IMAGENS Aliance.Net";
            this.Load += new System.EventHandler(this.TFViewImage_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdNavigator)).EndInit();
            this.bdNavigator.ResumeLayout(false);
            this.bdNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ptbImage;
        private System.Windows.Forms.BindingNavigator bdNavigator;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripLabel lb_imagem;
    }
}