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
    public partial class TFLanFichaTec_MPrima : Form
    {
        public bool St_altera
        { get; set; }

        public string Cd_empresa
        { get; set; }

        public CamadaDados.Producao.Producao.TRegistro_FichaTec_MPrima FichaTec_MPrima
        {
            get
            {
                if (bsFichaTec_MPrima.Current != null)
                    return (bsFichaTec_MPrima.Current as CamadaDados.Producao.Producao.TRegistro_FichaTec_MPrima);
                else
                    return null;
            }
            set
            {
                bsFichaTec_MPrima.Add(value);
                bsFichaTec_MPrima.ResetCurrentItem();
            }
        }

        public TFLanFichaTec_MPrima()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (CD_Produto.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Produto.Focus();
                return;
            }
            if (CD_Local.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar local armazenagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Local.Focus();
                return;
            }
            if (CD_Unidade.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar unidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Unidade.Focus();
                return;
            }
            if (Quantidade.Value <= 0)
            {
                MessageBox.Show("Obrigatorio informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Quantidade.Focus();
                return;
            }
            if (Quantidade.Focused)
                (bsFichaTec_MPrima.Current as CamadaDados.Producao.Producao.TRegistro_FichaTec_MPrima).Qtd_produto = Quantidade.Value;
            if (PC_QuebraTecnica.Focused)
                (bsFichaTec_MPrima.Current as CamadaDados.Producao.Producao.TRegistro_FichaTec_MPrima).Pc_quebra_tec = PC_QuebraTecnica.Value;
            bsFichaTec_MPrima.EndEdit();
            this.DialogResult = DialogResult.OK;
        }

        private void TFLanFichaTec_MPrima_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            CD_Produto.Enabled = !St_altera;
            BB_Produto.Enabled = !St_altera;
            //Criar novo registro se nao estiver alterando
            if(!St_altera)
                bsFichaTec_MPrima.AddNew();
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                    "isnull(e.st_servico, 'N')|=|'N'");
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + CD_Produto.Text.Trim() + "';" +
                                                     "isnull(e.st_servico, 'N')|=|'N'",
                                                    new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_versao_mprima_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_formulacao|Cd. Versão|80;" +
                              "a.Ds_formula|Descrição Versão|250";
            string vParam = "a.cd_empresa|=|'" + Cd_empresa.Trim() + "';" +
                            "a.cd_produto|=|'" + CD_Produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_versao_mprima },
                                            new CamadaDados.Producao.Producao.TCD_FormulaApontamento(),
                                            vParam);
        }

        private void cd_versao_mprima_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_formulacao|=|" + cd_versao_mprima.Text + ";" +
                            "a.cd_empresa|=|'" + Cd_empresa.Trim() + "';" +
                            "a.cd_produto|=|'" + CD_Produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_versao_mprima },
                                            new CamadaDados.Producao.Producao.TCD_FormulaApontamento());
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("ds_local|Local Armazenagem|200;cd_local|Cd. Local|80"
            , new Componentes.EditDefault[] { CD_Local, DS_Local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_local|=|'" + CD_Local.Text.Trim() + "';" +
                              "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local },
                                                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_unidade|Unidade|200;" +
                              "cd_unidade|Cd. Unidade|80;" +
                              "sigla_unidade|Sigla|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD }, 
                                            new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), string.Empty); 
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_unidade|=|'" + CD_Unidade.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD },
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

        private void TFLanFichaTec_MPrima_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
