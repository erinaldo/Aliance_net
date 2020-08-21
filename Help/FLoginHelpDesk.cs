using System;
using System.Windows.Forms;

namespace Help
{
    public partial class TFLoginHelpDesk : Form
    {
        public string Login
        { get { return edtLogin.Text; } }
        public string Id_cliente { get; set; }

        public TFLoginHelpDesk()
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
            //Validar login e senha
            string ret = ServiceRest.DataService.ValidarLogin(
                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(string.Empty, string.Empty, "A", null), 
                edtLogin.Text, 
                edtSenha.Text);
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
