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
    public partial class TFCadModeloNotaFiscal : Form
    {
        private CamadaDados.Faturamento.Cadastros.TRegistro_CadModeloNF cModelo;
        public CamadaDados.Faturamento.Cadastros.TRegistro_CadModeloNF rModelo
        {
            get
            {
                if (bsModeloNF.Current != null)
                    return bsModeloNF.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadModeloNF;
                else return null;
            }
            set { rModelo = value; }
        }
        public TFCadModeloNotaFiscal()
        {
            InitializeComponent();
        }
       
        private void FCadModeloNotaFiscal_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rModelo != null)
            {
                bsModeloNF.DataSource = new CamadaDados.Faturamento.Cadastros.TList_CadModeloNF() { rModelo };
                cd_modelo.Enabled = false;
                ds_modelo.Enabled = false;
            }
            else bsModeloNF.AddNew();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            (bsModeloNF.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadModeloNF).DS_Modelo = ds_modelo.Text;

            if (panelDados1.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCadModeloNotaFiscal_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                bb_inutilizar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
