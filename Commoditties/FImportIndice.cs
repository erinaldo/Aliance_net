using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFImportIndice : Form
    {
        public string Cd_tabeladesconto
        { get { return CD_TabelaDesconto.Text; } }
        public string Cd_tipoamostra
        { get { return CD_TipoAmostra.Text; } }

        public TFImportIndice()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(CD_TabelaDesconto.Text))
            {
                MessageBox.Show("Obrigatorio informar tabela desconto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_TabelaDesconto.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_TipoAmostra.Text))
            {
                MessageBox.Show("Obrigatorio informar tipo amostra.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_TipoAmostra.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFImportIndice_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
        }

        private void bb_TabelaDesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TabelaDesconto|Tabela Desconto|350;" +
                              "CD_TabelaDesconto|Cód. TabDesc.|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TabelaDesconto, ds_tabelaDesconto },
                                    new CamadaDados.Graos.TCD_TabelaDesconto(), string.Empty);
        }

        private void CD_TabelaDesconto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_tabeladesconto|=|'" + CD_TabelaDesconto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_TabelaDesconto, ds_tabelaDesconto },
                                    new CamadaDados.Graos.TCD_TabelaDesconto());
        }

        private void bb_Amostra_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Amostra|Descrição Amostra|350;" +
                              "CD_TipoAmostra|Cód. Amostra|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TipoAmostra, ds_amostra },
                                    new CamadaDados.Graos.TCD_CadAmostra(), string.Empty);
        }

        private void CD_TipoAmostra_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_TipoAmostra|=|'" + CD_TipoAmostra.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_TipoAmostra, ds_amostra },
                                    new CamadaDados.Graos.TCD_CadAmostra());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFImportIndice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
