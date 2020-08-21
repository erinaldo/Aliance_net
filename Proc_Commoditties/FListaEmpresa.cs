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
    public partial class TFListaEmpresa : Form
    {
        public CamadaDados.Diversos.TList_CadEmpresa lEmp
        { get; set; }
        public CamadaDados.Diversos.TRegistro_CadEmpresa rEmp
        {
            get
            {
                if (bsEmpresa.Current != null)
                    return bsEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa;
                else return null;
            }
        }

        public TFListaEmpresa()
        {
            InitializeComponent();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFListaEmpresa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsEmpresa.DataSource = lEmp;
        }

        private void gEmpresa_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
