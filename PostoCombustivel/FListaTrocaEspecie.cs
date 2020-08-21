using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFListaTrocaEspecie : Form
    {
        public string Id_caixa
        { get; set; }

        public CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie rTroca
        {
            get
            {
                if (bsTrocaEspecie.Current != null)
                    return bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie;
                else return null;
            }
        }

        public TFListaTrocaEspecie()
        {
            InitializeComponent();
        }

        private void TFListaTrocaEspecie_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsTrocaEspecie.DataSource = CamadaNegocio.Faturamento.PDV.TCN_TrocaEspecie.Buscar(string.Empty,
                                                                                              string.Empty,
                                                                                              Id_caixa,
                                                                                              null);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaTrocaEspecie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
