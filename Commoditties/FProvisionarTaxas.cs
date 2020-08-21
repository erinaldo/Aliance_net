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
    public partial class TFProvisionarTaxas : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nr_contrato
        { get; set; }
        public string Cd_produto
        { get; set; }
        public DateTime? Dt_prevista
        { get; set; }

        public TFProvisionarTaxas()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
            this.Nr_contrato = string.Empty;
            this.Cd_produto = string.Empty;
            this.Dt_prevista = null;
        }

        private void TotalizarTaxas()
        {
            if (bsTaxaRealizar.Count > 0)
            {
                total_peso.Value = (bsTaxaRealizar.DataSource as CamadaDados.Graos.TList_TaxaDeposito).Sum(p => p.Ps_Taxa);
                total_valor.Value = (bsTaxaRealizar.DataSource as CamadaDados.Graos.TList_TaxaDeposito).Sum(p => p.Vl_Taxa);
            }
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(id_taxa.Text))
            {
                MessageBox.Show("Obrigatorio informar taxa para provisionar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_taxa.Focus();
                return;
            }
            bsTaxaRealizar.DataSource = 
                CamadaNegocio.Graos.TCN_MovDeposito.CalcularTaxasExpedicaoPendentes(Cd_empresa,
                                                                                    Nr_contrato,
                                                                                    Cd_produto,
                                                                                    Dt_prevista.Value,
                                                                                    id_taxa.Text);
            this.BuscarTaxasProvisionadas();
            this.TotalizarTaxas();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(id_taxa.Text))
            {
                MessageBox.Show("Obrigatorio informar taxa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_taxa.Focus();
                return;
            }
            if (tp_taxa.Text.Trim().ToUpper().Equals("P") && peso_faturar.Value.Equals(0))
            {
                MessageBox.Show("Obrigatorio informar peso taxa para provisionar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                peso_faturar.Focus();
                return;
            }
            if (tp_taxa.Text.Trim().ToUpper().Equals("V") && valor_faturar.Value.Equals(0))
            {
                MessageBox.Show("Obrigatorio informar valor taxa para provisionar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valor_faturar.Focus();
                return;
            }
            if (bsTaxaRealizar.Count.Equals(0))
            {
                MessageBox.Show("Não existe taxas para provisionar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CamadaDados.Graos.TRegistro_TaxaDeposito rTaxa = bsTaxaRealizar.Current as CamadaDados.Graos.TRegistro_TaxaDeposito;
                rTaxa.Vl_Taxa = valor_faturar.Value;
                rTaxa.Ps_Taxa = peso_faturar.Value;
                rTaxa.Tp_Lancto = "P";
                CamadaNegocio.Graos.TCN_LanTaxas_Deposito.Gravar(rTaxa, null);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarTaxasProvisionadas()
        {
            CamadaDados.Graos.TList_TaxaDeposito lTaxa = 
                CamadaNegocio.Graos.TCN_LanTaxas_Deposito.BuscarTx(Nr_contrato,
                                                                   "'P'",
                                                                   null);
            ps_provisionado.Value = lTaxa.Sum(p => p.Ps_Taxa);
            vl_provisionado.Value = lTaxa.Sum(p => p.Vl_Taxa);
        }

        private void bb_taxa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Taxa|Taxa Deposito|200;" +
                              "a.id_taxa|Id. Taxa|80;" +
                              "a.tp_taxa|TP. Taxa|80";
            string vParam = "|exists|(select 1 from TB_GRO_Contrato_TaxaDeposito x " +
                            "           where x.id_taxa = a.id_taxa " +
                            "           and x.nr_contrato = " + Nr_contrato + " " +
                            "           and x.st_gerartxsomente = 'E')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_taxa, ds_taxa, tp_taxa },
                                            new CamadaDados.Graos.TCD_CadTaxaDeposito(), vParam);
            peso_faturar.Enabled = tp_taxa.Text.Trim().ToUpper().Equals("P");
            valor_faturar.Enabled = tp_taxa.Text.Trim().ToUpper().Equals("V");
        }

        private void id_taxa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_taxa|=|" + id_taxa.Text + ";" +
                            "|exists|(select 1 from TB_GRO_Contrato_TaxaDeposito x " +
                            "           where x.id_taxa = a.id_taxa " +
                            "           and x.nr_contrato = " + Nr_contrato + " " +
                            "           and x.st_gerartxsomente = 'E')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_taxa, ds_taxa, tp_taxa },
                                            new CamadaDados.Graos.TCD_CadTaxaDeposito());
            peso_faturar.Enabled = tp_taxa.Text.Trim().ToUpper().Equals("P");
            valor_faturar.Enabled = tp_taxa.Text.Trim().ToUpper().Equals("V");
        }

        private void TFProvisionarTaxas_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gTaxaRealizar);
            pTotal.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            Nr_Contrato.Text = this.Nr_contrato;
            cd_produto.Text = this.Cd_produto;
            dt_prevista.Text = this.Dt_prevista.Value.ToString();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void peso_faturar_ValueChanged(object sender, EventArgs e)
        {
            if (peso_faturar.Value > ps_provisionar.Value)
                peso_faturar.Value = ps_provisionar.Value;
        }

        private void valor_faturar_ValueChanged(object sender, EventArgs e)
        {
            if (valor_faturar.Value > vl_provisionar.Value)
                valor_faturar.Value = vl_provisionar.Value;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFProvisionarTaxas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void total_peso_ValueChanged(object sender, EventArgs e)
        {
            ps_provisionar.Value = total_peso.Value - ps_provisionado.Value;
        }

        private void ps_provisionado_ValueChanged(object sender, EventArgs e)
        {
            ps_provisionar.Value = total_peso.Value - ps_provisionado.Value;
        }

        private void total_valor_ValueChanged(object sender, EventArgs e)
        {
            vl_provisionar.Value = total_valor.Value - vl_provisionado.Value;
        }

        private void vl_provisionado_ValueChanged(object sender, EventArgs e)
        {
            vl_provisionar.Value = total_valor.Value - vl_provisionado.Value;
        }

        private void TFProvisionarTaxas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gTaxaRealizar);
        }
    }
}
