using CamadaDados.Faturamento.Orcamento;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Faturamento.Orcamento;
using CamadaNegocio.Faturamento.Pedido;
using FormBusca;
using System;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFTrocarClienteProposta : Form
    {
        public TRegistro_Orcamento Orcamento { get; set; }
        public string pCd_clifor => cd_clifor.Text;
        public string pMotivoTroca => MotivoTroca.Text;
        public string Login { get; set; }

        public TFTrocarClienteProposta()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if(string.IsNullOrEmpty(cd_clifor.Text))
            {
                MessageBox.Show("Obrigatório informar novo cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_clifor.Focus();
                return;
            }
            if(string.IsNullOrEmpty(MotivoTroca.Text))
            {
                MessageBox.Show("Obrigatório informar motivo da troca.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MotivoTroca.Focus();
                return;
            }
            if(!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR TROCAR CLIENTE PROPOSTA", null))
                using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                {
                    fRegra.Login = Utils.Parametros.pubLogin;
                    fRegra.Ds_regraespecial = "PERMITIR TROCAR CLIENTE PROPOSTA";
                    if (fRegra.ShowDialog() == DialogResult.Cancel)
                    {
                        MessageBox.Show("Obrigatório informar LOGIN com permissão para realizar troca", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else Login = fRegra.Login;
                }
            DialogResult = DialogResult.OK;
        }

        private void bbClifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new TCD_CadClifor());
        }

        private void TFTrocarClienteProposta_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsOrcamento.DataSource = new TList_Orcamento { Orcamento };
            //Buscar itens orcamento
            bsOrcamentoItem.DataSource = TCN_Orcamento_Item.Buscar(Orcamento.Nr_orcamentostr, false, false, null);
            //Buscar Pedidos
            bsPedidos.DataSource = TCN_Pedido.Busca(string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    false,
                                                    false,
                                                    false,
                                                    false,
                                                    false,
                                                    false,
                                                    false,
                                                    false,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    decimal.Zero,
                                                    decimal.Zero,
                                                    Orcamento.Nr_orcamentostr,
                                                    string.Empty,
                                                    false,
                                                    0,
                                                    string.Empty,
                                                    null);
            //Buscar Parcelas
            bsParcelas.DataSource = new TCD_LanParcela().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                    "inner join tb_fat_pedido_itens y " +
                                    "on x.nr_pedido = y.nr_pedido " +
                                    "and x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and y.nr_orcamento = " + Orcamento.Nr_orcamentostr + ")"
                    }
                }, 0, string.Empty, "a.dt_vencto", string.Empty);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFTrocarClienteProposta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
