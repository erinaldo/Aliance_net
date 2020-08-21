using CamadaDados.Diversos;
using FormBusca;
using System;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFAbrirCaixaPDV : Form
    {
        private bool St_fixarvlretido
        { get; set; }
        public string pCd_empresa
        { get; set; }
        public string pLogin
        { get; set; }

        public CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV rCaixa
        { get; set; }

        public TFAbrirCaixaPDV()
        {
            InitializeComponent();
            rCaixa = null;
            pLogin = string.Empty;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (string.IsNullOrEmpty(cd_contaorig.Text))
                {
                    MessageBox.Show("Obrigatorio configurar frente caixa para empresa " + cd_empresa.Text.Trim(),
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                rCaixa = new CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV();
                rCaixa.Login = login.Text;
                rCaixa.Vl_abertura = vl_transf.Value;
                rCaixa.Cd_empresa = cd_empresa.Text;
                rCaixa.St_valortransportar = St_fixarvlretido;
                if (vl_transf.Value > decimal.Zero)
                {
                    rCaixa.rTransf = new CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa();
                    rCaixa.rTransf.CD_ContaGer_Entrada = cd_contadest.Text;
                    rCaixa.rTransf.CD_ContaGer_Saida = cd_contaorig.Text;
                    rCaixa.rTransf.CD_Empresa = cd_empresa.Text;
                    rCaixa.rTransf.CD_Historico = cd_historico.Text;
                    rCaixa.rTransf.Complemento = ds_complemento.Text;
                    rCaixa.rTransf.Valor_Transferencia = vl_transf.Value;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void BuscarConfigPDV()
        {
            CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(cd_empresa.Text, null);
            if (lCfg.Count > 0)
            {
                cd_contaorig.Text = lCfg[0].Cd_contacaixa;
                ds_contaorig.Text = lCfg[0].Ds_contacaixa;
                cd_contadest.Text = lCfg[0].Cd_contaoperacional;
                ds_contadest.Text = lCfg[0].Ds_contaoperacional;
                cd_historico.Text = lCfg[0].Cd_historicocaixa;
                ds_historico.Text = lCfg[0].Ds_historicocaixa;
            }
            else
                MessageBox.Show("Não existe configuração frente caixa para a empresa " + cd_empresa.Text.Trim(), "Mensagem",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarVlReterUsuario()
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(login.Text)) &&
                (!St_fixarvlretido))
            {
                //Buscar valor a transportar do ultimo caixa do login
                object obj_reter =
                new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().BuscarEscalar(
                    new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + login.Text.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                            }
                        }, "isnull(a.Vl_Transportar, 0)", string.Empty, "a.DT_Fechamento desc", null);
                if (obj_reter != null)
                    if(decimal.Parse(obj_reter.ToString()) > decimal.Zero)
                    {
                        vl_transf.Value = decimal.Parse(obj_reter.ToString());
                        vl_transf.Enabled = false;
                        St_fixarvlretido = true;
                    }
            }
        }

        private void TFAbrirCaixaPDV_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            cd_empresa_Leave(this, new EventArgs());
            cd_empresa.Enabled = string.IsNullOrEmpty(pCd_empresa);
            bb_empresa.Enabled = string.IsNullOrEmpty(pCd_empresa);
            login.Text = pLogin;
            login.Enabled = string.IsNullOrEmpty(pLogin);
            bb_login.Enabled = string.IsNullOrEmpty(pLogin);
            cd_empresa.Focus();
            CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv =
                CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                          string.Empty,
                                                                          Utils.Parametros.pubTerminal,
                                                                          string.Empty,
                                                                          null);
            if (lPdv.Count > 0)
                if (lPdv[0].St_fixarvlretidobool)
                {
                    vl_transf.Value = lPdv[0].Vl_maxretcaixa;
                    vl_transf.Enabled = false;
                    St_fixarvlretido = true;
                }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFAbrirCaixaPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_login_Click(object sender, EventArgs e)
        {
            string vColunas = "a.login|Login|100;" +
                              "a.nome_usuario|Nome Usuario|200";
            string vParam = "a.Tp_Registro|=|'U'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { login },
                                   new TCD_CadUsuario(), vParam);
            BuscarVlReterUsuario();
        }

        private void login_Leave(object sender, EventArgs e)
        {
            string vParam = "a.login|=|'" + login.Text.Trim() + "';" +
                            "a.tp_registro|=|'U'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { login },
                                    new TCD_CadUsuario());
            BuscarVlReterUsuario();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                BuscarConfigPDV();
                BuscarVlReterUsuario();
            }
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            UtilPesquisa.EDIT_LeaveEmpresa(vParam, new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                BuscarConfigPDV();
                BuscarVlReterUsuario();
            }
        }
    }
}
