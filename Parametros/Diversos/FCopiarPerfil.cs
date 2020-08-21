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
    public partial class TFCopiarPerfil : Form
    {
        private string plogin;
        public string pLogin
        {
            get { return login_import.Text; }
            set { plogin = value; }
        }

        public CamadaDados.Diversos.TRegistro_CadUsuario rUser
        { get { return bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario; } }

        public TFCopiarPerfil()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pUsuario.validarCampoObrigatorio())
            {
                if (string.IsNullOrEmpty(login_import.Text))
                {
                    MessageBox.Show("Obrigatorio informar login de importação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    login_import.Focus();
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFCopiarPerfil_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            login_import.Text = plogin;
            login_import_Leave(this, new EventArgs());
            bsUsuario.AddNew();
        }

        private void bb_usuario_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nome_usuario|Nome Usuario|200;" +
                              "a.login|Login|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { login_import, nm_usuario },
                                            new CamadaDados.Diversos.TCD_CadUsuario(), "a.Tp_Registro|=|'U'");
        }

        private void login_import_Leave(object sender, EventArgs e)
        {
            string vParam = "a.login|=|'" + login_import.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { login_import, nm_usuario },
                                            new CamadaDados.Diversos.TCD_CadUsuario());
        }

        private void Login_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Login.Text))
            {
                CamadaDados.Diversos.TList_CadUsuario lUser =
                    CamadaNegocio.Diversos.TCN_CadUsuario.Busca(Login.Text,
                                                                string.Empty,
                                                                string.Empty,
                                                                null);
                if (lUser.Count > 0)
                    if (MessageBox.Show("Login ja se encontra cadastrado no sistema.\r\n" +
                                       "Caso prossiga com a importação, o perfil atual será apagado.\r\n" +
                                       "Deseja prosseguir com a importação?", "Pergunta", MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        bsUsuario.Clear();
                        bsUsuario.DataSource = lUser;
                        Login.Enabled = false;
                        if (!Senha.Focus())
                            Nome_Usuario.Focus();
                    }
                    else
                    {
                        Login.Clear();
                        Login.Focus();
                    }
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCopiarPerfil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
