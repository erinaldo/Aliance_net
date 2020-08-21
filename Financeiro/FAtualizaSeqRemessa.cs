using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFAtualizaSeqRemessa : Form
    {
        public string pId_config
        { get; set; }
        public string pDs_config
        { get; set; }
        public decimal pNr_seqatual
        { get; set; }
        public decimal Nr_seqremessa
        { get { return decimal.Parse(nr_seqremessa.Text); } }

        public TFAtualizaSeqRemessa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(nr_seqremessa.Text))
            {
                MessageBox.Show("Obrigatório informar Sequencial para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_seqremessa.Focus();
                return;
            }
            if (new CamadaDados.Financeiro.Bloqueto.TCD_LoteRemessa().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.id_config",
                        vOperador = "=",
                        vVL_Busca = id_config.Text
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.nr_arqremessa",
                        vOperador = "=",
                        vVL_Busca = nr_seqremessa.Text
                    }
                }, "1") != null)
            {
                MessageBox.Show("Numero sequencial já esta sendo utilizado por outro lote de remessa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAtualizaSeqRemessa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            id_config.Text = pId_config;
            cfgboleto.Text = pDs_config;
            nr_seqatual.Text = pNr_seqatual.ToString();
        }

        private void TFAtualizaSeqRemessa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
