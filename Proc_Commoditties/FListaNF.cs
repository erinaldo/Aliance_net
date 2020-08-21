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
    public partial class TFListaNF : Form
    {
        public CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lFat
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat
        {
            get
            {
                if (bsNotaFiscal.Current != null)
                    return bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento;
                else return null;
            }
        }

        public TFListaNF()
        {
            InitializeComponent();
        }

        

        private void TFListaNF_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsNotaFiscal.DataSource = lFat;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaNF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
