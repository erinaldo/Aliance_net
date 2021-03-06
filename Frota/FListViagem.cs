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
    public partial class TFListViagem : Form
    {
        public CamadaDados.Frota.TList_Viagem lViagem
        { get; set; }
        public CamadaDados.Frota.TRegistro_Viagem rViagem
        {
            get
            {
                if (bsViagem.Current != null)
                    return bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem;
                else
                    return null;
            }
        }


        public TFListViagem()
        {
            InitializeComponent();
        }

        private void TFListViagem_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsViagem.DataSource = lViagem;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListViagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
