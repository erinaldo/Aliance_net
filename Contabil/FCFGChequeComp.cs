using System;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFCFGChequeComp : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_contagerorig
        { get; set; }
        public string pDs_contagerorig
        { get; set; }
        public string pCd_contagerdest
        { get; set; }
        public string pDs_contagerdest
        { get; set; }
        public string pTp_movimento
        { get; set; }
        public string pCd_contadeb
        { get; set; }
        public string pDs_contadeb
        { get; set; }
        public string pCd_classificacaodeb
        { get; set; }
        public string pCd_contacred
        { get; set; }
        public string pDs_contacred
        { get; set; }
        public string pCd_classificacaocred
        { get; set; }

        private CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado rcheque;
        public CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado rCheque
        {
            get
            {
                if (bsCheque.Current != null)
                    return bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado;
                else return null;
            }
            set { rcheque = value; }
        }

        public TFCFGChequeComp()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("PAGAR", "P"));
            cbx.Add(new Utils.TDataCombo("RECEBER", "R"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCFGChequeComp_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rcheque != null)
            {
                bsCheque.DataSource = new CamadaDados.Contabil.TList_CTB_CFGCheque_Compensado() { rcheque };
                CD_Empresa.Enabled = false;
                btn_Empresa.Enabled = false;
                cd_contagerent.Enabled = false;
                bb_contagerent.Enabled = false;
                cd_contagersai.Enabled = false;
                bb_contagersai.Enabled = false;
                tp_movimento.Enabled = false;
            }
            else
            {
                bsCheque.AddNew();
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Cd_empresa = pCd_empresa;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Nm_empresa = pNm_empresa;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Cd_contager_saida = pCd_contagerorig;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Ds_contager_saida = pDs_contagerorig;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Cd_contager_entrada = pCd_contagerdest;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Ds_contager_entrada = pDs_contagerdest;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).TP_Movimento = pTp_movimento;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Cd_conta_ctb_credstr = pCd_contacred;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Ds_conta_ctb_cred = pDs_contacred;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Cd_classificacao_cred = pCd_classificacaocred;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Cd_conta_ctb_debstr = pCd_contadeb;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Ds_conta_ctb_deb = pDs_contadeb;
                (bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado).Cd_classificacao_deb = pCd_classificacaodeb;
                bsCheque.ResetCurrentItem();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCFGChequeComp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void bb_contagerent_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|350;" +
                              "a.cd_contager|Cd. Conta|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
            new Componentes.EditDefault[] { cd_contagerent, ds_contagerent },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contagerent_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contagerent.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contagerent, ds_contagerent },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_contagersai_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|350;" +
                              "a.cd_contager|Cd. Conta|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
            new Componentes.EditDefault[] { cd_contagersai, ds_contagersai },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contagersai_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contagersai.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contagersai, ds_contagersai },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_contadeb_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
            {
                cd_contadeb.Text = rConta.Cd_conta_ctbstr;
                ds_contadeb.Text = rConta.Ds_contactb.Trim();
                classificacaodeb.Text = rConta.Cd_classificacao;
            }
        }

        private void cd_contadeb_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + cd_contadeb.Text + "';isnull(a.st_Registro, 'A')|<>|'C';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { cd_contadeb, ds_contadeb, classificacaodeb },
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_contacred_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
            {
                cd_contacred.Text = rConta.Cd_conta_ctbstr;
                ds_contacred.Text = rConta.Ds_contactb.Trim();
                classificacaocred.Text = rConta.Cd_classificacao;
            }
        }

        private void cd_contacred_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + cd_contacred.Text + "';isnull(a.st_Registro, 'A')|<>|'C';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { cd_contacred, ds_contacred, classificacaocred },
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }
    }
}
