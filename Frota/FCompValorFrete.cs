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
    public partial class TFCompValorFrete : Form
    {
        private CamadaDados.Faturamento.CTRC.TRegistro_CTRCompValorFrete rcomp;
        public CamadaDados.Faturamento.CTRC.TRegistro_CTRCompValorFrete rComp
        {
            get
            {
                if (bsCompValorFrete.Current != null)
                    return bsCompValorFrete.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTRCompValorFrete;
                else return null;
            }
            set { rcomp = value; }

        }

        public TFCompValorFrete()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCompValorFrete_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rcomp != null)
                bsCompValorFrete.DataSource = new CamadaDados.Faturamento.CTRC.TList_CTRCompValorFrete() { rcomp };
            else bsCompValorFrete.AddNew();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCompValorFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
