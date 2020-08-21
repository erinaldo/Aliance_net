using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFRegraUsuario : Form
    {
        public string Ds_regraespecial
        { get; set; }
        private string vLogin;
        public string Login
        {
            get
            {
                return LoginUser.Text.Trim();
            }
            set { vLogin = value; }
        }
        public string LoginInformado { get; private set; } = string.Empty;

        public TFRegraUsuario()
        {
            InitializeComponent();
            this.Ds_regraespecial = string.Empty;
            this.vLogin = string.Empty;
        }

        private bool validarUsuario()
        {
            object obj = new CamadaDados.Diversos.TCD_CadUsuario().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "Login",
                        vOperador = "=",
                        vVL_Busca = "'"+LoginUser.Text.Trim()+"'"
                    }
                }, "1");
            if (obj != null)
                return obj.ToString().Trim().Equals("1");
            else
                return false;
        }

        private bool validarSenha()
        {
            if ((LoginUser.Text.Trim().ToUpper().Equals("MASTER") && new BancoDados.TObjetoBanco().ValidarSenhaMaster(Senha.Text)) ||
                (LoginUser.Text.Trim().ToUpper().Equals("DESENV") && new BancoDados.TObjetoBanco().ValidarSenhaDesenv(Senha.Text)))
                return true;
            object obj = new CamadaDados.Diversos.TCD_CadUsuario().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "Login",
                        vOperador = "=",
                        vVL_Busca = "'"+LoginUser.Text.Trim()+"'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "Senha",
                        vOperador = "=",
                        vVL_Busca = "'"+Senha.Text.Trim()+"'"
                    }
                }, "1");
            if (obj != null)
                return obj.ToString().Trim().Equals("1");
            else
                return false;
        }

        private void validarRegra()
        {
            if (this.Ds_regraespecial.Trim() != string.Empty)
            {
                if (LoginUser.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatorio informar usuario.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginUser.Focus();
                    return;
                }
                if (Senha.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatorio informar senha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Senha.Focus();
                    return;
                }
                if (!this.validarUsuario())
                {
                    MessageBox.Show("Usuario informado não existe no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginUser.Clear();
                    LoginUser.Focus();
                    return;
                }
                if (!this.validarSenha())
                {
                    MessageBox.Show("Senha incorreta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Senha.Clear();
                    Senha.Focus();
                    return;
                }
                if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginUser.Text.Trim(), this.Ds_regraespecial, null))
                {
                    LoginInformado = LoginUser.Text.Trim();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Usuario não tem permissão para realizar operação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginUser.Focus();
                }
            }
        }   

        private void TFRegraUsuario_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            lblMsg.Text = Ds_regraespecial;
            LoginUser.Text = vLogin;
            LoginUser.Focus();
        }

        private void TFRegraUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.validarRegra();
            else if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            this.validarRegra();
        }

        private void BTN_Sair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
