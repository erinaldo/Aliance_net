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
    public partial class TFLan_BloqueioCredito : Form
    {
        public bool St_liquidacao
        { get; set; }
        public bool St_consulta
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados
        { get; set; }
        public decimal Vl_fatura
        { get; set; }
        public bool St_desbloqueado
        { get; set; }

        public TFLan_BloqueioCredito()
        {
            InitializeComponent();
            this.Vl_fatura = decimal.Zero;
        }

        private string MotivoBloqueio()
        {
            string motivo = string.Empty;
            string virg = string.Empty;
            if ((rDados.Vl_limitecredito > decimal.Zero) &&
                ((rDados.Vl_limitecredito - rDados.Vl_debito_aberto) < Vl_fatura))
            {
                motivo = "LIMITE CREDITO INSUFICIENTE(SALDO=" + (rDados.Vl_limitecredito - rDados.Vl_debito_aberto).ToString("N2", new System.Globalization.CultureInfo("pt-BR")) +
                            ", VL. VENDA=" + Vl_fatura.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + ")";
                virg = ",";
            }
            if (rDados.St_bloq_debitovencidobool && (rDados.Vl_debito_vencto > decimal.Zero))
            {
                motivo += virg + "DEBITO VENCIDO=" + rDados.Vl_debito_vencto.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                virg = ",";
            }
            if (rDados.Vl_ch_devolvido > decimal.Zero)
            {
                motivo += virg + "CHEQUE DEVOLVIDO=" + rDados.Vl_ch_devolvido.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                virg = ",";
            }
            if (rDados.St_bloqcreditoavulsobool)
                motivo += virg + rDados.Ds_motivobloqavulso.Trim();
            return motivo;
        }

        private void EfetuarLogin()
        {
            try
            {
                if (Utils.Parametros.pubLogin.Trim().Equals("MASTER") || 
                    Utils.Parametros.pubLogin.Trim().Equals("DESENV") ||
                    CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VENDA PARA CLIENTE INADIMPLENTE", null))
                {
                    //Gravar registro de desbloqueio do credito para efeito de auditoria
                    Utils.InputBox ibp = new Utils.InputBox();
                    ibp.Text = "Observação Desbloqueio";
                    string motivo = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(motivo) || motivo.Trim().Length < 10)
                    {
                        MessageBox.Show("Obrigatório informar motivo para desbloqueio.\r\nObs.: Informar no minimo 10 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    CamadaNegocio.Financeiro.Duplicata.TCN_LiberarCredito.Gravar(
                        new CamadaDados.Financeiro.Duplicata.TRegistro_LiberarCredito()
                        {
                            Cd_clifor = rDados.Cd_clifor,
                            Ds_obsbloqueio = this.MotivoBloqueio(),
                            Ds_obsliberacao = motivo,
                            Dt_liberacao = CamadaDados.UtilData.Data_Servidor(),
                            Dt_solicitacao = CamadaDados.UtilData.Data_Servidor(),
                            Loginbloqueio = Utils.Parametros.pubLogin,
                            Logindesbloqueio = Utils.Parametros.pubLogin,
                            Vl_compra = vl_financeiro.Value,
                            St_registro = "C"
                        }, null);
                    this.St_desbloqueado = true;
                    this.DialogResult = DialogResult.OK;
                }
                else using(TFValidaLogin fLogin = new TFValidaLogin())
                {
                    if (fLogin.ShowDialog() == DialogResult.OK)
                    {
                        if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(fLogin.pLogin, "PERMITIR VENDA PARA CLIENTE INADIMPLENTE", null))
                        {
                            MessageBox.Show("Usuario não tem permissão para desbloquear crédito do cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Gravar registro de desbloqueio do credito para efeito de auditoria
                        Utils.InputBox ibp = new Utils.InputBox();
                        ibp.Text = "Observação Desbloqueio";
                        string motivo = ibp.ShowDialog();
                        if (string.IsNullOrEmpty(motivo) || motivo.Trim().Length < 10)
                        {
                            MessageBox.Show("Obrigatório informar motivo para desbloqueio.\r\nObs.: Informar no minimo 10 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        CamadaNegocio.Financeiro.Duplicata.TCN_LiberarCredito.Gravar(
                            new CamadaDados.Financeiro.Duplicata.TRegistro_LiberarCredito()
                            {
                                Cd_clifor = rDados.Cd_clifor,
                                Ds_obsbloqueio = this.MotivoBloqueio(),
                                Ds_obsliberacao = motivo,
                                Dt_liberacao = CamadaDados.UtilData.Data_Servidor(),
                                Dt_solicitacao = CamadaDados.UtilData.Data_Servidor(),
                                Loginbloqueio = Utils.Parametros.pubLogin,
                                Logindesbloqueio = fLogin.pLogin,
                                Vl_compra = vl_financeiro.Value,
                                St_registro = "C"
                            }, null);
                        this.St_desbloqueado = true;
                        this.DialogResult = DialogResult.OK;
                    }
                    else MessageBox.Show("Obrigatório informar LOGIN para desbloquear venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        
        private void FLan_BloqueioCredito_Load(object sender, EventArgs e)
        {
            this.St_desbloqueado = false;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;

            cd_clifor.Text = rDados.Cd_clifor;
            nm_clifor.Text = rDados.Nm_clifor;
            vl_financeiro.Value = Vl_fatura;
            if (!this.St_liquidacao)
            {
                vl_limitecredito.Value = rDados.Vl_limitecredito;
                vl_debitoaberto.Value = rDados.Vl_debito_aberto;
                Vl_dupPerdidas.Value = rDados.Vl_dupPerdidas;
                saldo_credito.Value = vl_limitecredito.Value > decimal.Zero ? vl_limitecredito.Value - vl_debitoaberto.Value : decimal.Zero;
                if ((vl_limitecredito.Value > decimal.Zero) && (saldo_credito.Value < vl_financeiro.Value))
                    lblSaldoCredito.ForeColor = Color.Red;
                vl_debitovencido.Value = rDados.Vl_debito_vencto;
                st_bloq_debitovencido.Checked = rDados.St_bloq_debitovencidobool;
                if (st_bloq_debitovencido.Checked && (vl_debitovencido.Value > decimal.Zero))
                    lblDebVencto.ForeColor = Color.Red;
                st_bloqavulso.Checked = rDados.St_bloqcreditoavulsobool;
                st_renovarcadastro.Checked = rDados.St_renovarcadastro;
                dt_renovacaocadastro.Text = rDados.Dt_renovacaocadastro.HasValue ? rDados.Dt_renovacaocadastro.Value.ToString("dd/MM/yyyy") : string.Empty;
                if (st_renovarcadastro.Checked)
                    lblRenovacao.ForeColor = Color.Red;
                bb_renovar.Enabled = st_renovarcadastro.Checked && CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR RENOVAR CADASTRO CLIENTE", null);
                st_bloqueioSPC.Checked = rDados.St_bloqueiospcbool;
                dt_consulaSPC.Text = rDados.Dt_consultaSPC.HasValue ? rDados.Dt_consultaSPC.Value.ToString("dd/MM/yyyy") : string.Empty;
                ds_consultaSPC.Text = rDados.Ds_ConsultaSPC;
                if (st_bloqueioSPC.Checked)
                    lblDescricao.ForeColor = Color.Red;
            }
            
            tot_chdevolvido.Value = rDados.Vl_ch_devolvido;
            if (tot_chdevolvido.Value > decimal.Zero)
                lblChDevolvido.ForeColor = Color.Red;
            vl_limitecredch.Value = rDados.Vl_limitecredCH;
            vl_ch_predatado.Value = rDados.Vl_ch_predatado;
            saldo_credCH.Value = vl_limitecredch.Value > decimal.Zero ? vl_limitecredch.Value - vl_ch_predatado.Value : decimal.Zero;
            if ((vl_limitecredch.Value > decimal.Zero) && (saldo_credCH.Value < vl_financeiro.Value))
                lblSaldoCredCH.ForeColor = Color.Red;
            if (this.St_consulta)
                bb_desbloquear.Enabled = false;
        }

        private void bb_desbloquear_Click(object sender, EventArgs e)
        {
            this.EfetuarLogin();
        }

        private void bb_renovar_Click(object sender, EventArgs e)
        {
            //Buscar dados clifor
            CamadaDados.Financeiro.Cadastros.TList_CadClifor lClifor =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(rDados.Cd_clifor,
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
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              null);
            if (lClifor.Count > 0)
            {
                lClifor[0].lEndereco = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lClifor[0].Cd_clifor,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 0,
                                                                                                 null);
                lClifor[0].lContato = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                     lClifor[0].Cd_clifor,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     string.Empty,
                                                                                                     0,
                                                                                                     null);
                lClifor[0].lDadosBanc = CamadaNegocio.Financeiro.Cadastros.TCN_CadDados_Bancarios_Clifor.Busca(lClifor[0].Cd_clifor,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               null);
                using (Financeiro.Cadastros.TFClifor fClifor = new Financeiro.Cadastros.TFClifor())
                {
                    fClifor.Text = "Renovando Cadastro Cliente/Fornecedor";
                    fClifor.rClifor = lClifor[0];
                    if (fClifor.ShowDialog() == DialogResult.OK)
                    {
                        if (fClifor.rClifor != null)
                        {
                            try
                            {
                                fClifor.rClifor.Dt_renovacaocadastro = CamadaDados.UtilData.Data_Servidor();
                                fClifor.rClifor.Loginrenovacao = Utils.Parametros.pubLogin;
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                st_renovarcadastro.Checked = false;
                                dt_renovacaocadastro.Text = fClifor.rClifor.Dt_renovacaocadastrostr;
                                bb_renovar.Enabled = false;
                                MessageBox.Show("Cadastro renovado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bool st_bloqfin = (vl_limitecredito.Value > decimal.Zero) && ((vl_limitecredito.Value - vl_debitoaberto.Value) < vl_financeiro.Value);
                                bool st_bloqdeb = st_bloq_debitovencido.Checked && vl_debitovencido.Value > decimal.Zero;
                                if ((!st_bloqfin) && (!st_bloqdeb) && (!st_bloqavulso.Checked))
                                {
                                    this.St_desbloqueado = true;
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            if (vl_debitoaberto.Value > decimal.Zero)
                using (TFListaParcelas fLista = new TFListaParcelas())
                {
                    fLista.Cd_clifor = rDados.Cd_clifor;
                    fLista.ShowDialog();
                }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if(vl_ch_predatado.Value > decimal.Zero)
                using (TFListaChPreDatados fLista = new TFListaChPreDatados())
                {
                    fLista.Nm_clifor = rDados.Nm_clifor;
                    fLista.ShowDialog();
                }
        }

        private void st_bloqavulso_CheckedChanged(object sender, EventArgs e)
        {
            lklMotivo.Enabled = st_bloqavulso.Checked;
        }

        private void lklMotivo_Click(object sender, EventArgs e)
        {
            if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR MOTIVO BLOQUEIO CREDITO AVULSO", null))
                MessageBox.Show(rDados.Ds_motivobloqavulso.Trim(), "Motivo Bloqueio Avulso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
