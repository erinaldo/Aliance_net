using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFPlacaConvenio : Form
    {
        private CamadaDados.PostoCombustivel.TRegistro_Convenio_Placa rplaca;
        public CamadaDados.PostoCombustivel.TRegistro_Convenio_Placa rPlaca
        {
            get
            {
                if (bsPlacaConvenio.Count > 0)
                    return bsPlacaConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Placa;
                else
                    return null;
            }
            set { rplaca = value; }
        }

        public TFPlacaConvenio()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFPlacaConvenio_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if(rplaca != null)
            {
                bsPlacaConvenio.DataSource = new CamadaDados.PostoCombustivel.TList_Convenio_Placa(){rplaca};
                placa.Enabled = false;
                ds_veiculo.Focus();
            }
            else
            {
                bsPlacaConvenio.AddNew();
                placa.Focus();
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

        private void TFPlacaConvenio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }
    }
}
