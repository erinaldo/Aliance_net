using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel.Cadastros
{
    public partial class TFCadLacre : Form
    {
        private CamadaDados.PostoCombustivel.Cadastros.TRegistro_LacreBomba rlacre;
        public CamadaDados.PostoCombustivel.Cadastros.TRegistro_LacreBomba rLacre
        {
            get
            {
                if (bsLacre.Current != null)
                    return bsLacre.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_LacreBomba;
                else
                    return null;
            }
            set { rlacre = value; }
        }

        public TFCadLacre()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pLacre.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCadLacre_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rlacre != null)
                bsLacre.DataSource = new CamadaDados.PostoCombustivel.Cadastros.TList_LacreBomba() { rlacre };
            else
                bsLacre.AddNew();
            nr_lacre.Focus();
        }

        private void TFCadLacre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
