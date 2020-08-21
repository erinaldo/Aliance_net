using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aliance.NET
{
    public partial class TFAlterarSenha : Form
    {
        public string vLogin = string.Empty;
        public string vSenhaAtual = string.Empty;

        public TFAlterarSenha()
        {
            InitializeComponent();
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            if (senhaatual.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar senha atual.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                senhaatual.Focus();
                return;
            }
            if (novasenha.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar nova senha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                novasenha.Focus();
                return;
            }
            if (confirma.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório confirmar nova senha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                confirma.Focus();
                return;
            }
            if (confirma.Focused)
            {
                if (novasenha.Text.Trim() != confirma.Text.Trim())
                {
                    MessageBox.Show("Confirmação de senha diferente da senha informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    confirma.Clear();
                    confirma.Focus();
                    return;
                }
            }
            if (senhaatual.Text.Trim().Equals(novasenha.Text.Trim()))
            {
                MessageBox.Show("Nova senha deve ser diferente da senha atual.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                novasenha.Clear();
                novasenha.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[2];
            filtro[0].vNM_Campo = "login";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + vLogin.Trim() + "'";
            filtro[1].vNM_Campo = "senha";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + senhaatual.Text.Trim() + "'";
            CamadaDados.Diversos.TList_CadUsuario user = new CamadaDados.Diversos.TCD_CadUsuario().Select(filtro, 1, "");
            if (user.Count > 0)
            {
                //Alterar senha do usuario
                user[0].Senha = novasenha.Text.Trim();
                user[0].Dt_altsenha = DateTime.Today;
                if (CamadaNegocio.Diversos.TCN_CadUsuario.Gravar(user[0], null).Trim() != string.Empty)
                {
                    MessageBox.Show("Senha alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vSenhaAtual = novasenha.Text.Trim();
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
                MessageBox.Show("Senha atual invalida para o login " + vLogin.Trim() + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void confirma_Leave(object sender, EventArgs e)
        {
            if(confirma.Text.Trim() != string.Empty)
                if (novasenha.Text.Trim() != confirma.Text.Trim())
                {
                    MessageBox.Show("Confirmação de senha diferente da senha informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    confirma.Clear();
                    confirma.Focus();
                }
        }

        private void TFAlterarSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                BTN_OK_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFAlterarSenha_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pBotoes.BackColor = Utils.SettingsUtils.Default.COLOR_3;
        }
    }
}
