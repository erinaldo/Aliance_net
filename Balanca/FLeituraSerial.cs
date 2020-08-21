using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LeituraSerial;

namespace Balanca
{
    public partial class TFLeituraSerial : Form
    {
        public decimal vl_capturado = 0;
        public string Cd_protocolo = string.Empty;
        public string ds_valor = string.Empty;
        public string ds_amostra = string.Empty;

        public TFLeituraSerial()
        {
            InitializeComponent();
        }
                
        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLeituraSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                bb_capturar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());
        }

        private void bb_capturar_Click(object sender, EventArgs e)
        {
            vl_capturado = valor.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void TFLeituraSerial_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            lblValor.Text = ds_valor.Trim();
            lblAmostra.Text = "AMOSTRA: " + ds_amostra.Trim();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar protocolo
            CamadaDados.Diversos.TList_RegCadProtocolo lProtocolo = CamadaNegocio.Diversos.TCN_CadProtocolo.Busca(Cd_protocolo, string.Empty, string.Empty, null);
        }
    }
}
