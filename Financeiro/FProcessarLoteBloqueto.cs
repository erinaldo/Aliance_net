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
    public partial class TFProcessarLoteBloqueto : Form
    {
        public string Id_lote
        { get; set; }
        public string Ds_lote
        { get; set; }
        public decimal Vl_totalbloqueto
        { get; set; }
        public decimal Vl_taxa
        { get; set; }
        public DateTime? Dt_processamento
        { get; set; }

        public TFProcessarLoteBloqueto()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {

            if (Convert.ToDateTime(dt_processamento.Text) > CamadaDados.UtilData.Data_Servidor())
            {
                MessageBox.Show("Data processamento invalida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return;
            }
            try
            {
                Dt_processamento = Convert.ToDateTime(dt_processamento.Text);
            }
            catch
            {
                MessageBox.Show("Obrigatorio informar data de processamento", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_processamento.Focus();
                return;
            }
            if(vl_liquido.Value <= decimal.Zero)
                MessageBox.Show("Não existe valor de liquido informado.?",
                                "Pergunta", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (vl_taxa.Value <= decimal.Zero)
            {
                MessageBox.Show("Não existe valor de taxa informado.?",
                                "Pergunta", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Vl_taxa = vl_taxa.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFProcessarLoteBloqueto_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            id_lotebusca.Text = Id_lote;
            pDados.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            ds_lotebusca.Text = Ds_lote;
            vl_total_titulo.Value = Vl_totalbloqueto;
            vl_taxa.Value = Vl_taxa;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFProcessarLoteBloqueto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void vl_taxa_ValueChanged(object sender, EventArgs e)
        {
            vl_liquido.Value = vl_total_titulo.Value - vl_taxa.Value;
        }

        private void vl_liquido_ValueChanged(object sender, EventArgs e)
        {
            vl_taxa.Value = vl_total_titulo.Value - vl_liquido.Value;
        }
    }
}
