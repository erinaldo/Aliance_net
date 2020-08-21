using System;
using System.Drawing;
using System.Windows.Forms;

namespace WebCamLibrary
{
    public partial class TFVisualizarCaptura : Form
    {
        private Image imagem;
        public Image Imagem
        {
            get { return imagem; }
            set { imagem = value; }
        }
        private byte[] img;
        public byte[] Img
        {
            get
            {
                if (imagem != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
                else
                    return img;
            }
            set
            {
                img = value;
                if (value != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    ms.Write(value, 0, value.Length);
                    imagem = Image.FromStream(ms);
                }
            }
        }

        public TFVisualizarCaptura()
        {
            InitializeComponent();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            pImagens.Image = null;
            Imagem = null;
            Img = null;
        }

        private void bb_capturar_Click(object sender, EventArgs e)
        {
                using (TFCapturaVideo fCap = new TFCapturaVideo())
                {
                    if (fCap.ShowDialog() == DialogResult.OK)
                    {

                        pImagens.Image = fCap.Img;

                        pImagens.SizeMode = PictureBoxSizeMode.StretchImage;
                        Img = Utils.Convercao_imagem.imageToByteArray(pImagens.Image);
                    }
                }
            
        }

        private void bb_localizar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "IMAGENS|*.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                    if (System.IO.File.Exists(ofd.FileName))
                    {
                        Imagem = Image.FromFile(ofd.FileName);
                    }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar imagem: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            FCadCliForImage_Load(this, new EventArgs());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {    
            DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FCadCliForImage_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
                if(Img != null)
                    pImagens.Image = Imagem;
        }
    }
}
