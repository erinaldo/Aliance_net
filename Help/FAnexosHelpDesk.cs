using System;
using System.Drawing;
using System.Windows.Forms;

namespace Help
{
    public partial class TFAnexosHelpDesk : Form
    {
        public bool st_print = false;
        private string pds_anexo;
        public string pDs_anexo
        {
            get { return ds_anexo.Text; }
            set { pds_anexo = value; }
        }
        private Image img_anexo;
        public Image Img_anexo
        {
            get { return pAnexo.Image; }
            set { img_anexo = value; }
        }

        public TFAnexosHelpDesk()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_anexo.Text))
            {
                MessageBox.Show("Obrigatorio informar descrição anexo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_anexo.Focus();
                return;
            }
            if (pAnexo.Image == null)
            {
                MessageBox.Show("Obrigatorio informar imagem anexo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void bb_load_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Filter = "IMAGENS|*.jpg";
                if (file.ShowDialog() == DialogResult.OK)
                    if (System.IO.File.Exists(file.FileName))
                        pAnexo.Image = Image.FromFile(file.FileName);
            }
        }

        private void pFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFAnexosHelpDesk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.Control && e.KeyCode.Equals(Keys.V))
                pAnexo.Image = Clipboard.GetImage();
        }

        private void TFAnexosHelpDesk_Load(object sender, EventArgs e)
        {
            ds_anexo.Enabled = img_anexo == null;
            bb_load.Enabled = img_anexo == null;
            bb_gravar.Enabled = img_anexo == null;
            ds_anexo.Text = pds_anexo;
            pAnexo.Image = img_anexo;

            if (st_print)
            {
                ds_anexo.Enabled = true;
                bb_load.Enabled = true;
                bb_gravar.Enabled = true;
            }
        }

        private void tsmColar_Click(object sender, EventArgs e)
        {
            pAnexo.Image = Clipboard.GetImage();
        }
    }
}
