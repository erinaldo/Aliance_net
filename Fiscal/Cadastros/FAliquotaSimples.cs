using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fiscal.Cadastros
{
    public partial class TFAliquotaSimples : Form
    {
        private CamadaDados.Fiscal.TRegistro_AliquotaSimples raliq;
        public CamadaDados.Fiscal.TRegistro_AliquotaSimples rAliq
        {
            get
            {
                if (bsAliq.Current != null)
                    return bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples;
                else return null;
            }
            set { raliq = value; }
        }

        public TFAliquotaSimples()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_aliquota.Text))
            {
                MessageBox.Show("Obrigatório informar descrição aliquota.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_aliquota.Focus();
                return;
            }
            if (pc_aliquota.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar % aliquota.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pc_aliquota.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFAliquotaSimples_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (raliq != null)
                bsAliq.DataSource = new CamadaDados.Fiscal.TList_AliquotaSimples() { raliq };
            else bsAliq.AddNew();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAliquotaSimples_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
