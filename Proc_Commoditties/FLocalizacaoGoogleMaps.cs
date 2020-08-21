using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class FLocalizacaoGoogleMaps : Form
    {
        public string pDestino { get; set; } = string.Empty;
        public string pOrigem { get; set; } = string.Empty;

        private ObjectMap cObjectMap = new ObjectMap();
        public ObjectMap rObjectMap
        {
            get
            {
                return cObjectMap;
            }set
            {
                cObjectMap = value;
            }
        }

        public FLocalizacaoGoogleMaps()
        {
            InitializeComponent();
        }

        private void FLocalizacaoGoogleMaps_Load(object sender, EventArgs e)
        {
            if (cObjectMap == null)
                cObjectMap = new ObjectMap();

            cObjectMap.pDestino = pDestino;
            cObjectMap.pOrigem = pOrigem;

            Navigate nav = new Navigate();
            cObjectMap = nav.BuscarLocalizacao(pOrigem, pDestino);
            cObjectMap.pDestino = pDestino;
            cObjectMap.pOrigem = pOrigem;
            editDefault1.Text = cObjectMap.distancia;
            editDefault2.Text = cObjectMap.duracao;
            if(!string.IsNullOrEmpty(cObjectMap.distancia) && !string.IsNullOrEmpty(cObjectMap.duracao) )
            webBrowser1.Navigate(string.Format(cObjectMap.web_browser_navigate, cObjectMap.pOrigem, cObjectMap.pDestino));

        }

        private void FLocalizacaoGoogleMaps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
