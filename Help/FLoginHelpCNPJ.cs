using System;
using System.Windows.Forms;
using Utils;

namespace Help
{
    public partial class TFLoginHelpCNPJ : Form
    {
        public string Login
        { get { return edtLogin.Text; } }
        public string Id_cliente { get; set; }
        public TFLoginHelpCNPJ()
        {
            InitializeComponent();
        }

        private void pFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edtLogin.Text))
            {
                MessageBox.Show("Obrigatorio informar login.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                edtLogin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(edtSenha.Text))
            {
                MessageBox.Show("Obrigatorio informar senha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                edtSenha.Focus();
                return;
            }
            if(cnpj.Text.SoNumero().Length != 14)
            {
                MessageBox.Show("Obrigatório informar CNPJ valido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnpj.Focus();
                return;
            }
            //Validar login e senha
            string ret = ServiceRest.DataService.ValidarLogin(cnpj.Text.SoNumero(), edtLogin.Text, edtSenha.Text);
            if (!string.IsNullOrWhiteSpace(ret))
            {
                Id_cliente = ret;
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Login ou Senha invalido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
