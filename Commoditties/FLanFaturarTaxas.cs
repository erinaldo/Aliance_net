using System;
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
    public partial class TFLanFaturarTaxas : Form
    {
        public string Nr_contrato
        { get; set; }
        public string Nr_pedido
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Tp_taxa
        {
            get
            {
                if (st_percentual.Checked)
                    return "P";
                else
                    return "V";
            }
        }

        public List<CamadaDados.Graos.TRegistro_TaxaDeposito> lTaxas
        {
            get
            {
                if (bsTaxas.Count > 0)
                    return (bsTaxas.DataSource as CamadaDados.Graos.TList_TaxaDeposito).FindAll(p => p.St_faturar);
                else
                    return null;
            }
        }

        public TFLanFaturarTaxas()
        {
            InitializeComponent();
        }

        private void TotalizarTaxas()
        {
            if (bsTaxas.Count > 0)
            {
                total_peso.Value = (bsTaxas.DataSource as CamadaDados.Graos.TList_TaxaDeposito).Sum(p => p.Ps_Taxa);
                total_valor.Value = (bsTaxas.DataSource as CamadaDados.Graos.TList_TaxaDeposito).Sum(p => p.Vl_Taxa);
                peso_faturar.Value = (bsTaxas.DataSource as CamadaDados.Graos.TList_TaxaDeposito).Where(p => p.St_faturar).Sum(p => p.Ps_Taxa);
                valor_faturar.Value = (bsTaxas.DataSource as CamadaDados.Graos.TList_TaxaDeposito).Where(p => p.St_faturar).Sum(p => p.Vl_Taxa);
            }
        }
        
        private void afterBusca()
        {
            bsTaxas.DataSource = new CamadaDados.Graos.TCD_LanTaxaDeposito().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.Id_taxa",
                        vOperador = "=",
                        vVL_Busca = (string.IsNullOrEmpty(id_taxa.Text) ? "a.id_taxa" : id_taxa.Text)
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.nr_contrato",
                        vOperador = "=",
                        vVL_Busca = Nr_Contrato.Text
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.nr_pedido",
                        vOperador = "=",
                        vVL_Busca = nr_pedido.Text
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + cd_produto.Text.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'P'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "b.tp_taxa",
                        vOperador = "=",
                        vVL_Busca = st_percentual.Checked ? "'P'" : "'V'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.DT_Lancto",
                        vOperador = dt_inicial.Text.Trim().Equals("/  /") ? "=" : ">=",
                        vVL_Busca = dt_inicial.Text.Trim().Equals("/  /") ? "a.DT_Lancto" :
                        "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_inicial.Text).ToString("yyyyMMdd")) + " 00:00:00'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.DT_Lancto",
                        vOperador = dt_final.Text.Trim().Equals("/  /") ? "=" : "<=",
                        vVL_Busca = dt_final.Text.Trim().Equals("/  /") ? "a.DT_Lancto" :
                        "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_final.Text).ToString("yyyyMMdd")) + " 23:59:59'"
                    }
                }, 0, string.Empty);
            this.TotalizarTaxas();
        }

        private void TFLanFaturarTaxas_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gAnalitico);
            pTpTaxa.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pTotais.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            Nr_Contrato.Text = this.Nr_contrato;
            nr_pedido.Text = this.Nr_pedido;
            cd_produto.Text = this.Cd_produto;
            this.afterBusca();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void st_marcatodos_Click(object sender, EventArgs e)
        {
            if (bsTaxas.Count > 0)
            {
                (bsTaxas.DataSource as CamadaDados.Graos.TList_TaxaDeposito).ForEach(p => p.St_faturar = st_marcatodos.Checked);
                bsTaxas.ResetBindings(true);
                this.TotalizarTaxas();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFLanFaturarTaxas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gAnalitico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsTaxas.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsTaxas.Current as CamadaDados.Graos.TRegistro_TaxaDeposito).St_faturar =
                        !(bsTaxas.Current as CamadaDados.Graos.TRegistro_TaxaDeposito).St_faturar;
                    bsTaxas.ResetCurrentItem();
                    this.TotalizarTaxas();
                }
        }

        private void bb_taxa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_taxa|Taxa Deposito|200;" +
                              "a.id_taxa|Id. Taxa|80";
            string vParam = "a.tp_taxa|=|" + (st_valor.Checked ? "'V'" : "'P'");
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_taxa, ds_taxa },
                                    new CamadaDados.Graos.TCD_CadTaxaDeposito(), vParam);
        }

        private void id_taxa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_taxa|=|" + id_taxa.Text+ ";"+
                "a.tp_taxa|=|" + (st_valor.Checked ? "'V'" : "'P'");
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[]{id_taxa, ds_taxa},
                                    new CamadaDados.Graos.TCD_CadTaxaDeposito());
        }

        private void TFLanFaturarTaxas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gAnalitico);
        }
    }
}
