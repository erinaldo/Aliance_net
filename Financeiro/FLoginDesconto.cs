using System;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFLoginDesconto : Form
    {
        public string Cd_grupo { get; set; } = string.Empty;
        public string Cd_tabelapreco { get; set; } = string.Empty;
        public decimal Pc_desc { get; set; } = decimal.Zero;
        public string Logindesconto { get { return Login.Text; } }
        public string Cd_empresa { get; set; } = string.Empty;
            
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
                    if (Login.Text.Trim().ToUpper().Equals("MASTER") || Login.Text.Trim().ToUpper().Equals("DESENV"))
                        this.DialogResult = DialogResult.OK;
                    else
                    {
                        //Buscar Vendedor
                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_funcativo, 'S')",
                                                vOperador = "<>",
                                                vVL_Busca = "'N'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.LoginVendedor",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Login.Text.Trim() + "'"
                                            }
                                        }, "a.cd_clifor");
                        if (obj == null)
                        {
                            MessageBox.Show("Não existe vendedor configurado para o login.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Buscar lista de descontos configuradas para o vendedor
                        CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                            CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(obj.ToString(),
                                                                                            Cd_empresa,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            null);
                        if (lDesc.Count > 0)
                        {  
                            if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(Cd_tabelapreco.Trim()) &&
                                                    p.Cd_grupo.Trim().Equals(Cd_grupo.Trim())))
                            {
                                //Desconto por tabela de preco e grupo de produto
                                decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(Cd_tabelapreco.Trim()) &&
                                                                        p.Cd_grupo.Trim().Equals(Cd_grupo.Trim())).Pc_max_desconto;
                                if (pc_desconto.Value > pc_max_desc)
                                    MessageBox.Show("Usuário não tem permissão para liberar este % desconto por tabela de preco e grupo de produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else this.DialogResult = DialogResult.OK;
                            }
                            else if (lDesc.Exists(p => string.IsNullOrEmpty(p.Cd_grupo) && p.Cd_tabelapreco.Trim().Equals(Cd_tabelapreco)))
                            {
                                //Desconto por tabela de preço
                                decimal pc_max_desc = lDesc.Find(p => string.IsNullOrEmpty(p.Cd_grupo) && p.Cd_tabelapreco.Trim().Equals(Cd_tabelapreco.Trim())).Pc_max_desconto;
                                if (pc_desconto.Value > pc_max_desc)
                                    MessageBox.Show("Usuário não tem permissão para liberar este % desconto por tabela de preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else this.DialogResult = DialogResult.OK;
                            }
                            else if (lDesc.Exists(p => string.IsNullOrEmpty(p.Cd_tabelapreco) && p.Cd_grupo.Trim().Equals(Cd_grupo.Trim())))
                            {
                                //Desconto por grupo de produto
                                decimal pc_max_desc = lDesc.Find(p => string.IsNullOrEmpty(p.Cd_tabelapreco) && p.Cd_grupo.Trim().Equals(Cd_grupo.Trim())).Pc_max_desconto;
                                if (pc_desconto.Value > pc_max_desc)
                                    MessageBox.Show("Usuário não tem permissão para liberar este % desconto por grupo de produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else this.DialogResult = DialogResult.OK;
                            }
                            else if (lDesc.Exists(p => string.IsNullOrEmpty(p.Cd_grupo) && string.IsNullOrEmpty(p.Cd_tabelapreco)))
                            {
                                //verificar se vendedor possui desconto geral
                                decimal pc_max_desc = lDesc.Find(p => string.IsNullOrEmpty(p.Cd_tabelapreco) && string.IsNullOrEmpty(p.Cd_grupo)).Pc_max_desconto;
                                if (pc_desconto.Value > pc_max_desc)
                                    MessageBox.Show("Usuário não tem permissão para liberar este % desconto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else this.DialogResult = DialogResult.OK;
                            }
                            else this.DialogResult = DialogResult.OK;
                        }
                        else MessageBox.Show("Usuario não possui configuração de % desconto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
