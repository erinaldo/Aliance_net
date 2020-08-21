using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sementes
{
    public partial class TFFormulaEstornoSemente : Form
    {
        public CamadaDados.Sementes.TRegistro_LoteSemente rSemente
        { get; set; }

        public TFFormulaEstornoSemente()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (this.pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFFormulaEstornoSemente_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsLoteSemente.Add(rSemente);
            pDetalhe.BackColor = Utils.SettingsUtils.Default.COLOR_2;
        }

        private void bb_formulacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_formula|Formula Produção|200;" +
                              "a.id_formulacao|Id. Formula|80";
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_prd_fichatec_mprima x " +
                            "           where x.id_formulacao = a.id_formulacao " +
                            "           and x.cd_empresa = a.cd_empresa " +
                            "           and x.cd_produto = '" + cd_produto.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_prd_fichatec_acabado x " +
                            "           where x.cd_empresa = a.cd_empresa " +
                            "           and x.id_formulacao = a.id_formulacao " +
                            "           and x.cd_produto = '" + cd_amostra.Text.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_formestorno, ds_formula },
                                            new CamadaDados.Producao.Producao.TCD_FormulaApontamento(), vParam);
        }

        private void id_formestorno_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_formulacao|=|" + id_formestorno.Text.Trim() + ";" +
                            "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_prd_fichatec_mprima x " +
                            "           where x.id_formulacao = a.id_formulacao " +
                            "           and x.cd_empresa = a.cd_empresa " +
                            "           and x.cd_produto = '" + cd_produto.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_prd_fichatec_acabado x " +
                            "           where x.cd_empresa = a.cd_empresa " +
                            "           and x.id_formulacao = a.id_formulacao " +
                            "           and x.cd_produto = '" + cd_amostra.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_formestorno, ds_formula },
                                    new CamadaDados.Producao.Producao.TCD_FormulaApontamento());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFFormulaEstornoSemente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
