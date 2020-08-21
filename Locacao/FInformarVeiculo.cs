using System;
using System.Drawing;
using System.Windows.Forms;

namespace Locacao
{
    public partial class TFInformarVeiculo : Form
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string IdLocacao { get; set; } = string.Empty;

        public string pId_veiculo
        { get { return id_veiculo.Text; } }
        public string pCd_motorista
        { get { return cd_motorista.Text; } }
        public string pObs
        { get { return ds_obs.Text; } }
        public TFInformarVeiculo()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (cd_motorista.Focused)
                ds_obs.Focus();
            if (string.IsNullOrEmpty(id_veiculo.Text))
            {
                MessageBox.Show("Obrigatório informar veículo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cd_motorista.Text))
            {
                MessageBox.Show("Obrigatório informar motorista!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void lblConfirma_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void lblCancela_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFInformarVeiculo_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
            id_veiculo.Focus();
            if (!string.IsNullOrEmpty(IdLocacao) && !string.IsNullOrEmpty(Cd_empresa))
                CamadaNegocio.Locacao.TCN_Historico.buscar(Cd_empresa, IdLocacao, string.Empty, null)
                    .ForEach(v => txtHistorico.Text += v.Ds_historico.Trim() + "\r\n");
        }

        private void TFInformarVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + id_veiculo.Text.Trim() + "';" +
                               "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(),
               vParam);
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                            "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_motorista, nm_motorista },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Motorista|200;" +
                              "a.cd_clifor|Codigo|80;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "d.ds_veiculo|Veiculo|100;" +
                              "d.placa|Placa|80;" +
                              "a.categoria_cnh|Categoria CNH|80;" +
                              "a.dt_vencimento_cnh|Vencimento CNH|100";
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_motorista, nm_motorista },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
        }

        private void lblConfirma_MouseEnter(object sender, EventArgs e)
        {
            lblConfirma.BorderStyle = BorderStyle.FixedSingle;
            lblConfirma.Cursor = Cursors.Hand;
            lblConfirma.ForeColor = Color.Blue;
        }

        private void lblConfirma_MouseLeave(object sender, EventArgs e)
        {
            lblConfirma.BorderStyle = BorderStyle.None;
            lblConfirma.Cursor = Cursors.Default;
            lblConfirma.ForeColor = Color.Black;
        }

        private void lbCancela_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lbCancela_MouseEnter(object sender, EventArgs e)
        {
            lbCancela.BorderStyle = BorderStyle.FixedSingle;
            lbCancela.Cursor = Cursors.Hand;
            lbCancela.ForeColor = Color.Blue;
        }

        private void lbCancela_MouseLeave(object sender, EventArgs e)
        {
            lbCancela.BorderStyle = BorderStyle.None;
            lbCancela.Cursor = Cursors.Default;
            lbCancela.ForeColor = Color.Black;
        }
    }
}
