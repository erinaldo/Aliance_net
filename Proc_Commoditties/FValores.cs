using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class FValores : Form
    {
        public decimal? Vl_quantidadeMin { get; set; } = null;
        public decimal? Vl_quantidadeMax { get; set; } = null;
        public decimal? Vl_quantidadeDef { get; set; } = null; //default
        public decimal? Vl_quantidadeCasaD { get; set; } = null;
        public decimal? Vl_descontoMin { get; set; } = null; //percentual ou valor
        public decimal? Vl_descontoMax { get; set; } = null;
        public decimal? Vl_descontoDef { get; set; } = null;
        public bool DescontPerc { get; set; } = true;
        public decimal? Vl_quantidadeValue { get; private set; } = null;
        public decimal? Vl_descontoValue { get; private set; } = null;

        public FValores()
        {
            InitializeComponent();
        }

        private void BB_Sair_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Enter_Click(object sender, EventArgs e)
        {
            if (validacao())
                DialogResult = DialogResult.OK;
        }

        private bool validacao()
        {
            if (Edt_quantidade.Text.Length.Equals(0) || Edt_desconto.Text.Length.Equals(0))
            {
                //MessageBox.Show("Obrigatório informar quantidade")
            }


            return true;
        }

        private void FValores_Load(object sender, EventArgs e)
        {
            if (Vl_quantidadeDef != null)
                Edt_quantidade.Text = Vl_quantidadeDef.ToString();
            if (!DescontPerc)
                rbValor.Checked = true;
            if (rbPercentual.Checked)
                Edt_desconto.Mask = "###.##";
            else
                Edt_desconto.Mask = "#.###";
            if (Vl_quantidadeCasaD != null & Vl_quantidadeCasaD.Equals(2))
                Edt_quantidade.Mask = "#.##";
        }

        private void rbPercentual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPercentual.Checked)
                Edt_desconto.Mask = "###.##";
            else
                Edt_desconto.Mask = "#.###";
        }

        private void Edt_quantidade_TextChanged(object sender, EventArgs e)
        {
            Edt_quantidade.Text = Edt_quantidade.Text.Trim();
        }

        private void Edt_desconto_TextChanged(object sender, EventArgs e)
        {
            Edt_desconto.Text = Edt_desconto.Text.Trim();
        }
    }
}
