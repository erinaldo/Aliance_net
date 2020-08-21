using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Componentes
{
    public partial class TFQuantidade : Form
    {
        public int Casas_decimais
        { get; set; }
        public bool St_permitirValorZero
        { get; set; }
        public string Ds_label
        { get; set; }

        public decimal Vl_saldo
        { get; set; }
        public decimal Vl_Minimo
        { get; set; }
        public decimal Vl_default
        { get; set; }

        public decimal Quantidade
        { get { return valor.Value; } }

        public TFQuantidade()
        {
            InitializeComponent();
            Casas_decimais = 3;
            Ds_label = string.Empty;
        }

        private void Confirmar()
        {
            if (valor.Value.Equals(decimal.Zero) && !St_permitirValorZero)
            {
                MessageBox.Show("Obrigatorio informar " + Ds_label.Trim() + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valor.Focus();
                return;
            }
            if (Vl_Minimo > decimal.Zero && 
                Vl_Minimo > valor.Value)
            {
                MessageBox.Show("Valor informado não pode ser menor que valor minimo permitido<" + Vl_Minimo.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)) + ">",
                                "mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valor.Focus();
                return;
            }
            if (Vl_saldo > decimal.Zero && 
                Vl_saldo < valor.Value)
            {
                MessageBox.Show("Valor informado maior que valor permitido.\r\n" +
                                "Vl. Permitido: " + Vl_saldo.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)) + ".",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valor.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Confirmar();
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
        }

        private void TFQuantidade_Load(object sender, EventArgs e)
        {
            valor.DecimalPlaces = Casas_decimais;
            if (!string.IsNullOrEmpty(Ds_label))
                lblQtde.Text = Ds_label;
            if (Vl_default > decimal.Zero)
                valor.Value = Vl_default;
            else
                valor.Value = valor.Minimum;
            if (Vl_saldo > decimal.Zero)
            {
                lblSaldo.Visible = true;
                lblSaldo.Text = "Saldo: " + Vl_saldo.ToString("N" + Casas_decimais.ToString(), new System.Globalization.CultureInfo("pt-BR", true));
            }
            else
            {
                lblSaldo.Visible = false;
            }
        }

        private void lblCancela_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lblConfirma_Click(object sender, EventArgs e)
        {
            this.Confirmar();
        }

        private void lblConfirma_MouseEnter(object sender, EventArgs e)
        {
            lblConfirma.BorderStyle = BorderStyle.FixedSingle;
            lblConfirma.Cursor = Cursors.Hand;
            lblConfirma.ForeColor = Color.Blue;
        }

        private void lblConfirma_MouseLeave(object sender, EventArgs e)
        {
            lblConfirma.BorderStyle = BorderStyle.None;
            lblConfirma.Cursor = Cursors.Default;
            lblConfirma.ForeColor = Color.Black;
        }

        private void lblCancela_MouseEnter(object sender, EventArgs e)
        {
            lblCancela.BorderStyle = BorderStyle.FixedSingle;
            lblCancela.Cursor = Cursors.Hand;
            lblCancela.ForeColor = Color.Blue;
        }

        private void lblCancela_MouseLeave(object sender, EventArgs e)
        {
            lblCancela.BorderStyle = BorderStyle.None;
            lblCancela.Cursor = Cursors.Default;
            lblCancela.ForeColor = Color.Black;
        }
    }
}
