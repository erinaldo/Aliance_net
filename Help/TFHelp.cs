using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.ConfigGer;
namespace Utils
{
    public partial class TFHelp : Form
    {
       
       string filehelp { get; set; }
        
        public TFHelp(string FileHelp)
        {
            InitializeComponent();
            filehelp = FileHelp;
            this.ShowDialog();
        }

        private void TFHelp_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            try
            {
                string URL_Dominio = string.Empty;
                string URL_Documento = string.Empty;
                string URL = string.Empty;

                URL_Dominio = TCN_CadParamGer.BuscaVlString("URL_HELP", null).ToLower();
                URL_Documento = filehelp + ".htm";

                if (URL_Dominio != "")
                {


                    string url =  URL_Dominio + URL_Documento;
                    wbHelp.Url = new System.Uri(url.Trim());

                }
                else
                {
                    MessageBox.Show("Parâmetro da url do help não existente : \r\n\r\n");
                    this.Dispose();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Chamar o HELP: \r\n\r\n" + ex.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }
        
    }
}
