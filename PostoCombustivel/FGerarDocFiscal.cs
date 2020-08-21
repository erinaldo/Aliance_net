using System;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFGerarDocFiscal : Form
    {
        public bool St_nfce { get; set; }
        public bool St_nfe { get; set; }
        public bool St_nfvinculada { get; set; }

        public TFGerarDocFiscal()
        {
            InitializeComponent();
            TopMost = true;
        }

        private void TFGerarDocFiscal_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void TFGerarDocFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F3))
            {
                St_nfce = true;
                DialogResult = DialogResult.OK;
            }
            else if(e.KeyCode.Equals(Keys.F4))
            {
                St_nfvinculada = true;
                DialogResult = DialogResult.OK;
            }
            else if(e.KeyCode.Equals(Keys.F5))
            {
                St_nfe = true;
                DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
        }

        private void bbNFCe_Click(object sender, EventArgs e)
        {
            St_nfce = true;
            DialogResult = DialogResult.OK;
        }

        private void bbNFCeComNFe_Click(object sender, EventArgs e)
        {
            St_nfvinculada = true;
            DialogResult = DialogResult.OK;
        }

        private void bbNFe_Click(object sender, EventArgs e)
        {
            St_nfe = true;
            DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
