using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFLanSessaoPDV : Form
    {
        public string Usuario
        { get { return Login.Text; } }
        public string Mensagem
        { get; set; }
        public string Titulo
        { get; set; }
        //Buscar Ponto Venda Terminal
        CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv =
            CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                      string.Empty,
                                                                      Utils.Parametros.pubTerminal,
                                                                      string.Empty,
                                                                      null);

        public TFLanSessaoPDV()
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
            try
            {
                if((Login.Text.Trim().Equals("MASTER") && new BancoDados.TObjetoBanco().ValidarSenhaMaster(Senha.Text)) ||
                    (Login.Text.Trim().Equals("DESENV") && new BancoDados.TObjetoBanco().ValidarSenhaDesenv(Senha.Text)))
                    this.DialogResult = DialogResult.OK;
                else if (CamadaNegocio.Diversos.TCN_CadUsuario.ValidarUsuario(Login.Text, Senha.Text))
                {
                    if (lPdv.Count > 0)
                    {
                        if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Login.Text, "PERMITIR EMITIR CUPOM FISCAL", null))
                        {
                            MessageBox.Show("Usuario não tem permissão para emitir cupom fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    if (!Login.Text.Trim().ToUpper().Equals("MASTER") && !Login.Text.Trim().ToUpper().Equals("DESENV"))
                        CamadaNegocio.Diversos.TCN_CadTerminal.ValidaTerminal(Login.Text);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFLanSessaoPDV_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            Login.Text = Utils.Parametros.pubLogin.Trim();
            lblMsg.Text = Mensagem;
            if (!string.IsNullOrEmpty(Mensagem))
                if (Mensagem.Equals("PERMITIR VENDA ABAIXO CUSTO"))
                    if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, Mensagem, null))
                        DialogResult = DialogResult.OK;
            if (lPdv.Count > 0)
            {
                label3.Text = "  PDV";
                lblPdv.Text = lPdv[0].Id_pdvstr + "-" + lPdv[0].Ds_pdv;
            }
            else
                label3.Text = Titulo;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFLanSessaoPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                EfetuarLogin();
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_ok_Click(object sender, EventArgs e)
        {
            EfetuarLogin();
        }

        private void BTN_Sair_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            EfetuarLogin();
        }

        private void lblLoginCorrente_Click(object sender, EventArgs e)
        {
            Login.Text = Utils.Parametros.pubLogin;
            Senha.Text = Utils.Parametros.pubSenha;
            EfetuarLogin();
        }
    }
}
