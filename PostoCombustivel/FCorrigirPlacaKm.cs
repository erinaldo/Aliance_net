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
    public partial class TFCorrigirPlacaKm : Form
    {
        public TFCorrigirPlacaKm()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(placa.Text.Replace("-", "").Trim()))
            {
                MessageBox.Show("Obrigatorio informar placa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                placa.Focus();
                return;
            }
            bsVendaCombustivel.DataSource = CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Buscar(string.Empty,
                                                                                                       CD_Empresa.Text,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       dt_ini.Text,
                                                                                                       dt_fin.Text,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       false,
                                                                                                       string.Empty,
                                                                                                       placa.Text,
                                                                                                       "a.dt_abastecimento desc",
                                                                                                       null);
        }

        private void afterGrava()
        {
            if(bsVendaCombustivel.Current != null)
                try
                {
                    CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel, null);
                    MessageBox.Show("Placa/KM corrigido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFCorrigirPlacaKm_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gAbastecimento);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, nm_empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, nm_empresa });
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFCorrigirPlacaKm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void PlacaVeic_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void TFCorrigirPlacaKm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gAbastecimento);
        }
    }
}
