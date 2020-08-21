using FormBusca;
using System;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFCorrigirRepresentante : Form
    {
        public string pCd_representante { get; set; }
        public string pNm_representante { get; set; }
        public decimal pPc_comrep { get; set; }
        public string pCd_cliforind { get; set; }
        public string pNm_cliforind { get; set; }
        public string pCd_gerente { get; set; }
        public string pNm_gerente { get; set; }

        public TFCorrigirRepresentante()
        {
            InitializeComponent();
        }

        private void TFCorrigirRepresentante_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            cd_representante.Text = pCd_representante;
            nm_representante.Text = pNm_representante;
            pc_comrep.Value = pPc_comrep;
            cd_cliforind.Text = pCd_cliforind;
            nm_cliforind.Text = pNm_cliforind;
            cd_gerente.Text = pCd_gerente;
            nm_gerente.Text = pNm_gerente;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void bb_representante_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_representante, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_representante, nm_representante },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_representante_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_representante.Text.Trim() + "';" +
                            "isnull(a.st_representante, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_representante, nm_representante },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_cliforind_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforind, nm_cliforind }, string.Empty);
        }

        private void cd_cliforind_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliforind.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_cliforind, nm_cliforind },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_gerente_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_gerente, nm_gerente }, string.Empty);
        }

        private void cd_gerente_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_gerente.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_gerente, nm_gerente },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void TFCorrigirRepresentante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void TFCorrigirRepresentante_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                pCd_representante = cd_representante.Text;
                pNm_representante = nm_representante.Text;
                pPc_comrep = pc_comrep.Value;
                pCd_cliforind = cd_cliforind.Text;
                pNm_cliforind = nm_cliforind.Text;
                pCd_gerente = cd_gerente.Text;
                pNm_gerente = nm_gerente.Text;
            }
        }
    }
}
