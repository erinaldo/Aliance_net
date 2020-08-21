using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Locacao
{
    public partial class TFOutrasDesp : Form
    {
        public CamadaDados.Locacao.TRegistro_OutrasDesp rDesp
        {
            get
            {
                if (bsOutrasDesp.Current != null)
                    return bsOutrasDesp.Current as CamadaDados.Locacao.TRegistro_OutrasDesp;
                else
                    return null;
            }
        }
        public TFOutrasDesp()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void TFOutrasDesp_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsOutrasDesp.AddNew();
        }

        private void TFOutrasDesp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
