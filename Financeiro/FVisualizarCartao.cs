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
    public partial class TFVisualizarCartao : Form
    {
        public bool St_debito { get; set; }
        public List<CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao> lFatura
        { get; set; }

        public TFVisualizarCartao()
        {
            InitializeComponent();
        }

        private void TFVisualizarCartao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsFatura.DataSource = lFatura;
            totfaturas.Text = lFatura.Sum(p => p.Vl_Saldoquitar).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
            if (St_debito)
                this.Text = "Visualizar Faturas - DÉBITO";
            else this.Text = "Visualizar Faturas - CRÉDITO";
        }
    }
}
