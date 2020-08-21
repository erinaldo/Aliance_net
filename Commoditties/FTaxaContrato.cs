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
    public partial class TFTaxaContrato : Form
    {
        private CamadaDados.Graos.TRegistro_CadContratoTaxaDeposito rtaxa;
        public CamadaDados.Graos.TRegistro_CadContratoTaxaDeposito rTaxa
        {
            get
            {
                if (bsTaxa.Current != null)
                    return bsTaxa.Current as CamadaDados.Graos.TRegistro_CadContratoTaxaDeposito;
                else
                    return null;
            }
            set
            {
                rtaxa = value;
            }
        }

        public TFTaxaContrato()
        {
            InitializeComponent();
            rtaxa = null;
            ArrayList cbx4 = new ArrayList();
            cbx4.Add(new Utils.TDataCombo("RECEBIMENTO", "R"));
            cbx4.Add(new Utils.TDataCombo("EXPEDICAO", "E"));
            st_gerartxsomente.DataSource = cbx4;
            st_gerartxsomente.DisplayMember = "Display";
            st_gerartxsomente.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFTaxaContrato_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pDados.set_FormatZero();
            if (rtaxa != null)
            {
                bsTaxa.DataSource = new CamadaDados.Graos.TList_CadContratoTaxaDeposito() { rtaxa };
                id_taxa.Enabled = false;
                bb_taxa.Enabled = false;
                bsTaxa.ResetCurrentItem();
            }
            else
                bsTaxa.AddNew();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFTaxaContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_taxa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_taxa|Taxa|250;" +
                                  "a.id_taxa|Id. Taxa|80;" +
                                  "a.tp_taxa|Tipo Taxa|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_taxa, ds_taxa, tp_taxa },
                                new CamadaDados.Graos.TCD_CadTaxaDeposito(), string.Empty);
        }

        private void id_taxa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.id_taxa|=|" + id_taxa.Text;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { id_taxa, ds_taxa, tp_taxa },
                                    new CamadaDados.Graos.TCD_CadTaxaDeposito());
        }

        private void bb_unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_unidade|Unidade|250;" +
                                  "a.cd_unidade|Cd. Unidade|80;" +
                                  "a.sigla_unidade|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_unidadetaxa, ds_unidadetaxa, sg_unidadetaxa },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), string.Empty);
        }

        private void cd_unidadetaxa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_unidade|=|'" + cd_unidadetaxa.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_unidadetaxa, ds_unidadetaxa, sg_unidadetaxa },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void bb_amostra_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_amostra|Amostra|250;" +
                                  "a.cd_tipoamostra|Cd. Amostra|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tipoamostra, ds_tipoamostra },
                                    new CamadaDados.Graos.TCD_CadAmostra(), string.Empty);
        }

        private void cd_tipoamostra_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_tipoamostra|=|'" + cd_tipoamostra.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_tipoamostra, ds_tipoamostra },
                                    new CamadaDados.Graos.TCD_CadAmostra());
        }
    }
}
