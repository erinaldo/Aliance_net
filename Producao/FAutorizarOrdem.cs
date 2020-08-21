using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFAutorizarOrdem : Form
    {
        public CamadaDados.Producao.Producao.TRegistro_OrdemProducao rOrdem
        {
            get;
            set;
        }

        public TFAutorizarOrdem()
        {
            InitializeComponent();
            rOrdem = null;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFAutorizarOrdem_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rOrdem != null)
            {
                bsOrdemProducao.DataSource = new CamadaDados.Producao.Producao.TList_OrdemProducao() { rOrdem };
                id_formulacao.Focus();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAutorizarOrdem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_formulacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_formula|Formula|100;" +
                              "a.id_formulacao|Id. Formula|80";
            string vParam = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_prd_fichatec_acabado x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and x.id_formulacao = a.id_formulacao " +
                            "and x.cd_produto = '" + cd_produto.Text.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_formulacao, ds_formula },
                                            new CamadaDados.Producao.Producao.TCD_FormulaApontamento(),
                                            vParam);
        }

        private void id_formulacao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_formulacao|=|" + id_formulacao.Text + ";" +
                            "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_prd_fichatec_acabado x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and x.id_formulacao = a.id_formulacao " +
                            "and x.cd_produto = '" + cd_produto.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_formulacao, ds_formula },
                                                new CamadaDados.Producao.Producao.TCD_FormulaApontamento());
        }
    }
}
