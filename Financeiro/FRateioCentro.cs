using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.CCustoLan;
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
    public partial class TFRateioCentro : Form
    {
        private TList_LanCCustoLancto lccusto;
        public TList_LanCCustoLancto lCCusto
        {
            get
            {
                if (bsCResultado.Count > 0)
                    return bsCResultado.DataSource as TList_LanCCustoLancto;
                else
                    return null;
            }
            set { lccusto = value; }
        }
        public decimal vVl_Documento
        { get; set; }
        public TFRateioCentro()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            if (Math.Round(vl_saldovalor.Value, 2) > decimal.Zero)
            {
                MessageBox.Show("Ainda existe saldo a ratear!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (vl_rateiocc.Focused)
                if (!ValorRateio())
                {
                    MessageBox.Show("Valor rateio não pode ser maior que saldo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            if (pc_rateiocc.Focused)
                if (!PcRateio())
                {
                    MessageBox.Show("Percentual rateio não pode ser maior que saldo percentual.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            DialogResult = DialogResult.OK;
        }

        private bool PcRateio()
        {
            bool retorno = true;
            (bsCResultado.Current as TRegistro_LanCCustoLancto).Pc_lancto = pc_rateiocc.Value;
            if (Math.Round((bsCResultado.List as TList_LanCCustoLancto).Sum(p => p.Pc_lancto), 2) > 100)
            {
                pc_rateiocc.Value = 100 - pc_total.Value;
                pc_rateiocc.Focus();
                retorno = false;
            }
            vl_rateiocc.Value = vl_documento.Value * pc_rateiocc.Value / 100;
            vl_total.Value = (bsCResultado.List as TList_LanCCustoLancto).Sum(p => p.Vl_lancto);
            return retorno;
        }

        private bool ValorRateio()
        {
            bool retorno = true;
            (bsCResultado.Current as TRegistro_LanCCustoLancto).Vl_lancto = vl_rateiocc.Value;
            if ((bsCResultado.List as TList_LanCCustoLancto).Sum(p => p.Vl_lancto) > vl_documento.Value)
            {
                vl_rateiocc.Value = vl_saldovalor.Value;
                vl_rateiocc.Focus();
                retorno = false;
            }
            if (vl_documento.Value > 0)
                pc_rateiocc.Value = vl_rateiocc.Value * 100 / vl_documento.Value;
            vl_total.Value = (bsCResultado.List as TList_LanCCustoLancto).Sum(p => p.Vl_lancto);
            return retorno;
        }

        private void TFRateioCentro_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            vl_rateiocc.Enabled = true;
            pc_rateiocc.Enabled = true;
            bsCResultado.DataSource = lccusto;
            vl_documento.Value = this.vVl_Documento;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFRateioCentro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
        }

        private void TFRateioCentro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Math.Round(vl_saldovalor.Value, 2) > decimal.Zero)
            {
                MessageBox.Show("Obrigatório informar rateio para lançar CENTRO RESULTADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private void vl_rateiocc_Leave(object sender, EventArgs e)
        {
            if (!ValorRateio())
                MessageBox.Show("Valor rateio não pode ser maior que saldo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pc_rateiocc_Leave(object sender, EventArgs e)
        {
            if (!PcRateio())
                MessageBox.Show("Percentual rateio não pode ser maior que saldo percentual.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void vl_documento_ValueChanged(object sender, EventArgs e)
        {
            vl_saldovalor.Value = vl_documento.Value - vl_total.Value;
            if (vl_documento.Value > 0)
            {
                pc_total.Value = vl_total.Value * 100 / vl_documento.Value;
                pc_total.Value = 100 - pc_total.Value;
            }
        }

        private void vl_total_ValueChanged(object sender, EventArgs e)
        {
            vl_saldovalor.Value = vl_documento.Value - vl_total.Value;
            if (vl_documento.Value > 0)
            {
                pc_total.Value = vl_total.Value * 100 / vl_documento.Value;
                pc_total.Value = 100 - pc_total.Value;
            }
        }
    }
}
