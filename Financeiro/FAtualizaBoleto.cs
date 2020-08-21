using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Financeiro
{
    public partial class TFAtualizaBoleto : Form
    {

        public CamadaDados.Financeiro.Bloqueto.blTitulo rBloqueto
        { get; set; }
        public DateTime pDt_atualizada
        { get { return DateTime.Parse(dt_atualizada.Text); } }
        public decimal pVl_multacalc
        { get { return vl_multacalc.Value; } }
        public decimal pVl_jurocalc
        { get { return vl_jurocalc.Value; } }

        public TFAtualizaBoleto()
        {
            InitializeComponent();
        }

        private bool CalcAtualizacao()
        {
            if (string.IsNullOrEmpty(dt_atualizada.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatorio informar data atualizada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_atualizada.Focus();
                return false;
            }
            if (DateTime.Parse(dt_atualizada.Text).Date < DateTime.Parse(dt_vencto.Text).Date)
            {
                MessageBox.Show("Data atualizada não pode ser menor que data vencimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_atualizada.Focus();
                return false;
            }
            if (DateTime.Parse(dt_atualizada.Text).Date < CamadaDados.UtilData.Data_Servidor().Date)
            {
                MessageBox.Show("Data atualizada não pode ser menor que data atual.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_atualizada.Focus();
                return false;
            }
            //Calcular Multa
            if (rBloqueto.Pc_multa > decimal.Zero)
                if (rBloqueto.Dt_vencimento.Value.AddDays(Convert.ToDouble(rBloqueto.Nr_diasmulta)).Date < DateTime.Parse(dt_atualizada.Text).Date)
                    vl_multacalc.Value = Math.Round(rBloqueto.Tp_multa.Trim().ToUpper().Equals("P") ? ((rBloqueto.Vl_documento * rBloqueto.Pc_multa) / 100) : rBloqueto.Pc_multa, 2);
            //Calcular Juro
            if ((rBloqueto.Pc_jurodia > decimal.Zero) && (rBloqueto.Dt_vencimento.Value.Date < DateTime.Parse(dt_atualizada.Text).Date))
                vl_jurocalc.Value = Math.Round((rBloqueto.Tp_jurodia.Trim().ToUpper().Equals("P") ? ((rBloqueto.Vl_documento * rBloqueto.Pc_jurodia) / 100) : rBloqueto.Pc_jurodia), 2) *
                                        DateTime.Parse(dt_atualizada.Text).Subtract(rBloqueto.Dt_vencimento.Value).Days;
            return true;
        }

        private void afterGrava()
        {
            if (dt_atualizada.Focused)
            {
                if (this.CalcAtualizacao())
                    this.DialogResult = DialogResult.OK;
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        private void TFAtualizaBoleto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsBoleto.DataSource = new CamadaDados.Financeiro.Bloqueto.blListaTitulo() { rBloqueto };
        }

        private void dt_atualizada_Leave(object sender, EventArgs e)
        {
            this.CalcAtualizacao();
        }

        private void vl_multacalc_ValueChanged(object sender, EventArgs e)
        {
            vl_atualizado.Value = vl_documento.Value + vl_multacalc.Value + vl_jurocalc.Value;
        }

        private void vl_jurocalc_ValueChanged(object sender, EventArgs e)
        {
            vl_atualizado.Value = vl_documento.Value + vl_multacalc.Value + vl_jurocalc.Value;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFAtualizaBoleto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }
    }
}
