using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFCadPremioSeguro : Form
    {
        private CamadaDados.Frota.Cadastros.TRegistro_CadSeguroPremios rpremio;
        public CamadaDados.Frota.Cadastros.TRegistro_CadSeguroPremios rPremio
        {
            get
            {
                if (bsPremioSeguro.Current != null)
                    return bsPremioSeguro.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroPremios;
                else return null;
            }
            set
            { rpremio = value; }
        }

        public TFCadPremioSeguro()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCadPremioSeguro_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rpremio != null)
            {
                bsPremioSeguro.DataSource = new CamadaDados.Frota.Cadastros.TList_CadSeguroPremios() { rpremio };
            }
            else
            {
                bsPremioSeguro.AddNew();
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCadPremioSeguro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
