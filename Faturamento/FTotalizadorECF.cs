using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFTotalizadorECF : Form
    {
        private CamadaDados.Faturamento.PDV.TRegistro_TotalizadorMapa rtot;
        public CamadaDados.Faturamento.PDV.TRegistro_TotalizadorMapa rTot
        {
            get
            {
                if (bsTotalizador.Current != null)
                    return bsTotalizador.Current as CamadaDados.Faturamento.PDV.TRegistro_TotalizadorMapa;
                else
                    return null;
            }
            set { rtot = value; }
        }

        public TFTotalizadorECF()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ICMS", "IC"));
            cbx.Add(new Utils.TDataCombo("ISS", "IS"));
            tp_aliquota.DataSource = cbx;
            tp_aliquota.DisplayMember = "Display";
            tp_aliquota.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (vl_totalizador.Focused)
                    (bsTotalizador.Current as CamadaDados.Faturamento.PDV.TRegistro_TotalizadorMapa).Vl_totalizador = vl_totalizador.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFTotalizadorECF_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rtot != null)
            {
                bsTotalizador.DataSource = new CamadaDados.Faturamento.PDV.TList_TotalizadorMapa() { rtot };
                cd_totalizador.Enabled = false;
            }
            else
                bsTotalizador.AddNew();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFTotalizadorECF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
