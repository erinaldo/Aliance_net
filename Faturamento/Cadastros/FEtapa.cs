using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento.Cadastros
{
    public partial class FEtapa : Form
    {
        private CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa cEtapa;
        public CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa rEtapa
        {
            get
            {
                if (bsEtapa.Current != null)
                    return bsEtapa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa;
                else return null;
            }
            set { cEtapa = value; }
        }
        public FEtapa()
        {
            InitializeComponent();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FEtapa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (cEtapa != null)
            {
                bsEtapa.DataSource = new CamadaDados.Faturamento.Cadastros.TList_CadEtapa() { cEtapa };
            }
            else bsEtapa.AddNew();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (panelDados1.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }
    }
}
