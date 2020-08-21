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
    public partial class TFCCustoLancto : Form
    {
        public CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto rLancto
        {
            get 
            {
                if (bsCCusto.Current != null)
                    return bsCCusto.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto;
                else return null;
            }
        }
        public TFCCustoLancto()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (this.pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCCustoLancto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            this.bsCCusto.AddNew();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_ccusto_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResultado fBusca = new FormBusca.TFBuscaCentroResultado())
            {
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_ccusto.Text = fBusca.Cd_centro;
                        ds_ccusto.Text = fBusca.Ds_centro;
                        tp_movimento.Text = fBusca.Tipo_registro;
                    }
            }
        }

        private void cd_ccusto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_ccusto.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S'";

            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_ccusto, ds_ccusto },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
            if (linha != null)
                tp_movimento.Text = linha["TP_Registro"].ToString().Trim().ToUpper().Equals("R") ? "RECEITA" : "DESPESA";
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCCustoLancto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_orcamento_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Orcamento|Nº Orçamento|80;" +
                              "a.NM_Clifor|Cliente|150;" +
                              "a.DT_Orcamento|Dt. Orçamento|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_orcamento },
                new CamadaDados.Faturamento.Orcamento.TCD_Orcamento(), "isnull(a.st_registro, 'AB')|<>|'CA'");
        }

        private void nr_orcamento_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.nr_orcamento|=|" + nr_orcamento.Text + ";isnull(a.st_registro, 'AB')|<>|'CA'",
                new Componentes.EditDefault[] { nr_orcamento },
                new CamadaDados.Faturamento.Orcamento.TCD_Orcamento());
        }
    }
}
