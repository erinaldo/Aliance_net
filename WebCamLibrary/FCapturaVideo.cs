using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WebCamLibrary
{
    public partial class TFCapturaVideo : Form
    {
        AForge.Video.DirectShow.VideoCaptureDevice videoSource;

        public Image Img
        { get { return pbImagem.Image; } }

        public TFCapturaVideo()
        {
            InitializeComponent();
            AForge.Video.DirectShow.FilterInfoCollection videosources = new AForge.Video.DirectShow.FilterInfoCollection(AForge.Video.DirectShow.FilterCategory.VideoInputDevice);
            if (videosources != null)
            {
                videoSource = new AForge.Video.DirectShow.VideoCaptureDevice(videosources[0].MonikerString);
                videoSource.NewFrame += (s, e) => pbImagem.Image = (Bitmap)e.Frame.Clone();
                videoSource.Start();
            }
        }

        private void capturarImagem()
        {
            pbImagem.Image.Save("snapshot.png", System.Drawing.Imaging.ImageFormat.Png);    
        }

        private void SalvarImagem()
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.SalvarImagem();
        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            this.capturarImagem();
        }

        private void TFCapturaVideo_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void TFCapturaVideo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.SalvarImagem();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F3))
                toolStripButton1_Click(this,new EventArgs());
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                bbCaptura.Text = " (F3)\n Nova Cap.";
            }
            else
            {
                videoSource.Start();
                bbCaptura.Text = " (F3)\n Capturar";
            }

        }
    }
}
