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
    public partial class TFAlterarEventoNFe : Form
    {
        private CamadaDados.Faturamento.NFE.TRegistro_EventoNFe revento;
        public CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rEvento
        {
            get
            {
                if (bsEventoNFe.Current != null)
                    return bsEventoNFe.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe;
                else return null;
            }
            set { revento = value; }
        }

        public TFAlterarEventoNFe()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_evento.Text))
            {
                MessageBox.Show("Obrigatorio informar descrição evento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_evento.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFAlterarEventoNFe_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsEventoNFe.DataSource = new CamadaDados.Faturamento.NFE.TList_EventoNFe() { revento };
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAlterarEventoNFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
