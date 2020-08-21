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
    public partial class TFAutorizRetDeposito : Form
    {
        private CamadaDados.Graos.TRegistro_AutorizRetDeposito rautoriz;
        public CamadaDados.Graos.TRegistro_AutorizRetDeposito rAutoriz
        {
            get
            {
                if (bsAutoriz.Current != null)
                    return bsAutoriz.Current as CamadaDados.Graos.TRegistro_AutorizRetDeposito;
                else
                    return null;
            }
            set
            { rautoriz = value; }
        }

        public TFAutorizRetDeposito()
        {
            InitializeComponent();
        }

        private decimal SaldoContrato()
        {
            if ((!string.IsNullOrEmpty(nr_Contrato.Text)) &&
                (!string.IsNullOrEmpty(cd_produto.Text)))
            {
                CamadaDados.Balanca.TRegistro_SaldoSinteticoPedido lSaldo =
                    new CamadaDados.Balanca.TCD_PedidoAplicacao().BuscaSaldoFiscal(nr_Contrato.Text,
                                                                                   cd_produto.Text);
                return lSaldo.Quantidade_Fiscal_E - lSaldo.Quantidade_Fiscal_S;
            }
            else return decimal.Zero;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFAutorizRetDeposito_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            if (this.rautoriz != null)
                bsAutoriz.Add(rautoriz);
            else
                bsAutoriz.AddNew();
            nr_Contrato.Focus();
        }

        private void bb_contrato_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[]{nr_Contrato,
                                                                                                          cd_empresa,
                                                                                                          nm_empresa,
                                                                                                          cd_clifor,
                                                                                                          nm_clifor,
                                                                                                          cd_produto,
                                                                                                          ds_produto},
                                                                            "a.tp_movimento|=|'E';" +
                                                                            "isnull(a.st_registro, 'A')|=|'A';" +
                                                                            "isnull(cfgped.st_deposito, 'N')|=|'S'");
            if (linha != null)
            {
                cd_unidproduto.Text = linha["cd_unid_produto"].ToString();
                sg_produto.Text = linha["sigla_unid_produto"].ToString();
            }
            qtd_saldocontrato.Value = this.SaldoContrato();
        }

        private void nr_Contrato_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_contrato|=|" + nr_Contrato.Text + ";" +
                            "a.tp_movimento|=|'E';" +
                            "isnull(a.st_registro, 'A')|=|'A';" +
                            "isnull(cfgped.st_deposito, 'N')|=|'S'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_Contrato, cd_empresa, nm_empresa, cd_clifor, nm_clifor, cd_produto, ds_produto },
                                                                new CamadaDados.Graos.TCD_CadContrato());
            if (linha != null)
            {
                cd_unidproduto.Text = linha["cd_unid_produto"].ToString();
                sg_produto.Text = linha["sigla_unid_produto"].ToString();
            }
            qtd_saldocontrato.Value = this.SaldoContrato();
        }

        private void bb_unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_unidade|Unidade Medida|200;" +
                              "a.cd_unidade|Cd. Unidade|80;" +
                              "a.sigla_unidade|Sigla|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_unidade, ds_unidade, sigla_unidvalor},
                                            new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), string.Empty);
        }

        private void cd_unidade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_unidade|=|'" + cd_unidade.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_unidade, ds_unidade, sigla_unidvalor },
                                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAutorizRetDeposito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void qtd_retirar_Leave(object sender, EventArgs e)
        {
            decimal saldo = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(cd_unidproduto.Text, cd_unidade.Text, SaldoContrato(), 3, null);
            if (saldo > 0)
                if (qtd_retirar.Value > saldo)
                {
                    MessageBox.Show("Quantidade a retirar não pode ser maior que saldo do contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    qtd_retirar.Value = saldo;
                    qtd_retirar.Focus();
                }
        }
    }
}
