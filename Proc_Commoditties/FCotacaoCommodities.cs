using System;
using System.Windows.Forms;
using Utils;

namespace Proc_Commoditties
{
    public partial class TFCotacaoCommodities : Form
    {
        public string pCd_produto { get; set; } = string.Empty;
        public string pDs_produto { get; set; } = string.Empty;
        public string pCd_unidade { get { return cd_unidade.Text; } }
        public decimal pVl_precocompra { get { return vl_precocompra.Value; } }
        public decimal pVl_precovenda { get { return vl_precovenda.Value; } }
        public DateTime pDt_cotacao { get { return DateTime.Parse(dt_cotacao.Text); } }

        public TFCotacaoCommodities()
        {
            InitializeComponent();
        }
        private void afterGrava()
        {
            if(string.IsNullOrEmpty(cd_unidade.Text))
            {
                MessageBox.Show("Obrigatório informar unidade do preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_unidade.Focus();
                return;
            }
            if(vl_precocompra.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar valor compra.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_precocompra.Focus();
                return;
            }
            if(vl_precovenda.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar valor venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_precovenda.Focus();
                return;
            }
            if(string.IsNullOrEmpty(dt_cotacao.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data cotação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_cotacao.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }
        private void TFCotacaoCommodities_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            cd_produto.Text = pCd_produto;
            ds_produto.Text = pDs_produto;
            dt_cotacao.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFCotacaoCommodities_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_unidade_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("ds_unidade|Unidade|200;cd_unidade|Código|60",
                                             new Componentes.EditDefault[] { cd_unidade, ds_unidade },
                                             new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(),
                                             string.Empty);
        }

        private void cd_unidade_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_unidade|=|'" + cd_unidade.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_unidade, ds_unidade },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }
    }
}
