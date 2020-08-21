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
    public partial class TFVisualizaCheques : Form
    {
        public bool St_emitido { get; set; }
        public List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo> lCh
        { get; set; }

        public TFVisualizaCheques()
        {
            InitializeComponent();
        }

        private void TFVisualizaCheques_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsTitulo.DataSource = lCh;
            totcheques.Text = lCh.Sum(p => p.Vl_titulo).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
            if (St_emitido)
                this.Text = "Visualizar Cheques - EMITIDOS";
            else this.Text = "Visualizar Cheques - RECEBIDOS";
        }
    }
}
