using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Sementes
{
    public partial class TFProcessarLoteSemente : Form
    {
        private string Cd_produto
        { get; set; }
        private string Ds_produto
        { get; set; }

        public CamadaDados.Sementes.TRegistro_LoteSemente rSemente
        { get; set; }

        public TFProcessarLoteSemente()
        {
            InitializeComponent();
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_produto|Produto|200;" +
                              "a.cd_produto|Cd. Produto|80;" +
                              "b.sigla_unidade|Sigla Unidade|80";
            string vParam = string.Empty;
            if (id_formulacao.Text.Trim() != string.Empty)
                vParam = "|exists|(select 1 from tb_prd_fichatec_acabado x " +
                         "where x.cd_produto = a.cd_produto " +
                         "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "' " +
                         "and x.id_formulacao = " + id_formulacao.Text + ")";
            if (rbRefugar.Checked)
            {
                if (id_formulacao.Text.Trim() != string.Empty)
                    vParam += ";";
                vParam += "|exists|(select 1 from tb_est_tpproduto x " +
                          "where x.tp_produto = a.tp_produto " +
                          "and isnull(x.st_mprimasemente, 'N') = 'N' " +
                          "and isnull(x.st_semente, 'N') = 'N')";
            }
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_produto, ds_produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), vParam);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            if (id_formulacao.Text.Trim() != string.Empty)
                vParam += ";|exists|(select 1 from tb_prd_fichatec_acabado x " +
                          "where x.cd_produto = a.cd_produto " +
                          "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "' " +
                          "and x.id_formulacao = " + id_formulacao.Text + ")";
            if (rbRefugar.Checked)
                vParam += ";|exists|(select 1 from tb_est_tpproduto x " +
                          "where x.tp_produto = a.tp_produto " +
                          "and isnull(x.st_mprimasemente, 'N') = 'N' " +
                          "and isnull(x.st_semente, 'N') = 'N')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_produto, ds_produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_formulacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_formula|Formula Produção|200;" +
                              "a.id_formulacao|Id. Formula|80";
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_prd_fichatec_mprima x " +
                            "           where x.id_formulacao = a.id_formulacao " +
                            "           and x.cd_empresa = a.cd_empresa " +
                            "           and x.cd_produto = '" + cd_amostra.Text.Trim() + "')";
            if (cd_produto.Text.Trim() != string.Empty)
                vParam += ";|exists|(select 1 from tb_prd_fichatec_acabado x " +
                          "           where x.cd_empresa = a.cd_empresa " +
                          "           and x.id_formulacao = a.id_formulacao " +
                          "           and x.cd_produto = '" + cd_produto.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_formulacao, ds_formula },
                                    new CamadaDados.Producao.Producao.TCD_FormulaApontamento(), vParam);
        }

        private void id_formulacao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_formulacao|=|" + id_formulacao.Text.Trim() + ";" +
                            "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_prd_fichatec_mprima x " +
                            "           where x.id_formulacao = a.id_formulacao " +
                            "           and x.cd_empresa = a.cd_empresa " +
                            "           and x.cd_produto = '" + cd_amostra.Text.Trim() + "')";
            if (cd_produto.Text.Trim() != string.Empty)
                vParam += ";|exists|(select 1 from tb_prd_fichatec_acabado x " +
                          "           where x.cd_empresa = a.cd_empresa " +
                          "           and x.id_formulacao = a.id_formulacao " +
                          "           and x.cd_produto = '" + cd_produto.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_formulacao, ds_formula },
                                    new CamadaDados.Producao.Producao.TCD_FormulaApontamento());
        }

        private void TFProcessarLoteSemente_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsLoteSemente.Add(rSemente);
            anosafra.Focus();
            this.Cd_produto = rSemente.Cd_produto;
            this.Ds_produto = rSemente.Ds_produto;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFProcessarLoteSemente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                if (pDados.validarCampoObrigatorio())
                    this.DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void rbRefugar_Click(object sender, EventArgs e)
        {
            if (rbRefugar.Checked)
            {
                cd_atestado.Enabled = false;
                dt_valgerminacao.Enabled = false;
                pc_germinacao.Enabled = false;
                pc_pureza.Enabled = false;
                cd_produto.Enabled = true;
                bb_produto.Enabled = true;
                ds_motivorefugo.Enabled = true;
            }
        }

        private void rbProcessarLote_Click(object sender, EventArgs e)
        {
            if (rbProcessarLote.Checked)
            {
                cd_atestado.Enabled = true;
                dt_valgerminacao.Enabled = true;
                pc_germinacao.Enabled = true;
                pc_pureza.Enabled = true;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
                cd_produto.Text = this.Cd_produto;
                ds_produto.Text = this.Ds_produto;
                ds_motivorefugo.Enabled = false;
            }
        }
    }
}
