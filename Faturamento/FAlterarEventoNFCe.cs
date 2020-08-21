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
    public partial class TFAlterarEventoNFCe : Form
    {
        private CamadaDados.Faturamento.PDV.TRegistro_EventoNFCe revento;
        public CamadaDados.Faturamento.PDV.TRegistro_EventoNFCe rEvento
        {
            get
            {
                if (bsEvento.Current != null)
                    return bsEvento.Current as CamadaDados.Faturamento.PDV.TRegistro_EventoNFCe;
                else return null;
            }
            set { revento = value; }
        }

        public TFAlterarEventoNFCe()
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

        private void TFAlterarEventoNFCe_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsEvento.DataSource = new CamadaDados.Faturamento.PDV.TList_EventoNFCe() { revento };
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAlterarEventoNFCe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
