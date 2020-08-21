using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFValidaLogin : Form
    {
        public string pLogin
        { get { return Login.Text; } }

        public TFValidaLogin()
        {
            InitializeComponent();
        }
        
        private void EfetuarLogin()
        {
            if (string.IsNullOrEmpty(Login.Text))
            {
                MessageBox.Show("Obrigatorio informar USUARIO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Senha.Text))
            {
                MessageBox.Show("Obrigatorio informar SENHA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Senha.Focus();
                return;
            }
            if ((Login.Text.Trim().Equals("MASTER") && new BancoDados.TObjetoBanco().ValidarSenhaMaster(Senha.Text)) ||
                (Login.Text.Trim().Equals("DESENV") && new BancoDados.TObjetoBanco().ValidarSenhaDesenv(Senha.Text)) ||
                CamadaNegocio.Diversos.TCN_CadUsuario.ValidarUsuario(Login.Text, Senha.Text))
                this.DialogResult = DialogResult.OK;
            else MessageBox.Show("Usuario ou senha invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void bb_cancela_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_confirma_Click(object sender, EventArgs e)
        {
            this.EfetuarLogin();
        }

        private void TFValidaLogin_Load(object sender, EventArgs e)
        {
            Senha.CharacterCasing = CharacterCasing.Normal;
        }
    }
}
