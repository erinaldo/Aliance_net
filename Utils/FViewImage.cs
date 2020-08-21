using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Utils;
using System.IO;

namespace Utils
{
    public partial class TFViewImage : Form
    {
        public BindingSource rImagem;

        public TFViewImage()
        {
            InitializeComponent();
            rImagem = new BindingSource();
            ptbImage.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.rImagem, "Foto_imagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            rImagem.PositionChanged += new EventHandler(rImagem_PositionChanged);
            bdNavigator.BindingSource = rImagem;
        }

        private void TFViewImage_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void ptbImage_DoubleClick(object sender, EventArgs e)
        {
            TFViewImage fImage = new TFViewImage();
            fImage.WindowState = FormWindowState.Normal;
            fImage.Top = 0;
            fImage.Left = 0;
            fImage.Width = Screen.PrimaryScreen.Bounds.Width;
            fImage.Height = Screen.PrimaryScreen.Bounds.Height;
        }

        private void rImagem_PositionChanged(object sender, EventArgs e)
        {
            if (rImagem.Current != null)
            {
                //lb_imagem.Text = 

            }
        }
    }
}
