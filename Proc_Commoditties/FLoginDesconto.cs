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
    public partial class TFLoginDesconto : Form
    {
        public decimal Pc_desc
        { get; set; }
        public string Logindesconto
        { get { return Login.Text; } }
        public TFLoginDesconto()
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
                if (CamadaNegocio.Diversos.TCN_CadUsuario.ValidarUsuario(Login.Text, Senha.Text))
                {
                    //Verificar se o usuario tem permissao para dar desconto
                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.loginvendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Login.Text.Trim() + "'"
                                        }
                                    }, "isnull(a.pc_max_desconto, 0)");
                    if (pc_desconto.Value > decimal.Parse(obj.ToString()))
                        MessageBox.Show("Usuário não tem permissão para liberar este % desconto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BTN_Sair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            this.EfetuarLogin();
        }

        private void FLoginDesconto_Load(object sender, EventArgs e)
        {
            pc_desconto.Value = Pc_desc;
        }
    }
}
