using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Balanca
{
    public partial class TFLanFotosPesagem : Form
    {
        public bool St_capturar
        { get; set; }

        private CamadaDados.Balanca.TList_FotosPesagem lfotos;
        public CamadaDados.Balanca.TList_FotosPesagem lFotos
        {
            get
            {
                if (bsFotosPesagem.Count > 0)
                    return (bsFotosPesagem.DataSource as CamadaDados.Balanca.TList_FotosPesagem);
                else
                    return null;
            }
            set
            {
                lfotos = value;
            }
        }

        public CamadaDados.Balanca.TList_FotosPesagem lFotosExcluir
        { get; set; }

        public TFLanFotosPesagem()
        {
            InitializeComponent();
            this.St_capturar = false;
        }

        private void TFLanFotosPesagem_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (lfotos != null && lfotos.Count > 0)
                bsFotosPesagem.DataSource = lfotos;
            else
                bsFotosPesagem.AddNew();
            bb_capturar.Enabled = this.St_capturar;
            bb_excluir.Enabled = this.St_capturar;
        }

        private void bb_capturar_Click(object sender, EventArgs e)
        {
            using (WebCamLibrary.TFCapturaVideo fCap = new WebCamLibrary.TFCapturaVideo())
            {
                if (fCap.ShowDialog() == DialogResult.OK)
                {

                    pbImagem.Image = fCap.Img;
                    pbImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                    (bsFotosPesagem.Current as CamadaDados.Balanca.TRegistro_FotosPesagem).Img = Utils.Convercao_imagem.imageToByteArray(fCap.Img);
                    bsFotosPesagem.ResetCurrentItem();
                }
            }
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            if (bsFotosPesagem.Current != null)
            {
                lFotosExcluir.Add(bsFotosPesagem.Current as CamadaDados.Balanca.TRegistro_FotosPesagem);
                bsFotosPesagem.RemoveCurrent();
            }
        }
    }
}
