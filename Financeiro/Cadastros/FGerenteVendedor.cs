using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFGerenteVendedor : Form
    {
        public string Cd_gerente
        { get; set; }
        public CamadaDados.Faturamento.Cadastros.TList_Gerente_X_Vendedor lGerente
        { get; set; }
        public TFGerenteVendedor()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (pc_comissao.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Informe a % Comissão!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                lGerente = new CamadaDados.Faturamento.Cadastros.TList_Gerente_X_Vendedor();
                using (TFListVendedor fVend = new TFListVendedor())
                {
                    if (fVend.ShowDialog() == DialogResult.OK)
                        if (fVend.lVendedor != null)
                            fVend.lVendedor.ForEach(p =>
                                lGerente.Add(new CamadaDados.Faturamento.Cadastros.TRegistro_Gerente_X_Vendedor()
                                {
                                    Cd_empresa = cd_empresa.Text,
                                    Cd_gerente = Cd_gerente,
                                    Cd_vendedor = p.Cd_clifor,
                                    Pc_comissao = pc_comissao.Value
                                }));
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFGerenteVendedor_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFGerenteVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }
    }
}
