using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Commoditties
{
    public partial class TFLan_Taxa : Form
    {
        public string Nr_contrato
        { get; set; }
        public string Nr_pedido
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla_produto
        { get; set; }

        public TFLan_Taxa()
        {
            InitializeComponent();
        }

        private void TFLan_Taxa_Load(object sender, EventArgs e)
        {
            pCabecalho.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            bsTaxaDeposito.AddNew();
            nr_contrato.Text = Nr_contrato;
            nr_pedido.Text = Nr_pedido;
            cd_produto.Text = Cd_produto;
            ds_produto.Text = Ds_produto;
            sigla_unidade.Text = Sigla_produto;
            (bsTaxaDeposito.Current as CamadaDados.Graos.TRegistro_TaxaDeposito).Tp_Lancto = "M";
            bsTaxaDeposito.ResetCurrentItem();
        }

        private void bb_taxa_Click(object sender, EventArgs e)
        {
            string vColunas = "b.ds_taxa|Taxa Deposito|200;" +
                              "a.id_taxa|Id. Taxa|80;" +
                              "a.id_reg|Id. Registro|80;" +
                              "a.valortaxa|Valor Taxa|80;" +
                              "a.periodocarencia|Periodo Carencia|80;" +
                              "a.frequencia|Frequencia|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_taxa, ds_taxa, id_reg },
                                                    new CamadaDados.Graos.TCD_CadContratoTaxaDeposito(), "a.nr_contrato|=|" + nr_contrato.Text);
            if (linha != null)
            {
                vl_taxa.Enabled = linha["tp_taxa"].ToString().Trim().ToUpper().Equals("V");
                if (!vl_taxa.Enabled)
                    vl_taxa.Value = vl_taxa.Minimum;
                ps_taxa.Enabled = linha["tp_taxa"].ToString().Trim().ToUpper().Equals("P");
                if (!ps_taxa.Enabled)
                    ps_taxa.Value = ps_taxa.Minimum;
            }
        }

        private void id_taxa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.id_taxa|=|" + id_taxa.Text + ";" +
                              "a.nr_contrato|=|" + nr_contrato.Text;
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { id_taxa, ds_taxa, id_reg },
                                    new CamadaDados.Graos.TCD_CadContratoTaxaDeposito());
            if (linha != null)
            {
                vl_taxa.Enabled = linha["tp_taxa"].ToString().Trim().ToUpper().Equals("V");
                if (!vl_taxa.Enabled)
                    vl_taxa.Value = vl_taxa.Minimum;
                ps_taxa.Enabled = linha["tp_taxa"].ToString().Trim().ToUpper().Equals("P");
                if (!ps_taxa.Enabled)
                    ps_taxa.Value = ps_taxa.Minimum;
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (id_taxa.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar taxa de armazenagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_taxa.Focus();
            }
            if (dt_lancto.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data de lançamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_lancto.Focus();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFLan_Taxa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
