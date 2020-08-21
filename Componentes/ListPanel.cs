using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Componentes
{
    public partial class ListPanel : Panel
    {
        private string Texto;
        public string NM_Campo { get { if (Texto == null) return ""; else return Texto; } set { set_vNM_Campo(value); } }

        private Image img;
        public Image Img { get { if (img == null) return null; else return img; } set { set_Image(value); } }

        private ImageLayout imgLayout;
        public ImageLayout ImgLayout { get { if (imgLayout.Equals(ImageLayout.None)) return ImageLayout.None; else return imgLayout; } set { set_ImageLayout(value); } }
        public ListPanel()
        {
            InitializeComponent();
        }

        private void set_vNM_Campo(string value)
        {
            Texto = value.ToUpper().Trim();
            if (!string.IsNullOrEmpty(Texto))
                label.Text = Texto;
        }

        private void set_Image(Image value)
        {
            img = value;
            if (img != null)
                pictureBox.BackgroundImage = img;
        }

        private void set_ImageLayout(ImageLayout value)
        {
            imgLayout = value;
            pictureBox.BackgroundImageLayout = imgLayout;
        }

        public ListPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void _MouseEnter(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Cursor = Cursors.Hand;
            this.ForeColor = Color.Blue;
        }

        private void _MouseLeave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Default;
            this.ForeColor = Color.Black;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        private void label_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
