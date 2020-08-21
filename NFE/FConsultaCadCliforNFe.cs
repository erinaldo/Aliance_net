using System;
using System.Windows.Forms;
using Utils;

namespace srvNFE
{
    public partial class TFConsultaCadCliforNFe : Form
    {
        public string nrCnpj
        { get; set; }
        public string nrCpf
        { get; set; }
        public string sgUF
        { get; set; }

        public CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe
        { get; set; }

        private CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rclifor;
        public CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor
        {
            get { return rclifor; }
            set { rclifor = value; }
        }

        public TFConsultaCadCliforNFe()
        {
            InitializeComponent();
        }

        private void TFConsultaCadCliforNFe_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            uf.DisplayMember = "Uf";
            uf.ValueMember = "Cd_uf";
            uf.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadUf.Buscar(string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                null);
            cnpj.Text = nrCnpj;
            cpf.Text = nrCpf;
            uf.Text = sgUF;
        }

        private void bb_consultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cnpj.Text.SoNumero()) &&
                string.IsNullOrEmpty(cpf.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatorio informar CNPJ ou CPF para realizar consulta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (uf.SelectedIndex < 0)
            {
                MessageBox.Show("Obrigatorio informar UF para realizar consulta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                uf.Focus();
                return;
            }
            try
            {
                //Verificar se o cliente nao existe na base de dados
                CamadaDados.Financeiro.Cadastros.TList_CadClifor lClifor =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              cnpj.Text,
                                                                              cpf.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              false,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              null);
                if (lClifor.Count > 0)
                {
                    rclifor = lClifor[0];
                    rclifor.lEndereco = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rclifor.Cd_clifor,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  0,
                                                                                                  null);
                }
                else
                    rclifor = ConsultaCad.TConsultaCad2.ConsultaCadClifor(cnpj.Text, cpf.Text, uf.Text, rCfgNfe);
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            { MessageBox.Show("Não foi possivel consultar CNPJ na base da SEFAZ.\r\n" +
                              "Realize o cadastro manualmente ou tente nova consulta mais tarde.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cnpj_Leave(object sender, EventArgs e)
        {
            if ((cnpj.Text.Trim() != string.Empty) && (cnpj.Text.Replace(',', '.').Trim() != ".   .   /    -"))
            {
                CNPJ_Valido.nr_CNPJ = cnpj.Text.Replace(',', '.');
                if (string.IsNullOrEmpty(CNPJ_Valido.nr_CNPJ))
                {
                    MessageBox.Show("Por Favor! Entre com um CNPJ Válido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cnpj.Clear();
                    cnpj.Focus();
                }
            }
        }

        private void cpf_Leave(object sender, EventArgs e)
        {
            if ((cpf.Text.Trim() != string.Empty) && (cpf.Text.Replace(',', '.').Trim() != ".   .   -"))
            {
                CPF_Valido.nr_CPF = cpf.Text.Replace(',', '.');
                if (string.IsNullOrEmpty(CPF_Valido.nr_CPF))
                {
                    MessageBox.Show("Por Favor! Entre com um CPF Válido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cpf.Clear();
                    cpf.Focus();
                }
            }
        }
    }
}
