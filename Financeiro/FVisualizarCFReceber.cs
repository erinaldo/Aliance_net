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
    public partial class TFVisualizarCFReceber : Form
    {
        public CamadaDados.PostoCombustivel.TList_CartaFrete lCartaFrete
        { get; set; }

        public TFVisualizarCFReceber()
        {
            InitializeComponent();
        }

        private void TFVisualizarCFReceber_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsCartaFrete.DataSource = lCartaFrete;
            if (lCartaFrete.Count > 0)
                totReceber.Text = lCartaFrete.Sum(p => p.Vl_documento).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
        }
    }
}
