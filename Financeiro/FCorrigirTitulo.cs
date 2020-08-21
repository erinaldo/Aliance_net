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
    public partial class TFCorrigirTitulo : Form
    {
        public CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rTitulo
        { get; set; }

        public TFCorrigirTitulo()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio() && pValores.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCorrigirTitulo_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsTitulo.DataSource = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo() { rTitulo };
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCorrigirTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { NM_Clifor }, string.Empty);
        }

        private void bb_clifor_nominal_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_clifor_nominal }, string.Empty);
        }
    }
}
