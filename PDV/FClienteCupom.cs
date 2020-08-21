using System;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace PDV
{
    public partial class TFClienteCupom : Form
    {
        public string Cd_clifor { get; set; }
        private string nome_clifor;
        public string Nm_clifor
        {
            get { return nm_clifor.Text; }
            set { nome_clifor = value; }
        }
        private string nr_cgccpf;
        public string Nr_cgccpf
        {
            get { return cpfcnpj.Text; }
            set { nr_cgccpf = value; }
        }
        private string nome_motorista;
        public string Nome_motorista
        {
            get { return nm_motorista.Text; }
            set { nome_motorista = value; }
        }
        public string pNr_requisicao
        { get { return Nr_requisicao.Text; } }
        public string Cpf_motorista
        { get { return cpf_motorista.Text; } }
        public string Ds_portador
        { get { return ds_portador.Text; } }
        private string pPlaca;
        public string Placa
        { get { return placa.Text; } set { pPlaca = value; } }
        public decimal Km
        { get { return km.Value; } }
        public decimal Km_maximo
        { get; set; }
        public bool St_avulso
        { get; set; }
        public string Email
        {
            get
            {
                return email.Text.Trim();
            }
            private set
            {
            }
        }
        public bool BloquearNmClifor = true;

        public TFClienteCupom()
        {
            InitializeComponent();
        }

        private bool ValidarKm(ref decimal Km_atual)
        {
            Km_maximo = decimal.Zero;
            bool retorno = true;
            //Validar KM Atual
            if ((!string.IsNullOrEmpty(placa.Text)) &&
                (placa.Text.Trim() != "-") &&
                (km.Value > decimal.Zero))
            {
                object obj = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "replace(a.placaveiculo, '-', '')",
                                            vOperador = "=",
                                            vVL_Busca = "'" + placa.Text.Trim().Replace("-", "") + "'"
                                        }
                                    }, "isnull(a.km_atual, 0)", string.Empty, "a.dt_abastecimento desc", null);
                if (obj != null)
                    //Buscar ultimo KM Informado para a placa
                    if (decimal.Parse(obj.ToString()) > km.Value)
                    {
                        Km_atual = decimal.Parse(obj.ToString());
                        retorno = false;
                    }
            }
            return retorno;
        }

        private bool ValidaCPF()
        {
            if (!string.IsNullOrEmpty(cpfcnpj.Text.SoNumero()))
            {
                CPF_Valido.nr_CPF = cpfcnpj.Text;
                CNPJ_Valido.nr_CNPJ = cpfcnpj.Text;
                if (string.IsNullOrEmpty(CPF_Valido.nr_CPF) &&
                    string.IsNullOrEmpty(CNPJ_Valido.nr_CNPJ))
                {
                    MessageBox.Show("Por Favor! Entre com um CPF/CNPJ Válido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cpfcnpj.Clear();
                    cpfcnpj.Focus();
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        }

        private void afterGrava()
        {
            if (!ValidaCPF())
                return;
            if (!string.IsNullOrEmpty(nm_clifor.Text))
                if (nm_clifor.Text.Trim().Length < 2)
                {
                    MessageBox.Show("Nome do cliente deve possuir dois ou mais caracteres.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nm_clifor.Focus();
                    return;
                }
            decimal KM = decimal.Zero;

            if (ValidarKm(ref KM))
                DialogResult = DialogResult.OK;

            else if (MessageBox.Show("KM Atual não pode ser menor ou igual ao ultimo KM informado para a placa (Ultimo KM: " + KM.ToString("N0", new System.Globalization.CultureInfo("pt-BR")) + ").\r\n" +
                                    "Deseja corrigir ultimo KM informado?", "Pergunta",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                //Buscar abastecida do ultimo KM
                CamadaDados.PostoCombustivel.TList_VendaCombustivel lVenda =
                    new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                    new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "replace(a.placaveiculo, '-', '')",
                                vOperador = "=",
                                vVL_Busca = "'" + placa.Text.Trim().Replace("-", "") + "'"
                            }
                        }, 1, "isnull(a.km_atual, 0)", "a.dt_abastecimento desc");
                if (lVenda.Count > 0)
                    using (TFCorrigirKM fKM = new TFCorrigirKM())
                    {
                        fKM.Ultimo_km = lVenda[0].Km_atual;
                        fKM.Km_atual = km.Value;
                        if (fKM.ShowDialog() == DialogResult.OK)
                            try
                            {
                                lVenda[0].Km_atual = fKM.Km_corrigido;
                                CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(lVenda[0], null);
                                MessageBox.Show("Ultimo KM corrigido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DialogResult = DialogResult.OK;
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
            else if (MessageBox.Show("Deseja informar KM maximo do hodometro?", "Pergunta", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                {
                    fQtd.Ds_label = "KM Maximo Hodometro";
                    fQtd.ShowDialog();
                    if (fQtd.Quantidade >= KM)
                    {
                        Km_maximo = fQtd.Quantidade;
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void TFClienteCupom_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            nm_clifor.Text = nome_clifor;
            cpfcnpj.Text = nr_cgccpf;
            nm_motorista.Text = nome_motorista;
            placa.Text = pPlaca;

            cd_portador.Enabled = St_avulso;
            bb_portador.Enabled = St_avulso;
            if (string.IsNullOrEmpty(cpfcnpj.Text.SoNumero()))
                cpfcnpj.Text = string.Empty;

            nm_clifor.Enabled = BloquearNmClifor;
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Clifor|300;" +
                              "a.cd_clifor|Código Clifor|90;" +
                              "a.nr_cgc|C.N.P.J|80;" +
                              "a.nr_cpf|C.P.F|80;" +
                              "a.nr_rg|R.G|80;" +
                              "a.tp_pessoa|Tipo Pessoa|80;" +
                              "a.nm_fantasia|Fantasia|100;" +
                              "a.cd_condfiscal_clifor|Condição Fiscal|80;" +
                              "a.email|E-mail|100";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), string.Empty);
            if (linha != null)
            {
                Cd_clifor = linha["cd_clifor"].ToString();
                cpfcnpj.Text = string.IsNullOrEmpty(linha["nr_cgc"].ToString()) ? linha["nr_cpf"].ToString() : linha["nr_cgc"].ToString();
                if (string.IsNullOrEmpty(cpfcnpj.Text.SoNumero()))
                    cpfcnpj.Text = string.Empty;

                email.Text = linha["email"].ToString();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFClienteCupom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_portador|Portador|200;" +
                              "a.cd_portador|Cd. Portador|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(),
                                                "isnull(tp_portadorpdv, '')|<>|''");
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_portador|=|'" + cd_portador.Text.Trim() + "';isnull(tp_portadorpdv, '')|<>|''";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_motorista }, string.Empty);
            if (linha != null)
                cpf_motorista.Text = linha["nr_cpf"].ToString();
        }

        private void cpf_motorista_TextChanged(object sender, EventArgs e)
        {
            if (cpf_motorista.Text.Trim().Length.Equals(3) ||
                cpf_motorista.Text.Trim().Length.Equals(7))
            {
                cpf_motorista.Text = cpf_motorista.Text + ".";
                cpf_motorista.SelectionStart = cpf_motorista.Text.Trim().Length;
            }
            if (cpf_motorista.Text.Trim().Length.Equals(11))
            {
                cpf_motorista.Text = cpf_motorista.Text + "-";
                cpf_motorista.SelectionStart = cpf_motorista.Text.Trim().Length;
            }
        }

        private void cpf_motorista_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cpf_motorista.Text.SoNumero()))
            {
                CPF_Valido.nr_CPF = cpf_motorista.Text;
                if (string.IsNullOrEmpty(CPF_Valido.nr_CPF))
                {
                    MessageBox.Show("Por Favor! Entre com um CPF Válido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cpf_motorista.Clear();
                    cpf_motorista.Focus();
                }
            }
        }
        
        private void cpfcnpj_Leave(object sender, EventArgs e)
        {
            ValidaCPF();
        }
    }
}
