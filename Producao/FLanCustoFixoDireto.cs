using System;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFLanCustoFixoDireto : Form
    {
        public bool St_altera
        { get; set; }

        public string Cd_empresa
        { get; set; }

        public CamadaDados.Producao.Producao.TRegistro_CustoFixo_Direto CustoFixoDireto
        {
            get
            {
                if (bsCustoFixoDireto.Current != null)
                    return (bsCustoFixoDireto.Current as CamadaDados.Producao.Producao.TRegistro_CustoFixo_Direto);
                else
                    return null;
            }
            set
            {
                bsCustoFixoDireto.Add(value);
                bsCustoFixoDireto.ResetCurrentItem();
            }
        }

        public TFLanCustoFixoDireto()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (id_custo.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar custo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_custo.Focus();
                return;
            }
            if (cd_moeda.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar moeda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_moeda.Focus();
                return;
            }
            if (CD_Unidade.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar unidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Unidade.Focus();
                return;
            }
            if ((vl_custo.Value == 0) && (pc_custo.Value == 0))
            {
                MessageBox.Show("Obrigatorio informar ou valor do custo ou % do custo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_custo.Focus();
                return;
            }
            if (vl_custo.Focused)
                (bsCustoFixoDireto.Current as CamadaDados.Producao.Producao.TRegistro_CustoFixo_Direto).Vl_custo = vl_custo.Value;
            if (pc_custo.Focused)
                (bsCustoFixoDireto.Current as CamadaDados.Producao.Producao.TRegistro_CustoFixo_Direto).Pc_custo = pc_custo.Value;
            bsCustoFixoDireto.EndEdit();
            this.DialogResult = DialogResult.OK;
        }

        private void bb_custo_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_custo|Custo Fixo|200;" +
                              "id_custo|Id. Custo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_custo, ds_custo },
                                            new CamadaDados.Producao.Cadastros.TCD_Cad_PRD_Custos(), string.Empty);
        }

        private void id_custo_Leave(object sender, EventArgs e)
        {
            string vColunas = "id_custo|=|" + id_custo.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { id_custo, ds_custo },
                                              new CamadaDados.Producao.Cadastros.TCD_Cad_PRD_Custos());
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_moeda_singular|Moeda|200;" +
                              "cd_moeda|Cd. Moeda|80;" +
                              "sigla|Sigla|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla },
                                            new CamadaDados.Financeiro.Cadastros.TCD_Moeda(), string.Empty);
        }

        private void cd_moeda_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_moeda|=|'" + cd_moeda.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla },
                                            new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
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

        private void TFLanCustoFixoDireto_Load(object sender, EventArgs e)
        {
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            id_custo.Enabled = !St_altera;
            bb_custo.Enabled = !St_altera;
            //Criar novo registro se nao estiver alterando
            if (!St_altera)
                bsCustoFixoDireto.AddNew();
        }

        private void TFLanCustoFixoDireto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }
    }
}
