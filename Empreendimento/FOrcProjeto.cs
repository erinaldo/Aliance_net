using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Empreendimento
{
    public partial class TFOrcProjeto : Form
    {
        private CamadaDados.Empreendimento.TRegistro_OrcProjeto rorc;
        public CamadaDados.Empreendimento.TRegistro_OrcProjeto rOrc
        {
            get
            {
                if (bsOrcProjeto.Current != null)
                    return bsOrcProjeto.Current as CamadaDados.Empreendimento.TRegistro_OrcProjeto;
                else return null;
            }
            set { rorc = value; }
        }

        public TFOrcProjeto()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFOrcProjeto_Load(object sender, EventArgs e)
        {
            obs.CharacterCasing = CharacterCasing.Normal;
            if (rorc != null)
                bsOrcProjeto.DataSource = new CamadaDados.Empreendimento.TList_OrcProjeto() { rorc };
            else bsOrcProjeto.AddNew();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFOrcProjeto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if(e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
